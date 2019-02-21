using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems
{
    public class NumberSum : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            int n = 0;
            if (args == null || args.Length == 0)
            {
                Trace.WriteLine("NumberSum requires an integer as an argument.");
                return;
            }

            var result = Int32.TryParse(args[0], out n);
            if (!result)
            {
                Trace.WriteLine("NumberSum requires a valid integer as an argument.");
                return;
            }

            bool mOnly = false;
            if (args.Length == 2)
                bool.TryParse(args[1], out mOnly);

            PrintSum(n, mOnly);
        }

        public void PrintSum(int n, bool multiplesOnly)
        {
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                var oldSum = sum;

                if (multiplesOnly)
                    if (i % 3 == 0 || i % 5 == 0)
                        sum += i;
                    else
                        continue;
                else
                    sum += i;

                Trace.WriteLine($"{oldSum} + {i} == {sum}");
            }
        }
    }
}
