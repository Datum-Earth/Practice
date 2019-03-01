using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems
{
    /* https://adriann.github.io/programming_problems.html
     * 
     * Write a program that prints the next 20 leap years.
     * 
     * Note: I don't really understand the math behind this. I just used this article. 
     * https://www.wikihow.com/Calculate-Leap-Years
     */

    public class CalculateLeapYears : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            foreach (int year in Calculate())
            {
                Trace.WriteLine(year);
            }
        }

        IEnumerable<int> Calculate()
        {
            int startingYear = DateTime.Now.Year;
            int leapYearsFound = 0;

            int targetYear = startingYear;
            while (leapYearsFound != 20)
            {
                if (targetYear % 4 == 0)
                {
                    if (targetYear % 100 != 0)
                    {
                        leapYearsFound++;
                        yield return targetYear;
                    } else if (targetYear % 400 == 0)
                    {
                        leapYearsFound++;
                        yield return targetYear;
                    }
                }

                targetYear++;
            }
        }
    }
}
