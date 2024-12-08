using AdventOfCode2024.Common;
using System.Text;

namespace AdventOfCode2024
{
    public static class Day06
    {
        public static void Solve()
        {
            var lines = DataReader.ReadInputData("06", false);
            // Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            var currentPos = FindStartingPos(lines);
            var res = 0;
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    if (lines[row][col] == '.')
                    {
                        res += CheckLoop(lines, currentPos, (row, col));
                    }
                }
            }

            Console.WriteLine($"Part 2: {res}");
        }

        private static int CheckLoop(string[] lines, (int row, int col) currentPos, (int row, int col) newObstacle)
        {
            string[] lines2 = new string[lines.Length];
            Array.Copy(lines, lines2, lines.Length);

            StringBuilder sb1 = new StringBuilder(lines2[newObstacle.row]);
            sb1[newObstacle.col] = '#';
            lines2[newObstacle.row] = sb1.ToString();
            var dir = lines[currentPos.row][currentPos.col];
            var visited = new HashSet<(int, int, char)>() { (currentPos.row, currentPos.col, dir) };
            try
            {
                while (true)
                {
                    currentPos = Move(ref lines2, currentPos);
                    dir = lines2[currentPos.row][currentPos.col];
                    if (visited.Contains((currentPos.row, currentPos.col, dir))) return 1;
                    visited.Add((currentPos.row, currentPos.col, dir));
                }
            }
            catch
            {
                return 0;
            }
        }

        private static void Part1(string[] lines)
        {
            var visited = new HashSet<(int, int)>();
            var currentPos = FindStartingPos(lines);
            visited.Add(currentPos);
            try
            {
                while (true)
                {
                    currentPos = Move(ref lines, currentPos);
                    visited.Add(currentPos);
                }
            }
            catch
            {
                Console.WriteLine($"Part 1: {visited.Count}");
            }
        }

        private static (int, int) Move(ref string[] lines, (int row, int col) currentPos)
        {
            var dir = lines[currentPos.row][currentPos.col];
            (int row, int col) nextPos = dir switch
            {
                '^' => (currentPos.row - 1, currentPos.col),
                '>' => (currentPos.row, currentPos.col + 1),
                'v' => (currentPos.row + 1, currentPos.col),
                '<' => (currentPos.row, currentPos.col - 1),
                _ => throw new Exception(),
            };
            if (lines[nextPos.row][nextPos.col] == '#')
            {
                StringBuilder sb1 = new StringBuilder(lines[currentPos.row]);
                sb1[currentPos.col] = dir switch
                {
                    '^' => '>',
                    '>' => 'v',
                    'v' => '<',
                    '<' => '^',
                    _ => throw new Exception(),
                };
                lines[currentPos.row] = sb1.ToString();

                return (currentPos.row, currentPos.col);
            }
            StringBuilder sb2 = new StringBuilder(lines[nextPos.row]);
            sb2[nextPos.col] = dir;
            lines[nextPos.row] = sb2.ToString();

            return nextPos;
        }

        private static (int, int) FindStartingPos(string[] lines)
        {
            for (int row = 0; row < lines.Length; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    if (new[] { 'v', '^', '<', '>' }.Contains(lines[row][col]))
                    {
                        return (row, col);
                    }
                }
            }
            throw new Exception();
        }
    }
}