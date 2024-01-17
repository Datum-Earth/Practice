using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Elementary
{
    public class SummationProblem : IPracticeProgram
    {
        /* https://adriann.github.io/programming_problems.html
         * 
         * 4⋅∑k=1106(−1)k+12k−1=4⋅(1−1/3+1/5−1/7+1/9−1/11…).
         * 
         */

        public void Execute(string[] args)
        {
            var result = Compute();
            Trace.WriteLine(result);
        }

        private double Compute()
        {
            double result = 0;

            for (int i = 1; i <= Math.Pow(10, 6); i++)
            {
                var numerator = Math.Pow(-1, (i + i));
                var denominator = (2 * i) - 1;

                result += numerator / denominator;
            }

            return result * 4;
        }
    }
}
