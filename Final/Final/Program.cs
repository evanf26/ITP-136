using System;
using System.Reflection.Metadata.Ecma335;

//this program is made to simulate a libraries' book check out system.
//it uses 2 classes, a book blass which contains information on each book and whether it is checked out
//and an inherited reference book class for books which cannot be taken home - encyclopedias, dictionaries, etc.

namespace Final
{
    using static System.Console;

    //book class
    public class Book
    {
        //constructor
        //set checked out to false unless a value is given to simplify creation of books
        public Book(string aTitle, string aAuthor, string aIsbn, bool aChecked = false)
        {
            title = aTitle;
            author = aAuthor;
            isbn = aIsbn;
            checkedOut = aChecked;
        }

        //book attributes
        public string title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public bool checkedOut { get; set; }

        //methods to return a formatted string of book information
        public virtual string Format()
        {
            string safeTitle = title.Length > 33 ? title.Substring(0, 29) + "..." : title;
            string safeAuthor = author.Length > 17 ? author.Substring(0, 14) + "..." : author;
            return(safeTitle.PadRight(36) + safeAuthor.PadRight(21) + isbn.PadRight(17) + checkedOut);
        }
        public virtual string FormatFull()
        {
            return(title + "\n" + author + "\n" + isbn + "\n" + "Checked out: " + checkedOut);
        }

        //check out and return methods
        public virtual void CheckOut()
        {
            //exit early if condition for book is not met (already checked out)
            if (checkedOut) { WriteLine("This book is already checked out."); return; }
            checkedOut = true;
            WriteLine(title + " checked out successfully.");
        }
        public virtual void Return()
        {
            if (!checkedOut) { WriteLine("This book is already in inventory"); return; }
            checkedOut = false;
            WriteLine(title + " returned successfully.");
        }
    }

    //inherited reference book class
    public class ReferenceBook : Book
    {
        //constructor
        public ReferenceBook(string aTitle, string aAuthor, string aIsbn, bool aChecked = false) : base(aTitle, aAuthor, aIsbn, aChecked)
        {
        }

        //override Print() to obscure checkedOut value
        public override string Format()
        {
            string safeTitle = title.Length > 33 ? title.Substring(0, 29) + "..." : title;
            string safeAuthor = author.Length > 17 ? author.Substring(0, 14) + "..." : author;
            return (safeTitle.PadRight(36) + safeAuthor.PadRight(21) + isbn.PadRight(17) + "N/A");
        }
        public override string FormatFull()
        {
            return (title + "\n" + author + "\n" + isbn + "\n" + "This is a reference book and cannot be checked out.");
        }

        //override CheckOut() and Return() methods such that the book cannot be moved
        public override void CheckOut() { WriteLine("This is a reference book and cannot be check out."); }
        //overriding the Return() method effectively does nothing but protects us from weird edge cases
        //such as a reference book being declared checked out in its constructor, or a visitor accidentally taking it home
        public override void Return() { WriteLine("This is a reference book and should not have been taken."); }
    }



    class Program
    {
        //main
        static void Main()
        {
            //initialize library inventory
            //in an ideal world this would be populated from an external file or database
            //using list instead of array in case library inventory needs to change size
            List<Book> bookList = new List<Book>
            {
                new Book("1984","Jorjor Wel","978-1443434973"),
                new Book("Of Mice and Men","John Steinbeck", "978-0140177398",true),
                new Book("Fahrenheit 451","Ray Bradbury", "978-1451673319"),
                //according to amazon this set of encyclopedias weigh 130 pounds
                new ReferenceBook("Encyclopedia Britannica Vol. 35","Encyclopedia Britannica","978-0852294437"),
                new ReferenceBook("Merriam-Webster's Spanish-English Dictionary","Merriam-Webster","978-0877792659")
            };

            //loop until user exits program
            while(true)
            {
                //start by printing book list
                WriteLine("Welcome to the library!\n\nOur current inventory:\n");
                PrintBooks(bookList);

                //get user input to provide information
                int input;
                int bookNum;
                while (true)
                {
                    WriteLine("Enter a book number to get more information, or 0 to exit:");
                    if (int.TryParse(ReadLine(), out input) && input > -1 && input < (bookList.Count + 1)) { break; }
                    WriteLine("Error: please provide a positive integer within range\n");
                }

                //exit check
                if (input == 0) { Environment.Exit(0); }

                //correct input to match indexing on the backend
                bookNum = input - 1;

                //clear terminal and show selected book information
                Clear();
                WriteLine(bookList[bookNum].FormatFull());

                //ask user what they want to do with the book
                while (true)
                {
                    WriteLine("Would you like to:\n0. Exit\n1. Check this book out\n2. Return this book\n3. Select a different book");
                    if (int.TryParse(ReadLine(), out input) && input > -1 && input < 4) { break; }
                    WriteLine("Error: please provide a positive integer within range\n");
                }

                //exit check again
                if (input == 0) { Environment.Exit(0); }

                //perform selected operation
                else if (input == 1) { bookList[bookNum].CheckOut(); }
                else if (input == 2) { bookList[bookNum].Return(); }
                else { Clear(); continue; }

                //ask user for next step
                while (true)
                {
                    WriteLine("\nThank you.\nWould you like to:\n0. Exit\n1. Select a different book");
                    if (int.TryParse(ReadLine(), out input) && input > -1 && input < 2) { break; }
                    WriteLine("Error: please provide a positive integer within range\n");
                }

                //exit check again
                if (input == 0) { Environment.Exit(0); }

                //perform selected operation
                else { Clear(); }
            }
        }



        //simple helper method to print out a list of books
        static void PrintBooks(List<Book> books)
        {
            WriteLine("Title".PadRight(36).PadLeft(40) + "Author".PadRight(21) + "ISBN-13".PadRight(17) + "Checked Out?");
            for (int i = 0; i < books.Count; i++)
            {
                //print method takes an integer to number each book
                WriteLine((i+1 + ". ").PadRight(4) + books[i].Format());
            }
        }
    }
}