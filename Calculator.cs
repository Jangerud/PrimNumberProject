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


        public void StartProgram()
        {
            bool programActive = true;

            do
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please choose your prim number: ");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                int[] primes = new int[] { };
                if (userChoice <= 1)
                {

                    Console.WriteLine("Please choose a higher number!");
                }
                else
                {

                }
            } while (programActive);
        }

        public static bool IsNumberPrime(int userNumber)
        {
            if (userNumber <= 1 || userNumber % 2 == 0)
            {
                return false;
            }

            return true;
        }
    }
}
