using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePrograms.Interfaces;
using PracticePrograms.PracticeItems.Elementary;
using PracticePrograms.PracticeItems.Text;

namespace PracticePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;

            #region Elementary
            //Run(new HelloWorld());
            //Run(new AskForName(), new string[1] { "true" });
            //Run(new NumberSum(), new string[2] { "17", "true" });
            //Run(new SumOrProduct());
            //Run(new MultiplicationTable(), new string[1] { "5" });
            //Run(new PrimeNumbers());
            //Run(new GuessingGame());
            //Run(new CalculateLeapYears());
            //Run(new SummationProblem());
            #endregion

            //Run(new LargestElement());

            Console.ReadLine();

        }

        static void Run(IPracticeProgram prog, string[] args = null)
        {
            var runner = new PracticeProgramRunner(prog, args);
            runner.Run();
        }
    }
}
