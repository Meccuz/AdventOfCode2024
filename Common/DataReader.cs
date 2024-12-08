namespace AdventOfCode2024.Common
{
    public static class DataReader
    {
        public static string[] ReadInputData(string day, bool isSample = false, bool isPart2 = false)
        {
            return File.ReadAllLines($"../../../Day{day}/input" +
                $"{(isPart2 ? "_2" : "")}" +
                $"{(isSample ? "_sample" : "")}.txt");
        }
    }
}
