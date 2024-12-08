using AdventOfCode2024.Common;

namespace AdventOfCode2024
{
    public static class Day01
    {
        public static void Solve()
        {
            var lines = DataReader.ReadInputData("01", false);
            List<int> col1 = new();
            List<int> col2 = new();
            foreach (var line in lines)
            {
                var tmp = line.Split("   ");
                col1.Add(int.Parse(tmp[0]));
                col2.Add(int.Parse(tmp[1]));
            }
            Part1(col1, col2);
            Part2(col1, col2);
        }

        private static void Part2(List<int> col1, List<int> col2)
        {
            Dictionary<int, int> map = [];
            var res = 0;
            foreach (var num in col1)
            {
                if (map.TryGetValue(num, out var val))
                {
                    res += num * val;
                }
                else
                {
                    val = col2.Count(x => x == num);
                    map.Add(num, val);
                    res += num * val;
                }
            }

            Console.WriteLine($"Part 2: {res}");
        }

        private static void Part1(List<int> col1, List<int> col2)
        {
            col1.Sort();
            col2.Sort();

            var res = 0;
            for (int i = 0; i < col1.Count; i++)
            {
                res += Math.Abs(col1[i] - col2[i]);
            }

            Console.WriteLine($"Part 1: {res}");
        }
    }
}
