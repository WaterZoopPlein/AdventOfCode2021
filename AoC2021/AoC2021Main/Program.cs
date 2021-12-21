using System.Diagnostics;
using AoC2021Days;

namespace AoC2021Main
{
    public class Program
    {
        public static void Main()
        {
            var day = new Day20(); // Replace date number here

            Solve(day);
        }

        private static void Solve(IDay day)
        {
            var watch1 = Stopwatch.StartNew();
            Console.WriteLine("Part 1");
            day.SolvePartOne();
            watch1.Stop();

            var watch2 = Stopwatch.StartNew();
            Console.WriteLine("Part 2");
            day.SolvePartTwo();
            watch2.Stop();

            Console.WriteLine($"Part One took {watch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Part Two took {watch2.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
