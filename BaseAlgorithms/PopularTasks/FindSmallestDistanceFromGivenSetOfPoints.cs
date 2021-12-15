using System;
using System.Drawing;
using System.Linq;

namespace BaseAlgorithms.PopularTasks
{
    public class FindSmallestDistanceFromGivenSetOfPoints
    {
        // A utility function to find the  
        // distance between two points  
        private static double Dist(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        // A Brute Force method to return the  
        // smallest distance between two points  
        // in P[] of size n  
        private static double BruteForce(Point[] p, int n)
        {
            var min = double.MaxValue;
            for (var i = 0; i < n; ++i)
                for (var j = i + 1; j < n; ++j)
                    if (Dist(p[i], p[j]) < min)
                        min = Dist(p[i], p[j]);
            return min;
        }

        // A utility function to find the  
        // distance beween the closest points of  
        // strip of given size. All points in  
        // strip[] are sorted accordint to  
        // y coordinate. They all have an upper 
        // bound on minimum distance as d.  
        // Note that this method seems to be  
        // a O(n^2) method, but it's a O(n)  
        // method as the inner loop runs at most 6 times  
        private static double StripClosest(Point[] strip, int size, double d)
        {
            var min = d; // Initialize the minimum distance as d  

            strip = strip.OrderBy(x => Math.Atan2(x.X, x.Y)).ToArray();

            // Pick all points one by one and try the next points till the difference  
            // between y coordinates is smaller than d.  
            // This is a proven fact that this loop runs at most 6 times  
            for (var i = 0; i < size; ++i)
                for (var j = i + 1; j < size && (strip[j].Y - strip[i].Y) < min; ++j)
                    if (Dist(strip[i], strip[j]) < min)
                        min = Dist(strip[i], strip[j]);

            return min;
        }

        // A recursive function to find the  
        // smallest distance. The array P contains  
        // all points sorted according to x coordinate  
        private static double ClosestUtil(Point[] P, int n)
        {
            // If there are 2 or 3 points, then use brute force  
            if (n <= 3)
                return BruteForce(P, n);

            // Find the middle point  
            var mid = n / 2;
            var midPoint = P[mid];

            // Consider the vertical line passing  
            // through the middle point calculate  
            // the smallest distance dl on left  
            // of middle point and dr on right side  
            var dl = ClosestUtil(P, mid);
            var extendedP = P.ToList();
            extendedP.Add(midPoint);
            var dr = ClosestUtil(extendedP.ToArray(), n - mid);

            // Find the smaller of two distances  
            var d = Math.Min(dl, dr);

            // Build an array strip[] that contains  
            // points close (closer than d)  
            // to the line passing through the middle point  
            var strip = new Point[n];
            var j = 0;
            for (var i = 0; i < n; i++)
                if (Math.Abs(P[i].X - midPoint.X) < d)
                {
                    strip[j] = P[i];
                    j++;
                }

            // Find the closest points in strip.  
            // Return the minimum of d and closest  
            // distance is strip[]  
            return Math.Min(d, StripClosest(strip, j, d));
        }

        // The main function that finds the smallest distance  
        // This method mainly uses closestUtil()  
        public static double Closest(Point[] P, int n)
        {
            P = P.OrderBy(x => Math.Atan2(x.X, x.Y)).ToArray();

            // Use recursive function closestUtil() 
            // to find the smallest distance  
            return ClosestUtil(P, n);
        }
    }
}