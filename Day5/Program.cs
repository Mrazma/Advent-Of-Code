using System.Text.RegularExpressions;
using System;
using System.Linq.Expressions;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");

            List<List<char>> crates = new List<List<char>>();

            int breakpoint = 0;

            for(int i = 0; i < lines.Length; i++) // Finds the space between crates and rearrengement procces
                if (lines[i] == "")
                    breakpoint = i;

            for (int i = 1; i < lines[breakpoint-1].Length; i +=4) //Puts Creates in lists
            {
                crates.Add(new List<char>());
                for (int j = breakpoint - 2; j >= 0; j--)
                {
                    string line = lines[j];
                    if (line[i] == ' ')
                        break;
                    crates[(i - 1) / 4].Add(line[i]);
                }
            }

            List<int[]> manual = new List<int[]>();

            for (int i = breakpoint+1; i < lines.Length; i++) //Seperates the numbers and puts them into the manual (rearrengement procces)
            {
                string[] numbrs = Regex.Split(lines[i], "\\D+");
                int[] intArray = { Convert.ToInt32(numbrs[1]), Convert.ToInt32(numbrs[2])-1, Convert.ToInt32(numbrs[3])-1 };

                manual.Add(intArray);
            }

            // Part I
            List<List<char>> crates1 = new List<List<char>>(); //Hard Copy
            foreach (var sublist in crates)
            {
                crates1.Add(new List<char>(sublist));
            }

            foreach (int[] intArray in manual) 
            {
                for (int i = 0; i < intArray[0]; i++)
                {
                    List<char> tmp = crates1[intArray[1]];
                    crates1[intArray[2]].Add(crates1[intArray[1]][tmp.Count-1]);
                    crates1[intArray[1]].RemoveAt(tmp.Count - 1);
                }               
            }

            foreach(List<char> l in crates1) 
            {
                Console.Write(l[l.Count-1]);
            } Console.WriteLine(); 

            // Part II
            foreach (int[] intArray in manual)
            {             
                crates[intArray[2]].AddRange(crates[intArray[1]].GetRange(crates[intArray[1]].Count - intArray[0], intArray[0]));
                crates[intArray[1]].RemoveRange(crates[intArray[1]].Count - intArray[0], intArray[0]);
            }

            foreach (List<char> l in crates)
            {
                Console.Write(l[l.Count - 1]);
            }
        }
        public static void VypisListLisu(List<List<char>> lists)
        {
            foreach(List<char> l in lists)
            {
                foreach(char c in l)
                {
                    Console.Write(c+"_");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------");
        }
    }
}