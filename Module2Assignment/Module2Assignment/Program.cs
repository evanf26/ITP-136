// See https://aka.ms/new-console-template for more information
using System;

namespace Module2Assignment
{
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Who is being seen today?");
            string patientName = ReadLine();
            WriteLine("Welcome: " + patientName);
        }
    }
}
