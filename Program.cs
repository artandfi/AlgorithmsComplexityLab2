using BenchmarkDotNet.Running;
using System;

namespace Lab2 {
    class Program {
        static void Main(string[] args) {
            BenchmarkRunner.Run<BenchmarkN>();
        }
    }
}
