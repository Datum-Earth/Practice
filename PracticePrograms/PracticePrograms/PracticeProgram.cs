using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class PracticeProgramRunner
    {
        private IPracticeProgram _prog;
        private string[] _args;

        public PracticeProgramRunner(IPracticeProgram prog, string[] args = null)
        {
            this._prog = prog;
            this._args = args;
        }

        public void Run()
        {
            Trace.WriteLine("Running practice item.");
            this._prog.Execute(_args);
            Trace.WriteLine("Practice item finished.");
        }
    }
}
