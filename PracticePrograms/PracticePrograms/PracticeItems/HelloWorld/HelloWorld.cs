using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePrograms.Interfaces;

namespace PracticePrograms.PracticeItems
{
    public class HelloWorld : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            _HelloWorld();
        }

        private void _HelloWorld()
        {
            Trace.WriteLine("Hello World!");
        }
    }
}
