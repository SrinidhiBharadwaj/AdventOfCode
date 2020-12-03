using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day1
    {
        private static List<int> yearList = new List<int>();
        public Day1()
        {
            using (var file = new StreamReader("C:\\Users\\sks\\Desktop\\AoC\\Day-1.txt"))
            {
                var line = string.Empty;

                while ((line = file.ReadLine()) != null)
                {
                    yearList.Add(Convert.ToInt32(line));
                }
            }
        }

        public  int findProductof2020(bool firstPart)
        {
            int product = 0;
            int refYear = 2020;

            if(firstPart)
            {
                /* First part of question 1 */
                foreach (int year in yearList)
                {
                    int numtoSearch = refYear - year;
                    if (yearList.Any(x => x == numtoSearch))
                    {
                        product = numtoSearch * year;
                        break;
                    }
                }
            }

            else
            {
                /* Second part of question 1 */
                for (int i = 0; i < yearList.Count; i++)
                {
                    int secondRef = yearList[i];
                    for (int j = i + 1; j < yearList.Count - i - 1; j++)
                    {
                        int numToSearch = refYear - secondRef - yearList[j];
                        if (yearList.Any(x => x == numToSearch))
                        {
                            product = numToSearch * secondRef * yearList[j];
                            break;
                        }
                    }
                }
            }
            return product;
        }
    }
}
