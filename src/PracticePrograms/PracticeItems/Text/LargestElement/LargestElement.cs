using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Text
{
    public class LargestElement : IPracticeProgram
    {
        /* https://adriann.github.io/programming_problems.html
         * 
         * Write a function that returns the largest element in a list.
         * 
         * Note: Since this is the first problem, I'm going to assume element is character length.
         * Getting trickier with resolving type and applying type-based comparisons seems a bit
         * advanced for what the question is asking. Regardless, it would be neat to come back
         * and do it anyways
        */

        public void Execute(string[] args)
        {
            var exampleList = new List<string>()
            {
                "a",
                "no",
                "yes",
                "function",
                "four",
                "seven",
                "Kazuto Kirigaya"
            };

            Trace.WriteLine(GetLargestElement(exampleList));
        }

        private string GetLargestElement(List<string> list)
        {
            string largestElement = String.Empty;

            foreach (string element in list)
            {
                if (element.Length > largestElement.Length)
                    largestElement = element;
            }

            return largestElement;
        }
    }
}
