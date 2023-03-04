namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");

            List<int> sums = new List<int>() {0};

            int currentelf = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    sums[currentelf] += Convert.ToInt32(lines[i]);
                }
                else
                {
                    currentelf++;
                    sums.Add(0);
                }
            }
            sums.Sort();
            sums.Reverse();

            Console.WriteLine(sums[0]); //First answer
            Console.WriteLine(sums[0] + sums[1] + sums[2]); //Second Answer
        }
    }
}