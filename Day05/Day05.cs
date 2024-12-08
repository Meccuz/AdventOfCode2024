using AdventOfCode2024.Common;

namespace AdventOfCode2024
{
    public static class Day05
    {
        static Dictionary<int, HashSet<int>> rulesDict = new();

        public static void Solve()
        {
            var lines = DataReader.ReadInputData("05", false);
            Part1(lines);
            Part2(lines);
        }

        private static void Part2(string[] lines)
        {
            var updates = lines.Where(x => x.Contains(",")).ToList();

            var res = 0;
            foreach (var update in updates)
            {
                var updateParsed = update.Split(",").Select((x, i) => ((i, int.Parse(x)))).ToDictionary(k => k.Item1, v => v.Item2);
                var skip = true;
                for (var i = 0; i < updateParsed.Count - 1; i++)
                {
                    var num = updateParsed[i];
                    for (var j = i + 1; j < updateParsed.Count; j++)
                    {
                        var next = updateParsed[j];
                        if (rulesDict.ContainsKey(next) && rulesDict[next].Contains(num))
                        {
                            updateParsed[i] = next;
                            updateParsed[j] = num;
                            i = -1;
                            skip = false;
                            break;
                        }
                    }
                }
                if (skip) continue;
                res += updateParsed.Select(x => x.Value).ToList()[updateParsed.Count / 2];
            }
            Console.WriteLine($"Part 2: {res}");
        }

        private static void Part1(string[] lines)
        {
            var rules = lines.Where(x => x.Contains("|")).ToList();
            var updates = lines.Where(x => x.Contains(",")).ToList();

            foreach (var rule in rules)
            {
                var ruleSplit = rule.Split("|").Select(int.Parse).ToList();
                var before = ruleSplit[0];
                var after = ruleSplit[1];
                if (!rulesDict.TryAdd(before, [after]))
                {
                    rulesDict[before].Add(after);
                }
            }

            var res = 0;
            foreach (var update in updates)
            {
                var visited = new HashSet<int>();
                var skip = false;
                var updateParsed = update.Split(",").Select(int.Parse).ToList();
                foreach (var num in updateParsed)
                {
                    foreach (var v in visited)
                    {
                        if (rulesDict.ContainsKey(num) && rulesDict[num].Contains(v))
                        {
                            skip = true;
                            break;
                        }
                    }
                    visited.Add(num);
                    if (skip) break;
                }
                if (skip) continue;
                res += updateParsed[updateParsed.Count / 2];
            }
            Console.WriteLine($"Part 1: {res}");
        }
    }
}
