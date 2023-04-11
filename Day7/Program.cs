namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("../../../input.txt");

            Dir Root = new Dir("Root",true);
            
            //Load//
            foreach (string line in lines)
            {
                if (line.Contains('$') && line.Contains("cd"))
                {
                    string name = line.Split(" ")[2];
                    if (name == "") continue;

                    if (name == "..")
                    {
                        Root.BackDir();
                    }
                    else
                    {
                        Root.AddDir(name);
                    }
                }
                else if (!(line.Contains('$')) && !(line.Contains("dir")))
                {
                    string[] data = line.Split(" ");
                    Root.AddFile(data[1], Convert.ToInt32(data[0]));
                }
            }
            Console.WriteLine(Root.PartI()); // Part1

            //Part2
            int neededspace = Math.Abs(70000000 - 30000000 - Root.CountSize());
            List<Dir> candidates = Root.PartII(neededspace);
            int winnersize = int.MaxValue;
            
            foreach(Dir d in candidates)
            {
                if(d.CountSize()< winnersize)
                {
                    winnersize = d.CountSize();
                }
            }
            Console.WriteLine(winnersize);

        }
    }
}