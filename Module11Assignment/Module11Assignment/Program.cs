// See https://aka.ms/new-console-template for more information
using System;

namespace Module11Assignment
{
    using static System.Console;

    class Program
    {
        //main
        static void Main(string[] args)
        {
            //pre-define decimals
            decimal inputA;
            decimal inputB;
            int operation;
            decimal output = 0;

            //ascii
            WriteLine(new string('=',14) + "\n" +
                "= Calculator =\n" +
                new string('=',14) + "\n");

            //loop to validate inputs
            while (true)
            {
                WriteLine("Please provide your first number");
                if (decimal.TryParse(ReadLine(), out inputA)) { break; }
                WriteLine("Error: please provide a decimal number");
            }
            while (true)
            {
                WriteLine("Please provide your second number");
                if (decimal.TryParse(ReadLine(), out inputB)) { break; }
                WriteLine("Error: please provide a decimal number");
            }

            //similar loop to get operation
            while (true)
            {
                WriteLine("Please provide the operator:\n" +
                    "1 - Addition\n" +
                    "2 - Multiplication\n" +
                    "3 - Subtraction\n" +
                    "4 - Division");
                if (int.TryParse(ReadLine(), out operation) && operation > 0 && operation < 5) { break; }
                WriteLine("Error: please provide a whole number between 1 and 4");
            }

            //perform calculation
            //technically we don't need the try catch because we verified inputs but better safe than sorry
            try
            {
                switch (operation)
                {
                    case 1:
                        output = inputA + inputB;
                        break;
                    case 2:
                        output = inputA * inputB;
                        break;
                    case 3:
                        output = inputA - inputB;
                        break;
                    case 4:
                        output = inputA / inputB;
                        break;
                }
                WriteLine("Answer is: " + output);
            } catch {
                WriteLine("Error: something went wrong");
            }
        }
    }
}