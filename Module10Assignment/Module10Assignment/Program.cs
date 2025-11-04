// See https://aka.ms/new-console-template for more information
using System;

namespace Module10Assignment
{
    using static System.Console;

    public class Food
    {
        //constructor
        public Food(int id, string name, string description, double cost)
        {
            FoodID = id;
            Name = name;
            Description = description;
            Cost = cost;
        }
        //food properties
        public int FoodID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }

    class Program
    {
        //main
        static void Main(string[] args)
        {
            //create food objects
            Food carrot = new Food(1,"Carrot","Root vegetable",1.5);
            Food potato = new Food(2, "Potato", "Tuberous vegerable", 2.25);

            //print header line
            WriteLine("ID".PadRight(5) + "Name".PadRight(15) + "Description".PadRight(36) + "Cost\n" + new string('=', 60));

            //print food objects
            WriteLine((carrot.FoodID).ToString("D4") + " " + (carrot.Name).PadRight(15) + carrot.Description + $"{carrot.Cost:C}".PadLeft(40 - carrot.Description.Length));
            WriteLine((potato.FoodID).ToString("D4") + " " + (potato.Name).PadRight(15) + potato.Description + $"{potato.Cost:C}".PadLeft(40 - potato.Description.Length));
        }
    }
}