using System.Runtime.ExceptionServices;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../List.txt";
            /*string[,] data = loaddata(path);
            char[] pismenka = CharList(data);
            Console.WriteLine(CharToInt(pismenka));*/
            string[,] data = NormalLoad(path);
            char[] pismenka = CommonThree(data);
            Console.WriteLine(CharToInt(pismenka));
        }
        public static string[,] loaddata(string path)
        {
            string[] countOfLines = File.ReadAllLines(path);

            string[,] pole = new string[countOfLines.Length, 2];

            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; i < countOfLines.Length; i++)
                {
                    string[] radek = splitstring(sr.ReadLine());
                    pole[i, 0] = radek[0];
                    pole[i, 1] = radek[1];
                }
            }
            return pole;
        }
        public static string[] splitstring(string txt)
        {
            string[] radek = new string[2];

            for(int i = 0; i < txt.Length; i++)
            {
                if (i < txt.Length / 2)
                {
                    radek[0] = radek[0] + txt[i];
                } 
                else
                {
                    radek[1] = radek[1] + txt[i];
                }
            }
            return radek;
        }
        public static char CharBoth(string one, string two)
        {
            char x;
            for(int i = 0; i < one.Length; i++)
            {
                for (int j = 0; j < two.Length; j++)
                {
                    if (one[i] == two[j])
                    {
                        x = two[j];
                        return x;
                    }
                }
            }
            Console.WriteLine("Error");
            return ' ';
        }
        public static char[] CharList(string[,] pole)
        {
            char[] charlist = new char[pole.GetLength(0)];
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                charlist[i] = CharBoth(pole[i, 0], pole[i, 1]);
            }
            return charlist;
        }
        public static int CharToInt(char[] pismenka)
        {
            int sum = 0;
            
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i = 0; i < pismenka.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j] == pismenka[i])
                    {
                        sum += j+1;
                    }
                }
            }
            return sum;
        }
        public static string[,] NormalLoad(string path)
        {
            string[] Lines = File.ReadAllLines(path);
            string[,] tripple = new string[Lines.Length / 3, 3];

            for (int i = 0; i < Lines.Length/3; i ++)
            {
                tripple[i,0] = Lines[(i*3)];
                tripple[i,1] = Lines[(i*3)+1];
                tripple[i,2] = Lines[(i*3)+2];
            }
            return tripple;
        }
        public static char[] CommonThree(string[,] Oddily)
        {
            char[] pismenka = new char[Oddily.GetLength(0)];
            for (int i = 0; i < Oddily.GetLength(0); i++)
            {
                pismenka[i] = TrojPismenko(Oddily[i, 0], Oddily[i, 1], Oddily[i, 2]);
            }
            return pismenka;
        }
        public static char TrojPismenko(string one, string two, string three)
        {
            string codvaob = "";
            for (int i = 0; i < one.Length; i++)
            {
                for (int j = 0; j < two.Length; j++)
                {
                    if (one[i] == two[j])
                    {
                        codvaob = codvaob + two[j];
                    }
                }
            }
            return CharBoth(codvaob, three);
        }
    }
}