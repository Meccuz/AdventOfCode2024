using AdventOfCode2024.Common;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public static class Day03
    {
        public static void Solve()
        {
            var lines = DataReader.ReadInputData("03", false);
            Part1(lines);
            //lines = DataReader.ReadInputData("03", true, true);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            var line = string.Join(string.Empty, lines);
            var tmp = line.Split("do()");
            var res = 0;
            foreach (var item in tmp)
            {
                var valid = item.Split("don't()").First();
                var regex = new Regex(@"mul\((\d+),(\d+)\)");
                var matches = regex.Matches(valid);
                foreach (Match match in matches)
                {
                    res += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }

            Console.WriteLine($"Part 2: {res}");
        }

        private static void Part1(string[] lines)
        {
            var res = 0;
            foreach (var line in lines)
            {
                var regex = new Regex(@"mul\((\d+),(\d+)\)");
                var matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    res += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }
            Console.WriteLine($"Part 1: {res}");
        }
    }
}
