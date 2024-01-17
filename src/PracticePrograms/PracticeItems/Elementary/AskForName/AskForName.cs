using PracticePrograms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.PracticeItems.Elementary
{
    public class AskForName : IPracticeProgram
    {
        public void Execute(string[] args)
        {
            bool bobAndAlice = false;
            if (args != null && args.Length > 0)
                bool.TryParse(args[0], out bobAndAlice);

            AskForNameAndGreetWithName(bobAndAlice);
        }

        private void AskForNameAndGreetWithName(bool bobAndAlice)
        {
            Console.WriteLine("What is your name?");
            var result = Console.ReadLine();

            if (bobAndAlice)
            {
                if (result.ToLower() == "bob" || result.ToLower() == "alice")
                    Console.WriteLine($"Hello, {result}.");
                else
                    Console.WriteLine("Unauthorized user.");
            }
            else
            {
                Console.WriteLine($"Hello, {result}.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
    }
}
