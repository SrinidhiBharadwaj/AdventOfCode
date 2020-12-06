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

       
        
        static void Main(string[] args)
        {
            Day1 day1Instance = new Day1(); 
            Day2 day2Instance = new Day2();
            Day3 day3Instance = new Day3();
            Day4 day4Instance = new Day4();
            Day5 day5Instance = new Day5();
            Day6 day6Instance = new Day6();

            /********************** Day - 1 **********************/

            int productOfYears = 0;
            bool firstPart = true;
            /* Part 1 */
            productOfYears = day1Instance.findProductof2020(firstPart);

            /* Part 2 */
            firstPart = false;
            productOfYears = day1Instance.findProductof2020(firstPart);

            /* ------------------------------------------------------ */

            /********************** Day - 2 **********************/

            int totalNumPasswords = 0;
            firstPart = true;
            /* Part 1 */
            totalNumPasswords = day2Instance.findTotalRightPasswords(firstPart);

            /* Part 2 */
            firstPart = false;
            totalNumPasswords = day2Instance.findTotalRightPasswords(firstPart);

            /* ------------------------------------------------------ */

            /********************** Day-3 **********************/
            long numTrees = 0;

            /* Part-1 */
            numTrees = day3Instance.findNumTrees(3, 1);

            /* Part-2 */
            numTrees = day3Instance.findNumTrees(1, 1) * day3Instance.findNumTrees(3, 1) 
                            * day3Instance.findNumTrees(5, 1) * day3Instance.findNumTrees(7, 1) * day3Instance.findNumTrees(1, 2);

            /* ------------------------------------------------------ */

            /********************** Day-4 **********************/
            int numValidPassports = 0;
            int numOfDataValid = 0;
            
            /* Part-1 */
            firstPart = true;
            numValidPassports = day4Instance.findTotalValidPassports(firstPart);

            /* Part-2 */
            firstPart = false;
            numOfDataValid = day4Instance.findTotalValidPassports(firstPart);

            /* ------------------------------------------------------ */

            /********************** Day-5 **********************/
            int highestSeatId = 0;
            int mySeat = 0;

            /* Part-1 */
            highestSeatId = day5Instance.checkHighestID();

            /* Part-2 */
            mySeat = day5Instance.checkMySeat();

            /* ------------------------------------------------------ */

            /********************** Day-5 **********************/
            int numOfAnswered = 0;
            int numOfQuesAllAnswered = 0;

            /* Part-1 */
            firstPart = true;
            numOfAnswered = day6Instance.checkSumOfCounts(firstPart);

            /* Part-2 */
            firstPart = false;
            numOfQuesAllAnswered = day6Instance.checkSumOfCounts(firstPart);

            /* ------------------------------------------------------ */


        }

    }
}
