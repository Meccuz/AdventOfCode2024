using AdventOfCode2024.Common;

namespace AdventOfCode2024
{
    public static class Day07
    {
        public static void Solve()
        {
            var lines = DataReader.ReadInputData("07", false);
            Part1(lines);
        }

        private static void Part1(string[] lines)
        {
            Int64 res = 0;
            foreach (var line in lines)
            {
                var split = line.Split(':');
                var result = Int64.Parse(split[0]);
                var numbers = split[1].Trim().Split(' ').Select(int.Parse).ToList();
                if (EvaluateRec(numbers, result, numbers[0], 0)) res += result;
            }
            Console.WriteLine($"Part 1: {res}");
        }

        private static void Part2(string[] lines)
        {
            Int64 res = 0;
            foreach (var line in lines)
            {
                var split = line.Split(':');
                var result = Int64.Parse(split[0]);
                var numbers = split[1].Trim().Split(' ').Select(int.Parse).ToList();
                if (EvaluateRec2(numbers, result, numbers[0], 0)) res += result;
            }
            Console.WriteLine($"Part 2: {res}");
        }

        private static bool EvaluateRec(List<int> numbers, Int64 result, Int64 partial, int index)
        {
            if (partial > result) return false;
            if (index == numbers.Count - 1)
            {
                if (partial == result) return true;
                return false;
            }

            return EvaluateRec(numbers, result, partial * numbers[index + 1], index + 1) ||
                EvaluateRec(numbers, result, partial + numbers[index + 1], index + 1);
        }

        private static bool EvaluateRec2(List<int> numbers, Int64 result, Int64 partial, int index)
        {
            if (partial > result) return false;
            if (index == numbers.Count - 1)
            {
                if (partial == result) return true;
                return false;
            }

            return EvaluateRec2(numbers, result, partial * numbers[index + 1], index + 1) ||
                EvaluateRec2(numbers, result, partial + numbers[index + 1], index + 1) ||
                EvaluateRec2(numbers, result, Int64.Parse(partial.ToString() + numbers[index + 1].ToString()), index + 1);
        }
    }
}