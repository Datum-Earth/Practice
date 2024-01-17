using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems
{
    public class PrintTable
    {
        private string[] Values { get; set; }

        public PrintTable(string[] vals)
        {
            this.Values = vals;
        }

        public PrintTable(List<string> vals)
        {
            this.Values = vals.ToArray();
        }

        public List<string> GetFormattedTable()
        {
            List<string> ret = new List<string>();
            string[,] table = ListToMatrix();

            for (int i = 0; i < table.GetLength(0); i++)
            {
                string line = String.Empty;
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    line += table[i, j] + '\t';
                }

                ret.Add(line);
            }

            return ret;
        }

        private string[,] ListToMatrix()
        {
            int matrixSize = TableMath.FindNextSquare(this.Values.Count());
            string[,] matrix = new string[matrixSize, matrixSize];

            int nextItemPos = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = this.Values[nextItemPos];
                    nextItemPos++;
                }
            }

            return matrix;
        }
    }
}
