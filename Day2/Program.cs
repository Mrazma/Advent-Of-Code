using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");
            int[,] converted = new int[lines.Length,2];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] splited = lines[i].Split(" ");

                converted[i, 0] = convert(splited[0]);
                converted[i, 1] = convert(splited[1]);
            }

            Console.WriteLine(scorecount(converted, 0)); // Part one

            converted = elfhelp(converted);
            Console.WriteLine(scorecount(converted, 0)); // Part Two
        }
        public static int convert(string txt)
        {
            switch (txt)
            {
                case "A":
                case "X":
                    return 1;
                case "B":
                case "Y":
                    return 2;
                case "C":
                case "Z":
                    return 3;
            }
            return 0;
        }
        public static int overflow(int a)
        {
            if (a == 0)
                return 3;
            else if (a == 4)
                return 1;
            else
                return a;
        }
        public static int scorecount(int[,] ints, int score)
        {
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                score += ints[i, 1];

                if (ints[i, 0] == ints[i, 1])
                    score += 3;
                else if (ints[i, 0] == overflow(ints[i, 1] - 1))
                    score += 6;
                else if (ints[i, 0] == overflow(ints[i, 1] + 1))
                    score += 0;
            }
            return score;
        }
        public static int[,] elfhelp(int[,] ints)
        {
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                if (ints[i, 1] == 1)
                    ints[i, 1] = overflow(ints[i, 0] - 1);
                else if (ints[i, 1] == 2)
                    ints[i, 1] = ints[i, 0];
                else if (ints[i, 1] == 3)
                    ints[i, 1] = overflow(ints[i, 0] + 1);
            }
            return ints;
        }
        //Git Test2
    }
}