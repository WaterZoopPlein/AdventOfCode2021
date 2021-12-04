using System.Diagnostics;
using AoC2021Days;

namespace AoC2021Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var day = new Day04(); // Replace date number here

            Solve(day);
        }

        private static void Solve(IDay day)
        {
            var watch1 = Stopwatch.StartNew();
            day.SolvePartOne();
            watch1.Stop();

            var watch2 = Stopwatch.StartNew();
            day.SolvePartTwo();
            watch2.Stop();

            Console.WriteLine($"Part One took {watch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Part Two took {watch2.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
