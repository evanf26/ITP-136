// See https://aka.ms/new-console-template for more information
using System;

namespace Module3Assignment
{
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {

            //initialize an input variable, as ReadLine returns a string
            string input;

            //simple greeting to the user
            WriteLine("Hello, today we will be itemizing a repair shop bill.");

            //ask the user for the price of each service, then save accordingly
            WriteLine("Please enter the total price for the oil change:");
            //parse the string to a float
            input = ReadLine();
            float oilChange = float.Parse(input);

            //not relevant but I had a flat tire on Sunday and was stuck at work until 1 am
            WriteLine("Please enter the total price for the tire change:");
            input = ReadLine();
            float tireChange = float.Parse(input);

            WriteLine("Please enter the total price for the car inspection:");
            input = ReadLine();
            float inspection = float.Parse(input);

            float total = (oilChange + tireChange + inspection);
            //output the price of service to the user
            WriteLine($"Subtotal for services performed = {total:C}"
                + $"\n6% tax for services performed = {(total * 0.06):C}"
                + $"\nTotal amount due = {(total * 1.06):C}");
        }
    }
}
