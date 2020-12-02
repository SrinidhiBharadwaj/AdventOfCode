using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class ReportRepair
    {

        private static List<int> yearList = new List<int>();
        private static List<string> passwordsList = new List<string>();
        static void Main(string[] args)
        {
            using (var file = new StreamReader("C:\\Users\\sks\\Downloads\\AoC-Pob1.txt"))
            {
                var line = string.Empty;

                while ((line = file.ReadLine()) != null)
                {
                    //passwordsList.Add(line);
                    yearList.Add(Convert.ToInt32(line));
                }
            }
            int product = findProductof2020();
           // int product = findTotalRightPasswords();
        }

        private static int findProductof2020()
        {
            int product = 0;
            int refYear = 2020;

            /* First part of question 1 */
            //foreach(int year in yearList)
            //{
            //    int numtoSearch = refYear - year;
            //    if(yearList.Any(x => x == numtoSearch))
            //    {
            //        product = yearList.FirstOrDefault(x => x == numtoSearch) * year;
            //        break;
            //    }
            //}

            /* Second part of question 1 */
            for (int i = 0;  i < yearList.Count; i++)
            {
                int secondRef = yearList[i];
                for(int j = i + 1; j < yearList.Count - i - 1; j++)
                {
                    int numToSearch = refYear - secondRef - yearList[j];
                    if (yearList.Any(x => x == numToSearch))
                    {
                        product = numToSearch * secondRef * yearList[j];
                        break;
                    }
                }
            }



            return product;
        }
        private static int findTotalRightPasswords()
        {
            int totalCorrectPasswords = 0;
            foreach (string password in passwordsList)
            {
                string minMax = password.Split(' ')[0];
                int minOccurrence = Int32.Parse(minMax.Split('-')[0]);
                int maxOccurrence = Int32.Parse(minMax.Split('-')[1]);
                
                char refLetter = (password.Split(' ')[1])[0];
                string pass = password.Split(':')[1].Replace(" ", "");
                
                /* Second part of question 2 */
                if (pass.Length >= maxOccurrence)
                {
                    if (pass[minOccurrence - 1] == refLetter ^ pass[maxOccurrence - 1] == refLetter)
                    {
                        totalCorrectPasswords++;
                    }
                }

                /* First part of question 2 */
                //foreach (char letter in pass)
                //{
                //    if (letter == refLetter)
                //    {
                //        count++;
                //    }
                //}
                //if (count >= minOccurrence && count <= maxOccurrence)
                //{
                //    totalCorrectPasswords++;
                //}

            }

            return totalCorrectPasswords;
        }
    }
}
