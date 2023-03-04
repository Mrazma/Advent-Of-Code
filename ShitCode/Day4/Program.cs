namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../List.txt";
            int[,] Pole = LoadData(path);
            Console.WriteLine(TrueCount(Pole));
        }
        public static int[,] LoadData(string path)
        {
            string[] Lines = File.ReadAllLines(path);

            int[,] Pole = new int[Lines.Length, 4];

            for (int i = 0; i < Lines.Length; i++)
            {
                string[] tmp1 = Lines[i].Split(",");
                string[] tmp2 = tmp1[0].Split("-");
                string[] tmp3 = tmp1[1].Split("-");

                Pole[i, 0] = Convert.ToInt32(tmp2[0]);
                Pole[i, 1] = Convert.ToInt32(tmp2[1]);
                Pole[i, 2] = Convert.ToInt32(tmp3[0]);
                Pole[i, 3] = Convert.ToInt32(tmp3[1]);
            }    
            return Pole;
        }
        public static int OverlapCount(int[,] pole)
        {
            int count = 0;
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                if (Overlap(pole[i,0], pole[i, 1], pole[i, 2], pole[i, 3]))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool Overlap(int x, int y, int a, int b)
        {
            if((x>=a && x<=b && y>=a && y<=b) || (a>=x && a<=y && b>=x && b<=y))
                return true;
            else 
                return false;
        }
        public static bool EasyOverlap(int x,int y, int a, int b, int j, int k, int o, int p)
        {
            bool sx = (x >= j && x <= k) || (x >= o && x <= p);
            bool sa = (a >= j && a <= k) || (a >= o && a <= p);
            bool sj = (j >= a && j <= b) || (j >= x && j <= y);
            bool so = (o >= a && o <= b) || (j >= x && j <= y);

            if ((sx || sa) || (sj || so))
                return true;
            else
                return false;
        }
        public static int DoubleCount(int[,] pole)
        {
            int count = 0;
            for (int i = 0; i < pole.GetLength(0)-1; i+=2)
            {
                if (EasyOverlap(pole[i, 0], pole[i, 1], pole[i, 2], pole[i, 3], pole[i+1, 0], pole[i+1, 1], pole[i+1, 2], pole[i+1, 3]))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool EasyOverlap2(int x, int y, int a, int b)
        {
            if ((x>= a && x<=b)||(a>=x&&a<=y))
                return true;
            else
                return false;
        }
        public static int TrueCount(int[,] pole)
        {
            int count = 0;
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                if (EasyOverlap2(pole[i, 0], pole[i, 1], pole[i, 2], pole[i, 3]))
                {
                    count++;
                }
            }
            return count;
        }

    }
}