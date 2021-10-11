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
            /*
             * Two vital variables are initiated in order to be able to run the program to it's full potential (or at all...)
             * First is the very bool value that keeps the program running, the second is the list that will store all the chosen prime numbers.
             */
            bool programActive = true;
            List<int> primes = new List<int>();
            /*
             * I use a do-while in order to keep the program running until the user chooses to quit.
             */
            do
            {
                /*First i clear the console in order to not have all the history of previous numbers typed in.
                  Then the welcome message with the prompt to the user to type his/hers choice of number.
                  The TryParse is there to make sure that the input is actually a number.
                */
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please choose your prim number: ");
                int.TryParse(Console.ReadLine(), out int userChoice);

                //I then check if the number is a prime number, if it isn't then i prompt for another try by clicking any button.
                if (IsNumberPrime(userChoice) == false)
                {

                    Console.WriteLine("Not a prim number or you didn't type a number! Press any key to try again.");
                    Console.ReadKey();
                }
                //If the number is indeed a prime number then i give the user some options with the prime number. Again i use the check for the input value.
                else
                {
                    Console.WriteLine("The chosen number is a prime number!");
                    Console.WriteLine("1. Add number to list.");
                    Console.WriteLine("2. Write out the next prime number.");
                    Console.WriteLine("3. Show numbers in list!");
                    Console.WriteLine("4. Exit");
                    int.TryParse(Console.ReadLine(), out int menuChoice);

                    //For the menu i use a switch to handle the different options.
                    switch (menuChoice)
                    {
                        //First option is to add the number to a list which is done below. Once again i use the readkey command to give the user time to 
                        //see what happens.
                        case 1:
                            primes.Add(userChoice);
                            Console.WriteLine("Number added to list! Press any key to go back to start.");
                            Console.ReadKey();
                            break;
                        /*
                         *This option first takes the highest value from the list and then uses the method called NextPrime which checks if the next number
                         *in line is a prime number. If it is, then it will print the number for the user to see.
                         */
                        case 2:
                            int maxValue = primes.Max();
                            int newPrime = NextPrime(maxValue);
                            Console.Clear();
                            Console.WriteLine($"{newPrime}");
                            Console.ReadKey();

                            break;
                            /*
                             *The third option uses a sort of the list and then a reverse in order to get the highest number at the top of the console window
                             * when the print of values is done. A use of a foreach is done in order to print the list.
                             */
                        case 3:
                            Console.Clear();
                            primes.Sort();
                            primes.Reverse();
                            foreach (var i in primes)
                            {
                                Console.WriteLine(i + ", ");
                            }

                            Console.ReadKey();
                            break;
                            /*
                             * Last option is simply an exit option for the user should they want to quit.
                             */
                        case 4:
                            Console.WriteLine("Have a pleasant day!");
                            programActive = false;
                            break;
                    }
                }
            } while (programActive);
        }


        //Method that checks if the users number is a prime number.
        //Author of the method code: https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number .
        public static bool IsNumberPrime(int userNumber)
        {
            if (userNumber <= 1 || userNumber % 2 == 0) //An if statement that checks if the number is either less than or equal to 1,
                                                        //or if the return value is 0 from dividing the users number with 2. 
            {
                return false;
            }
            /*
             * The limit variable is set to the value that returns from the Math.Floor method, which returns the largest int value that is less than or
             * equal to userNumber.
             * But I also use Math.Sqrt method which is used to calculate the square root of a specified number. In this case I use our
             * input value. This method I got from the afore mentioned link.
             */
            var limit = (int) Math.Floor(Math.Sqrt(userNumber)); 

            /*
             * A for loop is used in order to check if the number returns a 0 or a value after the modulus calculation.
             */
            for (int i = 3; i <= limit; i++)
                if (userNumber % i == 0)
                {
                    return false;
                }

            return true;
        }

        /*
         * Method that checks for the next prime number in line after the highest number in the list.
         */
        public static int NextPrime(int userNumber)
        {
            //Create a bool in order to keep the while loop running until we find the next prime.
            bool success = false;
            while (!success)
            {
                /*
                 * Increment userNumber by 1 after each check. Then the if statement will use the method IsNumberPrime in to calculate if the new number is
                 * a prime. If it is a prime then it will end the loop by setting "success" variable to true. Then return the new number in the variable userNumber.
                 */

                userNumber++;
                if (IsNumberPrime(userNumber) == true)
                {
                    success = true;
                }
            }

            return userNumber;
        }
        
    }
}
