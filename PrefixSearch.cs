using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 {
    public static class PrefixSearch {
        public static string Naive(string[] needles, string haystack) {
            for (int i = 0; i < needles.Length; i++) {
                string needle = needles[i];

                if (needle.Length <= haystack.Length && NaiveMatch(needles[i], haystack)) {
                    return needle;
                }
            }

            return "Not found";
        }

        private static bool NaiveMatch(string needle, string haystack) {
            for (int i = 0; i < needle.Length; i++) {
                if (needle[i] != haystack[i]) {
                    return false;
                }
            }

            return true;
        }

        public static string Kmp(string[] needles, string haystack) {
            for (int i = 0; i < needles.Length; i++) {
                string needle = needles[i];
                int m = needle.Length;
                int n = haystack.Length;
                int[] pi = PrefixFunction(needle);
                int q = 0;

                for (int j = 0; j < n; j++) {
                    while (q > 0 && needle[q] != haystack[j]) {
                        q = pi[q];
                    }

                    if (needle[q] == haystack[j]) {
                        q++;
                    }

                    if (q == m) {
                        return needle;
                    }

                }
            }

            return "Not found";
        }

        private static int[] PrefixFunction(string needle) {
            int m = needle.Length;
            int[] pi = new int[m];

            pi[0] = 0;
            int k = 0;

            for (int q = 1; q < m; q++) {
                while (k > 0 && needle[k] != needle[q]) {
                    k = pi[k - 1];
                }

                if (needle[k] == needle[q]) {
                    k++;
                }

                pi[q] = k;
            }

            return pi;
        }
    }
}
