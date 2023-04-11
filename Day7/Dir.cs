using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Dir
    {
        public string Name { get; set; }
        public List<Dir> Dirs { get; set; }
        public List<File> Files { get; set; }
        public Dir LookingAt { get; set; }
        public bool Active { get; set; }

        public Dir(string name, bool active)     
        {
            Name = name;
            Dirs = new List<Dir>();
            Files = new List<File>();
            LookingAt = null;
            Active = active;
        }
        public int CountSize()
        {
            int count = 0;

            foreach(File f in Files)
            {
                count += f.Size;
            }
            foreach(Dir d in Dirs)
            {
                count += d.CountSize();
            }
            return count;
        }        
        public void AddDir(string name)
        {
            Dir d = new Dir(name, true);

            if(Active)
            {
                Dirs.Add(d);
                LookingAt = Dirs.Last();
                Active = false;
            }
            else
            {
                LookingAt.AddDir(name);
            }
        }
        public bool BackDir()
        {
            if (Active)
            {
                Active = false;
                LookingAt = null;
                return true;
            } 
            else if(LookingAt.BackDir())
            {
                Active=true;
                LookingAt = null;
            }
            return false;
        }
        public void AddFile(string name, int size)
        {
            if (Active)
            {
                Files.Add(new File(name, size));
            }
            else
            {
                LookingAt.AddFile(name, size);
            }
        }
        public int PartI()
        {
            int c = 0;
            foreach(Dir d in Dirs)
            {
                if (d.CountSize() < 100000)
                {
                    c += d.CountSize();
                }
                c += d.PartI();
            } 
            return c;
        }
        public List<Dir> PartII(int neededspace)
        {
            List<Dir> candidates = new List<Dir>();

            foreach (Dir d in Dirs)
            {
                if (d.CountSize() > neededspace)
                {
                    candidates.Add(d);
                }
                candidates.AddRange(d.PartII(neededspace));
            }
            return candidates;
        }
    }
}
