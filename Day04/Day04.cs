using AdventOfCode2024.Common;

namespace AdventOfCode2024
{
    public static class Day04
    {
        private const string XMAS = "XMAS";
        private static int totCols;
        private static int totRows;

        public static void Solve()
        {
            var lines = DataReader.ReadInputData("04", false);
            totCols = lines[0].Length;
            totRows = lines.Length;
            Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            var res = 0;

            for (int row = 1; row < totRows - 1; row++)
            {
                for (int col = 1; col < totCols - 1; col++)
                {
                    if (lines[row][col] == 'A')
                    {
                        var tl = lines[row - 1][col - 1];
                        var tr = lines[row - 1][col + 1];
                        var dl = lines[row + 1][col - 1];
                        var dr = lines[row + 1][col + 1];
                        var d1 = (tl == 'M' && dr == 'S') || (tl == 'S' && dr == 'M');
                        var d2 = (tr == 'M' && dl == 'S') || (tr == 'S' && dl == 'M');
                        if (d1 && d2) res++;
                    }
                }
            }

            Console.WriteLine($"Part 2: {res}");
        }

        private static void Part1(string[] lines)
        {
            var res = 0;
            for (int row = 0; row < totRows; row++)
            {
                for (int col = 0; col < totCols; col++)
                {
                    if (lines[row][col] == 'X')
                    {
                        res += FindXMAS(lines, row - 1, col, 1, "U");
                        res += FindXMAS(lines, row - 1, col + 1, 1, "UR");
                        res += FindXMAS(lines, row, col + 1, 1, "R");
                        res += FindXMAS(lines, row + 1, col + 1, 1, "DR");
                        res += FindXMAS(lines, row + 1, col, 1, "D");
                        res += FindXMAS(lines, row + 1, col - 1, 1, "DL");
                        res += FindXMAS(lines, row, col - 1, 1, "L");
                        res += FindXMAS(lines, row - 1, col - 1, 1, "UL");
                    }
                }
            }

            Console.WriteLine($"Part 1: {res}");
        }

        private static int FindXMAS(string[] lines, int row, int col, int xmasIdx, string dir)
        {
            if (xmasIdx == XMAS.Length) { return 1; }
            if (row < 0 || row >= totRows || col < 0 || col >= totCols) { return 0; }
            if (lines[row][col] == XMAS[xmasIdx])
            {
                switch (dir)
                {
                    case "U": return FindXMAS(lines, row - 1, col, xmasIdx + 1, "U");
                    case "UR": return FindXMAS(lines, row - 1, col + 1, xmasIdx + 1, "UR");
                    case "R": return FindXMAS(lines, row, col + 1, xmasIdx + 1, "R");
                    case "DR": return FindXMAS(lines, row + 1, col + 1, xmasIdx + 1, "DR");
                    case "D": return FindXMAS(lines, row + 1, col, xmasIdx + 1, "D");
                    case "DL": return FindXMAS(lines, row + 1, col - 1, xmasIdx + 1, "DL");
                    case "L": return FindXMAS(lines, row, col - 1, xmasIdx + 1, "L");
                    case "UL": return FindXMAS(lines, row - 1, col - 1, xmasIdx + 1, "UL");
                }
            }
            return 0;
        }
    }
}
