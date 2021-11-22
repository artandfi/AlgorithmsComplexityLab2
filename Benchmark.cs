using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 {
    public class Benchmark {
        private const string _haystack = "abcdefghijklmnopqrstuvwxyz ";

        [ParamsSource(nameof(ValuesForK))]
        public int K { get; set; }
        
        public IEnumerable<int> ValuesForK => new List<int> { 2, 5, 10, 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };

        [Benchmark]
        public string PrefixNaive() => PrefixSearch.Naive(Needles(K), _haystack);

        [Benchmark]
        public string PrefixKmp() => PrefixSearch.Kmp(Needles(K), _haystack);

        private string[] Needles(int k) {
            string[] needles = new string[k];
            string start = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < k; i++) {
                needles[i] = start + (char)(i + 33);
            }

            return needles;
        }
    }
}
