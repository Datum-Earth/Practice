using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems
{
    public class GuessingGame : IPracticeProgram
    {
        /* https://adriann.github.io/programming_problems.html
         * 
         * Write a guessing game where the user has to guess a secret number. 
         * After every guess the program tells the user whether their number was too large or too small.
         * At the end the number of tries needed should be printed. 
         * It counts only as one try if they input the same number multiple times consecutively.
        */

        public void Execute(string[] args)
        {
            DoGuessing();
        }

        void DoGuessing()
        {
            int num = new Random().Next(0, 11);
            int attempts = 0;
            int lastAttempt = 0;
            bool firstRun = true;

            while (true)
            {
                Console.WriteLine("Guess a number!");
                string response = Console.ReadLine();

                int guess;
                var parseResult = Int32.TryParse(response, out guess);

                if (!parseResult)
                {
                    Console.WriteLine("That's not a valid integer. Try again.");
                    attempts++;
                    continue;
                }

                if (guess == num)
                {
                    Console.WriteLine($"Congratulations. The number was {num}, and it took you {attempts} tries.");
                    break;
                } else
                {
                    if (guess < num)
                        Console.WriteLine($"Sorry, that was incorrect. The number is greater than {guess}.");
                    else if (guess > num)
                        Console.WriteLine($"Sorry, that was incorrect. The number is less than {guess}.");

                    if (firstRun) //making sure if you select 0 on your first attempt, it still increments your attempt count
                    {
                        firstRun = false;
                        attempts++;
                        continue;
                    }

                    if (guess != lastAttempt)
                        attempts++;
                }
            }
        }
    }
}
