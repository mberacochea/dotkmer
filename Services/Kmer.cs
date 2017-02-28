using System.Collections.Generic;
using Iondude.Models;

namespace Iondude.Services
{
    public class Kmer
    {
        private Dictionary<string, int> contextCounters = new Dictionary<string, int>();
        private int k = 5;

        public Kmer(int k)
        {
            this.k = k;
        }

        public void CountContexts(FastQ read)
        {
            for (int i = 0; i < read.Seq.Length - this.k; i++)
            {
                int currentCount = 0;
                string kmer = read.Seq.Substring(i, this.k);
                this.contextCounters.TryGetValue(kmer, out currentCount);
                this.contextCounters[kmer] = currentCount + 1; 
            }
        }

        public int Count(string query)
        {
            if (this.contextCounters.ContainsKey(query))
            {
                return this.contextCounters[query];
            }

            return 0;
        }
    }
}