using System;
using System.Collections;

namespace BaseAlgorithms.PopularTasks
{
    public class Bloom
    {
        const int m = 1000;
        const int k = 5;
        BitArray _bloom = new BitArray(m);

        private static int[] Hashk(string s, int k)
        {
            var hashes = new int[k];
            hashes[0] = Math.Abs(s.GetHashCode());
            var r = new Random(hashes[0]);
            for (var i = 1; i < k; i++)
                hashes[i] = r.Next();
            
            return hashes;
        }

        public void AddData(string s)
        {
            var hashes = Hashk(s, k);
            for (var i = 0; i < k; i++)
                _bloom.Set(hashes[i] % m, true);
        }

        public Boolean LookUp(string s)
        {
            var hashes = Hashk(s, k);
            for (var i = 0; i < k; i++)
                if (_bloom[hashes[i] % m] == false) return false;
            
            return true;
        }
    }
}
