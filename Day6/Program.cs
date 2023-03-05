namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText("../../../input.txt");


            for (int i = 4; i < line.Length; i++) // Part I
            {
                string current4 = line.Substring(i - 4, 4);

                if (current4.Length == current4.Distinct().Count())
                {
                    Console.WriteLine(i);
                    break;
                }
            }

            for (int i = 14; i < line.Length; i++) // Part II
            {
                string current14 = line.Substring(i-14, 14);

                if (current14.Length == current14.Distinct().Count())
                {
                    Console.WriteLine(i);
                    break;
                }
            }

        }
    }
}