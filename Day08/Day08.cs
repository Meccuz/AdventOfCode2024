using AdventOfCode2024.Common;

namespace AdventOfCode2024
{
    public static class Day08
    {
        private static string[] lines;

        public static void Solve()
        {
            lines = DataReader.ReadInputData("08", false);
            Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            HashSet<(char type, int row, int col)> antennas = new();
            for (var row = 0; row < lines.Length; row++)
            {
                for (var col = 0; col < lines[row].Length; col++)
                {
                    if (lines[row][col] != '.') antennas.Add((lines[row][col], row, col));
                }
            }
            HashSet<(int row, int col)> antinodes = new();

            foreach (var antenna1 in antennas)
            {
                foreach (var antenna2 in antennas.Where(x => x != antenna1 && x.type == antenna1.type))
                {
                    antinodes.Add((antenna1.row, antenna1.col));
                    antinodes.Add((antenna2.row, antenna2.col));
                    var distX = antenna1.col - antenna2.col;
                    var distY = antenna1.row - antenna2.row;
                    (int row, int col) antinode1 = (antenna1.row + distY, antenna1.col + distX);
                    (int row, int col) antinode2 = (antenna2.row - distY, antenna2.col - distX);
                    while (IsValidPosition(antinode1))
                    {
                        antinodes.Add(antinode1);
                        antinode1 = (antinode1.row + distY, antinode1.col + distX);
                    }
                    while (IsValidPosition(antinode2))
                    {
                        antinodes.Add(antinode2);
                        antinode2 = (antinode2.row - distY, antinode2.col - distX);
                    }
                }
            }

            Console.WriteLine($"Part 2: {antinodes.Count}");
        }

        private static void Part1(string[] lines)
        {
            HashSet<(char type, int row, int col)> antennas = new();
            for (var row = 0; row < lines.Length; row++)
            {
                for (var col = 0; col < lines[row].Length; col++)
                {
                    if (lines[row][col] != '.') antennas.Add((lines[row][col], row, col));
                }
            }
            HashSet<(int row, int col)> antinodes = new();
            foreach (var antenna1 in antennas)
            {
                foreach (var antenna2 in antennas.Where(x => x != antenna1 && x.type == antenna1.type))
                {
                    var distX = antenna1.col - antenna2.col;
                    var distY = antenna1.row - antenna2.row;
                    var antinode1 = (antenna1.row + distY, antenna1.col + distX);
                    var antinode2 = (antenna2.row - distY, antenna2.col - distX);
                    if (IsValidPosition(antinode1)) antinodes.Add(antinode1);
                    if (IsValidPosition(antinode2)) antinodes.Add(antinode2);
                }
            }

            Console.WriteLine($"Part 1: {antinodes.Count}");
        }

        private static bool IsValidPosition((int row, int col) antinode)
        {
            return antinode.row >= 0 && antinode.col >= 0 && antinode.row < lines.Length && antinode.col < lines[0].Length;
        }
    }
}