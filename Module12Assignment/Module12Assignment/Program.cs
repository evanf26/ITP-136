// See https://aka.ms/new-console-template for more information
using System;

namespace Module12Assignment
{
    using static System.Console;

    //part class
    public class Part
    {
        //constructor
        public Part(int num, string name, string description, decimal price)
        {
            partNum = num;
            partName = name;
            partDesc = description;
            partPrice = price;
        }

        //part attributes
        public int partNum { get; set; }
        public string partName { get; set; }
        public string partDesc { get; set; }
        public decimal partPrice { get; set; }
    }

    class Program
    {

        //main
        static void Main()
        {
            //part count
            int partCount;
            //part attributes
            int aPartNum;
            string aPartName;
            string aPartDesc;
            decimal aPartPrice;

            //get number of parts
            WriteLine("Welcome to car part utility");
            while (true)
            {
                WriteLine("How many parts would you like to enter:");
                if (int.TryParse(ReadLine(), out partCount) && partCount > 0) { break; }
                WriteLine("Error: please provide a positive integer");
            }

            //define array
            Part[] partList = new Part[partCount];
            WriteLine("Please provide part information");

            //loop to fill array
            for (int i = 0; i < partCount; i++) 
            {
                //part number
                while (true)
                {
                    WriteLine("ID for part " + (i+1) + ":");
                    if (int.TryParse(ReadLine(), out aPartNum) && aPartNum > 0) { break; }
                    WriteLine("Error: please provide a positive integer");
                }

                //part name
                WriteLine("Name for part " + (i+1) + ":");
                aPartName = ReadLine();

                //description
                WriteLine("Description for part " + (i+1) + ":");
                aPartDesc = ReadLine();

                //price
                while (true)
                {
                    WriteLine("Price of part " + (i+1) + ":");
                    if (decimal.TryParse(ReadLine(), out aPartPrice) && aPartPrice > 0) { break; }
                    WriteLine("Error: please provide a positive decimal");
                }

                //assignment
                partList[i] = new Part(aPartNum, aPartName, aPartDesc, aPartPrice);
            }

            //begin output
            printList(partList);

            int input;

            //ask user for a part number
            while (true)
            {
                WriteLine("\nEnter a line number to view more part information:");
                if (int.TryParse(ReadLine(), out input) && input > 0 && input <= partList.Length) { break; }
                WriteLine("Error: please provide an integer within range");
            }

            Clear();
            printPart(partList[input - 1]);
        }

        //method to print list of parts
        static void printList(Part[] aPartList)
        {
            Clear();
            WriteLine(new string('*', 20).PadLeft(40) + "\n" + "* Car Part Utility *".PadLeft(40) + "\n" + new string('*', 20).PadLeft(40) +
                "\n");
            WriteLine("ID".PadLeft(7).PadRight(12) + "Name\n" + new string('=', 60));

            //loop for variable array size
            for (int i = 0; i < aPartList.Length; i++)
            {
                WriteLine(((i + 1) + ".").PadLeft(4).PadRight(5) + aPartList[i].partNum.ToString("D6") + " " + aPartList[i].partName);
            }
        }

        //method to print single part
        static void printPart(Part part)
        {
            WriteLine("ID".PadRight(7) + "Name".PadRight(48) + "Price");
            WriteLine(part.partNum.ToString("D6").PadRight(7) + part.partName.PadRight(44) + $"{part.partPrice:C}".PadLeft(9));
            WriteLine("\nDescription\n" + part.partDesc);
        }
    }
}