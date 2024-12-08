using AdventOfCode2024.Common;

namespace AdventOfCode2024
{
    public static class Day02
    {
        public static void Solve()
        {
            var lines = DataReader.ReadInputData("02", false);
            var reports = lines.Select(x => x.Split(" ").Select(int.Parse).ToList()).ToList();
            Part1(reports);
            Part2(reports);
        }

        private static void Part2(List<List<int>> reports)
        {
            var safeReports = 0;
            foreach (var report in reports)
            {
                if (IsSafe(report))
                {
                    safeReports++;
                }
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var newReport = new List<int>(report);
                        newReport.RemoveAt(i);
                        if (IsSafe(newReport))
                        {
                            safeReports++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Part 1: {safeReports}");
        }

        private static void Part1(List<List<int>> reports)
        {
            var safeReports = 0;
            foreach (var report in reports)
            {
                bool isSafe = IsSafe(report);

                if (isSafe) safeReports++;
            }

            Console.WriteLine($"Part 1: {safeReports}");
        }

        private static bool IsSafe(List<int> report)
        {
            var differences = report.Zip(report.Skip(1), (first, second) => second - first);
            var isSafe = differences.All(x => x > 0 && x < 4) || differences.All(x => x < 0 && x > -4);
            return isSafe;
        }
    }
}
