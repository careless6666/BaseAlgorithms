using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.Graph.MinimumSpanningTree
{
    public class MinCostToConnectAllPointsPrims
    {
        int Compare(Edge a, Edge b)
        {
            if (a.Distance == b.Distance) return a.A.Id.CompareTo(b.A.Id) != 0 ? a.A.Id.CompareTo(b.A.Id) : a.B.Id.CompareTo(b.B.Id);
            return a.Distance.CompareTo(b.Distance);
        }
        
        class Edge
        {
            public Point A {get;}        
            public Point B {get;}
            public int Distance {get;}
        
            public Edge (Point a, Point b)
            {
                A = a;
                B = b;
                Distance = Math.Abs(a.X-b.X) + Math.Abs(a.Y-b.Y);
            }
        }
    
        class Point
        {
            public int X;
            public int Y;
            public int Id;
        }
        
        public int MinCostConnectPoints(int[][] points) {
            var pts = new Point[points.Length];
            for (var i = 0; i < points.Length; i++)
            {
                pts[i] = new Point{X=points[i][0],Y=points[i][1], Id=i};
            }
        
            var edges = new SortedDictionary<Edge, bool>(new EdgeComparer());
            for (var i = 1; i < points.Length; i++)
            {
                edges.Add(new Edge(pts[0], pts[i]), false);
            }
            var visited = new bool[points.Length];
            visited[0] = true;
            var remainingVertices = points.Length-1;
            var distance = 0;
            while (edges.Count > 0 && remainingVertices > 0)
            {
                var curEdge = edges.Keys.First();
                edges.Remove(curEdge);
                Point nextVertex = null;
                if (!visited[curEdge.A.Id])
                {
                    nextVertex = curEdge.A;
                }
                else if (!visited[curEdge.B.Id])
                {
                    nextVertex = curEdge.B;
                }
                else
                {
                    continue;
                }
            
                visited[nextVertex.Id] = true;
                distance += curEdge.Distance;
                for (int i = 0; i < pts.Length; i++)
                {
                    if (!visited[i])
                    {
                        edges.Add(new Edge(nextVertex, pts[i]), false);
                    }
                }
                remainingVertices--;
            }
            return distance;
        }
    
        class EdgeComparer : IComparer<Edge>
        {
            public int Compare(Edge a, Edge b)
            {
                if (a.Distance == b.Distance) return a.A.Id.CompareTo(b.A.Id) != 0 ? a.A.Id.CompareTo(b.A.Id) : a.B.Id.CompareTo(b.B.Id);
                return a.Distance.CompareTo(b.Distance);
            }
        }
    }
}