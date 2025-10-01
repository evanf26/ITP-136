// See https://aka.ms/new-console-template for more information
using System;

namespace Module4Assignment
{
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            //initialize variable for price of appointment
            float bill = 0;
            //doctor's office user menu
            WriteLine("Welcome to the doctor's office.\n" +
                "Please choose appointment type:\n" +
                "1. Sick Appointment\n" +
                "2. Check-up");
            //take input and check response
            string input = ReadLine();
            if (input == "1")
            {
                //check patient age
                WriteLine("You chose: Sick Appointment.\n" +
                    "Is the patient a child or an adult?\n" +
                    "1. Child\n" +
                    "2. Adult");
                //input is defined in the scope above so we can re-use it
                input = ReadLine();
                if (input == "1") { bill += 50; }
                else if (input == "2") { bill += 75; }

                //check for labs
                WriteLine("Did the patient have labs done today?\n" +
                    "1. Yes\n" +
                    "2. No");
                input = ReadLine();
                if (input == "1") { bill += 25; }
            }
            else if (input == "2")
            {
                //check patient age
                WriteLine("You chose: Check-up.\n" +
                    "Is the patient a child or an adult?\n" +
                    "1. Child\n" +
                    "2. Adult");
                input = ReadLine();
                if (input == "1") { bill += 75; }
                else if (input == "2") { bill += 100; }
            }
            WriteLine($"Total for todays visit is: {bill:C}" );
        }
    }
}
