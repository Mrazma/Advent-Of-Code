using System.Text.RegularExpressions;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");

            List<int[]> ranges = new List<int[]>();

            for (int i = 0; i < lines.Length; i++)
            {
                Regex regex = new Regex("\\D+");
                int[] intArray = Array.ConvertAll(regex.Split(lines[i]), int.Parse);

                ranges.Add(intArray);
            }
            // Part I
            int numofoverlaps = 0;
            for (int i = 0; i < ranges.Count; i++)
            {
                if ((ranges[i][0] >= ranges[i][2] && ranges[i][1] <= ranges[i][3]) || (ranges[i][2] >= ranges[i][0] && ranges[i][3] <= ranges[i][1]))
                    numofoverlaps++;
            }
            Console.WriteLine(numofoverlaps);
            // Part II
            int numofoverlaps2 = 0;
            for (int i = 0; i < ranges.Count; i++)
            {
                if ((ranges[i][0] >= ranges[i][2] && ranges[i][0] <= ranges[i][3]) || (ranges[i][2] >= ranges[i][0] && ranges[i][2] <= ranges[i][1]))
                    numofoverlaps2++;
            }
            Console.WriteLine(numofoverlaps2);
        }
    }
}