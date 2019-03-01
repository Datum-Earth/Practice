using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticePrograms.PracticeItems.TableMath;

namespace PracticePrograms.PracticeItems
{
    public class PrimeNumbers : IPracticeProgram
    {
        /* https://adriann.github.io/programming_problems.html
         * 
         * Write a program that prints all prime numbers.
         * 
         * Note: Obviously if you go too high here, you'll run out of memory pretty quickly. The question
         * doesn't specify whether or not the program has to finish, so I guess this satisfies it.
         * 
         * This is just the most basic implementation of the sieve of eratosthenes. I would like to come back
         * and revisit this with an attempt at a segmented sieve, but even then I doubt I could find *all* prime
         * numbers since the memory cost with a segmented sieve is still O(sqrt(n)) with n being the upper bound.
         */

        public void Execute(string[] args)
        {
            int upperBound = 100;
            if (args == null || args.Length == 0)
                Trace.WriteLine("No arguments found. Using upper limit of 100.");
            else
            {
                int tempBound;
                var result = Int32.TryParse(args[0], out tempBound);
                if (result)
                    upperBound = tempBound;
                else
                    Trace.WriteLine("Failed to parse arg[0] as an integer. Using upper limit of 100.");
            }

            foreach (int i in GetPrimeNumbers(upperBound))
            {
                Trace.WriteLine(i);
            }
        }

        private IEnumerable<int> GetPrimeNumbers(int upperBound)
        {
            int n = (int)Math.Round(Math.Sqrt(upperBound));
            Dictionary<int, bool> numList = new Dictionary<int, bool>();
            foreach (int num in Enumerable.Range(2, upperBound))
                numList.Add(num, false);

            for (int i = 2; i <= n; i++)
            {
                if (numList[i]) // if already known to be compound, move on
                    continue;

                for (int j = i + i; j <= upperBound; j += i) // our starting number is known to be prime, so don't mark it out. Start the loop at the first multiple
                {
                    numList[j] = true;
                }
            }

            foreach (var val in numList)
            {
                if (!val.Value)
                    yield return val.Key;
            }
        }
    }
}
