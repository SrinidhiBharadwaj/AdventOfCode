using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day6
    {
        List<string> customsQuestions = new List<string>();
        List<List<string>> questionList = new List<List<string>>();
        
        public Day6()
        {
            using (var file = new StreamReader("C:\\Users\\sks\\Desktop\\AoC\\Day-6.txt"))
            {
                var line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        questionList.Add(new List<string>(customsQuestions));
                        customsQuestions.Clear();
                    }
                    else
                    {
                        customsQuestions.Add(line);
                    }
                }
            }
        }

        /* Code length can be reduced and made more efficient but leaving it as is for the time being */
        public int checkSumOfCounts(bool firstPart)
        {
            int sum = 0;
            List<char> encountered = new List<char>();

            if(firstPart)
            {
                foreach (List<string> inputs in questionList)
                {
                    encountered.Clear();
                    foreach (string ans in inputs)
                    {
                        foreach (char question in ans)
                        {
                            if (!encountered.Contains(question))
                                encountered.Add(question);
                        }
                    }
                    sum += encountered.Count;
                }
            }
            else
            {
                foreach (List<string> inputs in questionList)
                {
                    encountered.Clear();
                    foreach (string ans in inputs)
                    {
                        foreach (char question in ans)
                        {
                            encountered.Add(question);
                        }
                    }
                    int count = getCount(encountered, inputs.Count);
                    sum += count;
                }
            }
         

            return sum;
        }
        private int getCount(List<char> encounteredChars, int refCount)
        {
            int count = 0;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            List<int> countList = new List<int>();
            foreach(char c in alphabet)
            {
                countList.Add(encounteredChars.Count(x => x == c));
            }
            
            count = countList.Count(x => x == refCount);
            return count;
        }
    }

}
