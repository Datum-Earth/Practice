using PracticePrograms.Interfaces;
using PracticePrograms.PracticeItems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Elementary
{
    public class MultiplicationTable : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            int mCount = 12;
            if (args != null && args.Length > 0)
                Int32.TryParse(args[0], out mCount);


            DisplayTable(mCount);
        }

        private void DisplayTable(int multiplicationCount)
        {
            List<string> output = new List<string>();

            for (int i = 1; i <= multiplicationCount; i++)
            {
                for (int j = 1; j <= multiplicationCount; j++)
                {
                    string line = $"{i} * {j} == {i * j}";
                    output.Add(line);
                }
            }

            var pTable = new PrintTable(output);
            var table = pTable.GetFormattedTable();
            foreach (var line in table)
            {
                Trace.WriteLine(line);
            }
        }
    }
}
