using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../List.txt";
            string[,] pole = Loaddata(path);
            //string[,] pole = { { "A", "Y" },{ "B", "X" },{ "C", "Z" } };
            int[,] ints = convertToInt(pole);
                      
            ints = Elfhelp(ints);

            int score = KNPusage(ints);
            score = WinScore(ints, score);
            
            Console.WriteLine(score);
        }
        public static string[,] Loaddata(string path)
        {
            string[] countOfLines = File.ReadAllLines(path);

            string[,] pole = new string[countOfLines.Length,2];

            using(StreamReader sr = new StreamReader(path))
            {
                for(int i = 0; i < countOfLines.Length; i++)
                {
                    string[] line = sr.ReadLine().Split(" ");
                    pole[i,0] = line[0];
                    pole[i,1] = line[1];    
                }
            }
            return pole;
        }
        public static int[,] convertToInt(string[,] pole)
        {
            int[,] ints = new int[pole.GetLength(0), 2];

            for (int i = 0; i < pole.GetLength(0); i++)
            {
                switch (pole[i, 0])
                {
                    case "A":
                        ints[i, 0] = 1;
                        break;
                    case "B":
                        ints[i, 0] = 2;
                        break;
                    case "C":
                        ints[i, 0] = 3;
                        break;
                }
                switch (pole[i, 1])
                {
                    case "X":
                        ints[i, 1] = 1;
                        break;
                    case "Y":
                        ints[i, 1] = 2;
                        break;
                    case "Z":
                        ints[i, 1] = 3;
                        break;
                }
            }
            return ints;    
        }
        public static int KNPusage(int[,] pole)
        {
            int score = 0;
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                score += pole[i, 1];
            }
            return score;
        }
        public static int WinScore(int[,] pole, int score)
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                if (pole[i, 0] == 3 && pole[i, 1] == 1)
                {
                    score += 6;
                }
                else if (pole[i, 0] == 1 && pole[i, 1] == 3)
                {
                    //0
                }
                else if (pole[i, 0] == pole[i, 1])
                {
                    score += 3;
                }
                else if (pole[i, 1] == pole[i, 0] - 1) 
                {
                    //0
                }
                else if (pole[i, 1] == pole[i, 0] + 1) 
                {
                    score += 6;
                }
            }
            return score;
        }
        public static int[,] Elfhelp(int[,] pole)
        {
            for(int i = 0; i < pole.GetLength(0); i++)
            {
                if (pole[i,1] == 2)
                {
                    pole[i,1] = pole[i,0];
                } 
                else if (pole[i, 1] == 1)
                {
                    pole[i, 1] = Bounds(pole[i, 0] - 1);
                }
                else if (pole[i, 1] == 3)
                {
                    pole[i, 1] = Bounds(pole[i, 0] + 1);
                }
            }
            return pole;
        }
        public static int Bounds(int input)
        {
            if(input == 0)
            {
                return 3;
            }
            else if (input > 3)
            {
                return 1;
            }
            else
            {
                return input;
            }
            
        }
    }
}