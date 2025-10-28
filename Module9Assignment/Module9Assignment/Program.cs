// See https://aka.ms/new-console-template for more information
using System;

namespace Module9Assignment
{
    using static System.Console;

    class Program
    {
        //main
        static void Main(string[] args)
        {
            //pre-define arrays to store car data
            string[] make = {"","","","",""};
            string[] model = {"","","","",""};
            double[] cost = {0,0,0,0,0};

            //collect user data on cars
            getCarData(make, model, cost);

            //print car data
            printCarData(make, model, cost);

            //print most expensive car
            printExpensiveCar(make, model, cost);
        }

        //method to simplify line dividing strings
        static void lineBreak(int len, char symbol) { WriteLine(new string(symbol, len)); }

        //method to collect car data from user
        static void getCarData(string[] aMake, string[] aModel, double[] aCost)
        {
            //loop through arrays to gather car data
            for (int i = 0; i < aMake.Length; i++) {
                WriteLine("Please enter data for car " + (i+1) + ":\n" +
                    "Make:");
                aMake[i] = ReadLine();
                WriteLine("Model:");
                aModel[i] = ReadLine();
                while (true)
                {
                    WriteLine("Cost:");
                    if (double.TryParse(ReadLine(), out aCost[i]) && aCost[i] >= 0) { break; }
                    WriteLine("Please provide a positive value with no commas");
                }
                lineBreak(60, '=');
            }
        }

        //method to print car data in a digestible format
        static void printCarData(string[] aMake, string[] aModel, double[] aCost)
        {
            WriteLine("Make" + String.Format("{0,28}", "Model") + String.Format("{0,28}","Cost"));

            for (int i = 0; i < aMake.Length; i++) {
                WriteLine(aMake[i].PadRight(27) + aModel[i].PadRight(29) + $"{aCost[i]:C}");
            }
            lineBreak(60, '=');
        }

        //method to find the most expensive car
        static void printExpensiveCar(string[] aMake, string[] aModel, double[] aCost)
        {
            //initialize variables for storing the max
            double maxValue = 0;
            int index = 0;
            //loop through cars
            for (int i = 0; i < aCost.Length; i++) {
                if (aCost[i] > maxValue) { index = i; maxValue = aCost[i]; }
            }
            //print findings
            WriteLine("The most expensive car provided was the " + aMake[index] + " " + aModel[index] + 
                $", at a price of {aCost[index]:C}");
        }
    }
}