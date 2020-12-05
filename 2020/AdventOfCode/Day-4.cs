using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day4
    {
        List<string> validKeyWords = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        List<string> passPortInputs = new List<string>();
        List<List<string>> passIp = new List<List<string>>();
        Dictionary<string, string> passPortDetails = new Dictionary<string, string>();
        List<Dictionary<string, string>> passportDetailsList = new List<Dictionary<string, string>>();
        public Day4()
        {
            using (var file = new StreamReader("C:\\Users\\sks\\Desktop\\AoC\\Day-4.txt"))
            {
                var line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        passIp.Add(new List<string>(passPortInputs));
                        passPortInputs.Clear();
                    }
                    else
                    {
                        passPortInputs.Add(line);
                    }
                }
            }

            makeInputs();
        }

        public int findTotalValidPassports(bool firstPart)
        {
            int numValidPassports = 0;
            int numOfPassportsWithValidData = 0;
            List<string> eyeColor = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            foreach (Dictionary<string, string> keyValPair in passportDetailsList)
            {
                bool bPassPortValid = false, bDataValid = true;
                foreach (string s in validKeyWords)
                {
                    if (keyValPair.ContainsKey(s))
                        bPassPortValid = true;
                    else
                    {
                        bPassPortValid = false;
                        break;
                    }
                }
                if (bPassPortValid)
                {
                   
                    bDataValid &= isValid(int.Parse(keyValPair["byr"]), 1920, 2002);
                    bDataValid &= isValid(int.Parse(keyValPair["iyr"]), 2010, 2020);
                    bDataValid &= isValid(int.Parse(keyValPair["eyr"]), 2020, 2030);
                    
                    if (!eyeColor.Contains(keyValPair["ecl"])) bDataValid &= false;
                    if (keyValPair["pid"].Length != 9) bDataValid &= false;
                    if (keyValPair["hgt"].Contains("cm"))
                    {
                        bDataValid &= isValid(int.Parse(keyValPair["hgt"].Split('c')[0]), 150, 193);
                    }
                    else /* If height is measured in inches */
                    {
                        bDataValid &= isValid(int.Parse(keyValPair["hgt"].Split('i')[0]), 59, 76);
                    }
                    if(keyValPair["hcl"].Contains('#'))
                    {
                        if (keyValPair["hcl"].Split('#')[1].Length != 6) bDataValid &= false;
                    }
                    else
                    {
                        bDataValid &= false;
                    }
                    if (bDataValid) numOfPassportsWithValidData++;
                }
                if (bPassPortValid) numValidPassports++;
            }

            /* Return values based on the section of the question */
            if (firstPart) return numValidPassports;

            return numOfPassportsWithValidData;
        }

        private bool isValid(int val, int lowerBound, int upperBound)
        {
            if (!(val >= lowerBound && val <= upperBound))
                return false;
            return true;
        }

        private void makeInputs()
        {
            foreach(List<string> passPort in passIp)
            {
                passPortDetails.Clear();
                foreach (string passPortFields in passPort)
                {
                    if(passPortFields.Contains(" "))
                    {
                        string[] fields = passPortFields.Split(null);
                        foreach(string s in fields)
                        {
                            passPortDetails.Add(s.Split(':')[0], s.Split(':')[1]);
                        }
                    }
                    else
                    {
                        passPortDetails.Add(passPortFields.Split(':')[0], passPortFields.Split(':')[1]);
                    }
                   
                }
                passportDetailsList.Add(new Dictionary<string, string>(passPortDetails));
            }
        }
    }
}
