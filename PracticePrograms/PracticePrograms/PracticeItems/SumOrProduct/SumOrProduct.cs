using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems
{
    public class SumOrProduct : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            GetSumOrProduct();
        }

        public void GetSumOrProduct()
        {
            var input = new UserInput();
            var result = TryGetUserInput(out input);
            if (result)
                Calculate(input);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private void Calculate(UserInput input)
        {
            int sum = 0;
            if (input.Choice == SumOrProductChoice.Product)
                sum = 1;

            for (int i = 1; i <= input.Number; i++)
            {
                int oldsum = sum;
                if (input.Choice == SumOrProductChoice.Sum)
                {
                    sum += i;
                    Trace.WriteLine($"{oldsum} + {i} == {sum}");
                } else
                {
                    sum *= i;
                    Trace.WriteLine($"{oldsum} * {i} == {sum}");
                }
            }
        }

        private bool TryGetUserInput(out UserInput result)
        {
            Console.WriteLine("What number would you like to work with?");
            string numInput = Console.ReadLine();

            int n = 0;
            var intParseResult = Int32.TryParse(numInput, out n);
            if (!intParseResult)
            {
                Console.WriteLine("Failed to convert input into an integer.");
                result = null;
                return false;
            }

            Console.WriteLine($"You have chosen: {n}. Would you like the sum of 1 to {n}, or the product of 1 to {n}?");
            string choiceInput = Console.ReadLine();

            SumOrProductChoice c;
            var choiceParseResult = Enum.TryParse<SumOrProductChoice>(choiceInput, true, out c);

            if (!choiceParseResult)
            {
                Console.WriteLine("Failed to parse choice. Please enter either 'sum', 'product', '0' or '1'.");
                result = null;
                return false;
            }

            result = new UserInput() { Number = n, Choice = c };
            return true;
        }

        private class UserInput
        {
            public int Number { get; set; }
            public SumOrProductChoice Choice { get; set; }
        }

        private enum SumOrProductChoice
        {
            Sum,
            Product
        }
    }
}
