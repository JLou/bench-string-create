using BenchmarkDotNet.Running;

namespace bench;
internal class Program
{
    private static void Main(string[] args)
    {
        //var bench = new Benchs();
        //Console.WriteLine(bench.StringCreate() == bench.StringReplace());
        //Console.WriteLine();
        //Console.WriteLine(bench.StringCreate());
        //Console.WriteLine();
        //Console.WriteLine(bench.StringReplace());

        var summary = BenchmarkRunner.Run<Benchs>();
    }
}
