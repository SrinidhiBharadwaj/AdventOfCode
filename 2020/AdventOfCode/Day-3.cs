using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day3
    {
        private  List<string> treeLine = new List<string>();
        public Day3()
        {
            using (var file = new StreamReader("C:\\Users\\sks\\Desktop\\AoC\\Day-3.txt"))
            {
                var line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    treeLine.Add(line);
                }
            }
        }

        public long findNumTrees(int right, int down)
        {
            long totalNumTrees = 0;
            int downIndex = 0;
            int carriageRetIdx = 0;

            while (downIndex < treeLine.Count - 1)
            {
                downIndex += down;
                carriageRetIdx = (carriageRetIdx + right) % treeLine[downIndex - 1].Length;
                string tree = treeLine[downIndex];
                if (tree[carriageRetIdx] == '#')
                {
                    totalNumTrees++;
                }

            }
            return totalNumTrees;
        }
    }

  
}
