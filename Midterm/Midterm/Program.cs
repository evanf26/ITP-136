// See https://aka.ms/new-console-template for more information
using System;

namespace Midterm
{
    using static System.Console;

    class Program
    {
        //main
        static void Main(string[] args)
        {
            //introduction print
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Welcome to Reynolds Airlines!");
            ForegroundColor = ConsoleColor.White;

            //collect user information
            WriteLine(new string('=', 60) + "\n" +
                "Please provide your information to get started\n" +
                "Name:");
            string name = ReadLine();
            WriteLine("Address:");
            string address = ReadLine();
            WriteLine("Date of travel (mm/dd/yyyy):");
            string date = ReadLine();
            WriteLine("Thank you\n" + new string('=', 60));

            //collect bag data
            int bagBill = BagData();
            int seatBill = SeatData();

            //print receipt information
            PrintReceipt(name, address, date, bagBill, seatBill);
        }


        //methods


        //bag data method returns price of bag check
        static int BagData()
        {
            //initialize response variables
            //cannot be null string or loop breaks
            string response = "";
            int numBags;

            WriteLine("Please provide luggage information");

            //loop until a correct response is provided
            while (response != "y" && response != "n")
            {
                WriteLine("Would you like to check one or more bags (y/n)?");
                response = ReadLine().ToLower();
                if (response != "y" && response != "n") { WriteLine("Please provide an appropriate response (y/Y/n/N)"); }
            }

            //calculate and return a value
            if (response == "n") {
                WriteLine(new string('=', 60));
                return (0);
            }
            else //else if not required since we already verify response in the loop
            {
                //check number of bags, looping until correct input again
                //in this case, we can loop infinitely until the TryParse is successful (cool)
                while (true)
                {
                    WriteLine("How many bags would you like to check?");
                    if (int.TryParse(ReadLine(), out numBags) && numBags >= 0) { break; }
                    WriteLine("Please provide a positive whole number value");
                }
                //return the charge ($25 per bag)
                WriteLine(new string('=', 60));
                return (numBags*25);
            }
        }

        //seat data returns pricing of seats
        //very similar structure to bag data, as such we can reuse our code
        static int SeatData()
        {
            //initialize response variables
            //cannot be null string or loop breaks
            string response = "";
            int numSeats;

            WriteLine("Please provide seating information");

            //loop until a correct response is provided
            while (response != "y" && response != "n")
            {
                WriteLine("Would you like to pay for seats (y/n)?");
                response = ReadLine().ToLower();
                if (response != "y" && response != "n") { WriteLine("Please provide an appropriate response (y/Y/n/N)"); }
            }

            //calculate and return a value
            if (response == "n") {
                WriteLine(new string('=', 60));
                return (0);
            }
            else //else if not required since we already verify response in the loop
            {
                //check number of seats, looping until correct input again
                //in this case, we can loop infinitely until the TryParse is successful (cool)
                while (true)
                {
                    WriteLine("How many seats would you like to purchase?");
                    if (int.TryParse(ReadLine(), out numSeats) && numSeats >= 0) { break; }
                    WriteLine("Please provide a positive whole number value");
                }
                //return the charge ($30 per seat)
                WriteLine(new string('=', 60));
                return (numSeats * 30);
            }
        }

        //receipt printer
        static void PrintReceipt(string aName, string aAddress, string aDate, int aBags, int aSeats)
        {
            string response = "";
            //ask if the user would like a receipt
            while (response != "y" && response != "n")
            {
                WriteLine("Would you like a receipt for the bill (y/n)?");
                response = ReadLine().ToLower();
                if (response != "y" && response != "n") { WriteLine("Please provide an appropriate response (y/Y/n/N)"); }
            }

            if (response == "y") {
                //calculate tax
                double tax = (aBags + aSeats) * 0.05;

                //print customer information
                WriteLine("Printing receipt...\n");
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine(new string('*', 60));
                ForegroundColor = ConsoleColor.DarkBlue;
                WriteLine("Customer: " + aName + "\n" +
                    "Billing Address: " + aAddress + "\n" +
                    "Date: " + aDate);
                ForegroundColor = ConsoleColor.White;
                WriteLine(new string('=', 60));

                //print prices
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Baggage check bill:" + String.Format("{0,41}", $"{aBags:C}") + "\n" +
                    "Seating bill:" + String.Format("{0,47}", $"{aSeats:C}") + "\n" +
                    "5% Tax:" + String.Format("{0,53}", $"{tax:C}") + "\n" +
                    "Total:" + String.Format("{0,54}", $"{(aBags + aSeats + tax):C}"));
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine(new string('*',60));
                ForegroundColor = ConsoleColor.White;
            }
        }
    }
}