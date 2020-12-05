using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day5
    {
        List<string> seatList = new List<string>();
        List<int> seatId = new List<int>();
        public Day5()
        {
            using (var file = new StreamReader("C:\\Users\\sks\\Desktop\\AoC\\Day-5.txt"))
            {
                var line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    seatList.Add(line);
                }
            }
            int highestID = checkHighestID();
        }

        public int checkMySeat()
        {
            int seatNum = 0;

            for(int row = 1; row < 127; row++)
            {
                for(int col = 0; col < 8; col++)
                {
                    int temp = row * 8 + col;
                    if (!seatId.Contains(temp) && seatId.Contains(temp - 1) && seatId.Contains(temp + 1))
                    {
                        seatNum = row * 8 + col;
                    }
                }
            }

            return seatNum;
        }

        public int checkHighestID()
        {
            foreach(string seat in seatList)
            {
                string seatRow = seat.Substring(0, 7);
                string seatCol = seat.Substring(7);

                int row = calcRow(seatRow);
                int col = calcCol(seatCol);
                seatId.Add(row * 8 + col);
            }

            return seatId.Max();
        }
        private int calcRow(string row)
        {
            bool keepUpperHalf = false;
            int lowVal = 0, highVal = 127;
            for (int i = 0; i < row.Length; i++)
            {
                keepUpperHalf = row[i] == 'F' ? false : true;
                if (keepUpperHalf)
                {
                    lowVal = (lowVal + highVal + 1) / 2;
                }
                else
                    highVal = (lowVal + highVal + 1) / 2;

            }
            if (row[6] == 'B')
                return Math.Max(lowVal, highVal - 1);
            return Math.Min(lowVal, highVal - 1);
        }
        private int calcCol(string col)
        {
            bool keepUpperHalf = false;
            int lowVal = 0, highVal = 7;
            for (int i = 0; i < col.Length; i++)
            {
                keepUpperHalf = col[i] == 'L' ? false : true;
                if (keepUpperHalf)
                {
                    lowVal = (lowVal + highVal + 1) / 2;
                }
                else
                    highVal = (lowVal + highVal + 1) / 2;

            }
            if (col[2] == 'R')
                return Math.Max(lowVal, highVal - 1);
            return Math.Min(lowVal, highVal - 1); ;
        }
    }
}
