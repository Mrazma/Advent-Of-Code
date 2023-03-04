using System.Linq;
using System.Runtime.InteropServices;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");

            // Part I
            char[] chars = new char[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string one = lines[i].Substring(0, lines[i].Length/2);
                string two = lines[i].Substring(lines[i].Length/2);

                chars[i] = Convert.ToChar(String.Join(" ", one.Intersect(two)));
            }
            Console.WriteLine(weightcount(chars));

            // Part II
            char[] chars2 = new char[lines.Length / 3];

            for (int i = 0; i < lines.Length-2; i += 3)
            {
                chars2[i / 3] = Convert.ToChar(String.Join(" ", lines[i].Intersect(lines[i + 1].Intersect(lines[i + 2]))));
            }
            Console.WriteLine(weightcount(chars2));
        }
        public static int weightcount(char[] chars)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int num = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (chars[i] == alphabet[j])
                        num += j+1;
                } 
            }
            return num;
        }
    }
}