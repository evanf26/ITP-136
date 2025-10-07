// See https://aka.ms/new-console-template for more information
using System;

namespace Module6Assignment
{
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            //initialize variables
            int secretNumber = 8;
            //call custom methods in order
            welcomeMessage();
            magicNumber(secretNumber);
            findArea();
            double taxRate = localTaxRate();
            WriteLine($"Local tax rate is: {taxRate}");

        }
        //welcome message method
        static void welcomeMessage()
        {
            WriteLine("Welcome to My Method Examples");
        }
        //magic number method
        static void magicNumber(int secretNumber)
        {
            WriteLine($"Secret number is: {secretNumber}");
        }
        //find area method
        static void findArea()
        {
            WriteLine("Finding area\nEnter first dimension:");
            double length = Convert.ToDouble(ReadLine());
            WriteLine("Enter the second dimension:");
            double width = Convert.ToDouble(ReadLine());
            WriteLine($"Area of a {length} x {width} space is: {length*width}");
        }
        //local tax rate method
        static double localTaxRate()
        {
            WriteLine("Enter local tax rate as a decimal (for example, 6% = 0.06)");
            double taxRate = Convert.ToDouble(ReadLine());
            return(taxRate);
        }
    }
}