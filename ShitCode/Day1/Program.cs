using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../List.txt";

            int[,] elfList = Loaddata(path);
            int[] sums = getmaxsums(elfList);
            Array.Sort(sums);
            Array.Reverse(sums);

            Console.WriteLine(sums[0]+ sums[1] + sums[2]);
        }
        public static int[,] Loaddata(string path)
        {
            string[] countOfLines = File.ReadAllLines(path);
            int NumOfElfs = 0;
            int MaxPocket = 0;
            int PocketLast = 0;

            using (StreamReader sr = new StreamReader(path))
            {                
                for (int i = 0; i < countOfLines.Length; i++)
                {
                    try
                    {
                        int tmp = Convert.ToInt32(sr.ReadLine());
                        PocketLast++;
                    } 
                    catch
                    {
                        NumOfElfs++;
                        if(PocketLast>MaxPocket)
                            MaxPocket=PocketLast;
                    }
                }
            }
            int[,] ElfsList = new int[NumOfElfs, MaxPocket]; 
            using (StreamReader sr = new StreamReader(path))
            {
                int currentElf = 0;
                int currentPocketPos = 0;
                for (int i = 0; i < countOfLines.Length; i++)
                {
                    try
                    {
                        ElfsList[currentElf, currentPocketPos] = Convert.ToInt32(sr.ReadLine());
                        currentPocketPos++;
                    }
                    catch
                    {
                        currentElf++;
                        currentPocketPos = 0;
                    }
                }
            }
            return ElfsList;
        }
        public static int[] getmaxsums(int[,] pole)
        {
            int[] sums = new int[pole.GetLength(0)];

            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    sums[i] += pole[i, j];
                }                
            }
            return sums;
        }
        public static void WriteList2D(int[,] pole)
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    Console.Write(pole[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}