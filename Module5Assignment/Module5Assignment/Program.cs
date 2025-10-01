// See https://aka.ms/new-console-template for more information
using System;

namespace Module5Assignment
{
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            //take start and end numberes
            WriteLine("Enter a number to start counting from:");
            int startNumber = int.Parse(Console.ReadLine());
            WriteLine("Enter a number to stop counting on:");
            int endNumber = int.Parse(Console.ReadLine());

            WriteLine("Starting counting from " + startNumber + " to " + endNumber);
            //re-using startNumber as the counter
            while (startNumber <= endNumber)
            {
                WriteLine(startNumber);
                startNumber++;
            }
        }
    }
}
