using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day2
    {
        private List<string> passwordsList = new List<string>();
        public Day2()
        {

            using (var file = new StreamReader("C:\\Users\\sks\\Desktop\\AoC\\Day-2.txt"))
            {
                var line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    passwordsList.Add(line);
                }
            }
        }
        public  int findTotalRightPasswords(bool firstPart)
        {
            int totalCorrectPasswords = 0, count = 0;
            foreach (string password in passwordsList)
            {
                string minMax = password.Split(' ')[0];
                int minOccurrence = Int32.Parse(minMax.Split('-')[0]);
                int maxOccurrence = Int32.Parse(minMax.Split('-')[1]);

                char refLetter = (password.Split(' ')[1])[0];
                string pass = password.Split(':')[1].Replace(" ", "");

                if (!firstPart)
                {
                    /* Second part of question 2 */
                    if (pass.Length >= maxOccurrence)
                    {
                        if (pass[minOccurrence - 1] == refLetter ^ pass[maxOccurrence - 1] == refLetter)
                        {
                            totalCorrectPasswords++;
                        }
                    }
                }

                else
                {
                    count = 0;
                    /* First part of question 2 */
                    foreach (char letter in pass)
                    {
                        if (letter == refLetter)
                        {
                            count++;
                        }
                    }
                    if (count >= minOccurrence && count <= maxOccurrence)
                    {
                        totalCorrectPasswords++;
                    }
                }


            }

            return totalCorrectPasswords;
        }
    }
}
