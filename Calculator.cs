using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimNumberProject
{
    public class Calculator
    {


        public static void StartProgram()
        {
            bool programActive = true;
            List<int> primes = new List<int>();
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please choose your prim number: ");
                int.TryParse(Console.ReadLine(), out int userChoice);

                
                if (IsNumberPrime(userChoice) == false)
                {

                    Console.WriteLine("Please choose another number! Press any key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("The chosen number is a prime number!");
                    Console.WriteLine("1. Add number to list.");
                    Console.WriteLine("2. Write out the next prime number.");
                    Console.WriteLine("3. Show numbers in list!");
                    Console.WriteLine("4. Exit");
                    int.TryParse(Console.ReadLine(), out int menuChoice);

                    switch (menuChoice)
                    {
                        case 1:
                            primes.Add(userChoice);
                            Console.WriteLine("Number added to list! Press any key to go back to start.");
                            Console.ReadKey();
                            break;

                        case 2:

                            break;

                        case 3:
                            Console.Clear();
                            foreach (var i in primes)
                            {
                                Console.WriteLine(i + ", ");
                            }

                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine("Have a pleasant day!");
                            programActive = false;
                            break;
                    }
                }
            } while (programActive);
        }

        public static bool IsNumberPrime(int userNumber)
        {
            if (userNumber <= 1 || userNumber % 2 == 0)
            {
                return false;
            }

            var limit = (int) Math.Floor(Math.Sqrt(userNumber));

            for (int i = 3; i <= limit; i++)
                if (userNumber % i == 0)
                {
                    return false;
                }

            return true;
        }
    }
}
