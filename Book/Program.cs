using myproducts;
using System;

namespace myprogram
{
    /*
A BookProgram futtatható osztályban olvassa be n darab könyv (EBook) adatait egy tömbbe. 
n-et ellenőrzött módon olvassa be (1 és 10 közötti érték).
És tesztelje a létrehozott metódusokat.
     */
    class BookProgram
    {
        static void Main(string[] args)
        {

            //MEGOLDASOK HELYE

            Console.WriteLine("Number of books: ");
            int numberOfBooks = ReadInteger();

            //MEGOLDASOK HELYE
            //tomb letrehozasa

            EBook[] ebooks = new EBook[numberOfBooks];
            Book[] books = new Book[numberOfBooks];
            //for (int i = 0; i < bookArray.Length; i++)
            {
                //konyv adatainak bekerese
                //konyv letrehozasa
                for (int i = 0; i < ebooks.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". könyv: ");
                    Console.Write("Szerzo: ");
                    string name = Console.ReadLine();

                    Console.Write("Cim: ");
                    string title = Console.ReadLine();

                    Console.Write("Kiadas eve ");
                    int yearofpublication = int.Parse(Console.ReadLine());

                    Console.Write("Ar: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Oldalszam: ");
                    int pages = int.Parse(Console.ReadLine());

                    Console.Write("Stilus: ");
                    string style = Console.ReadLine();

                    Console.Write("e-cim: ");
                    string url = Console.ReadLine();

                    ebooks[i] = new EBook(name, title, price, pages, style, url);
                    books[i] = new Book(name, title, price, pages, style);
                }
            }


            //MEGOLDASOK HELYE
            //ListBookArray() hasznalata
            ListBookArray(ebooks);
            Console.WriteLine("Number of stlyes:");
            Console.WriteLine(Book.CountStyles(books));

            string searchStyle = "guide";
            int percentage = 10;

            Book.DiscountBooks(books, searchStyle, percentage);

            Console.WriteLine(searchStyle[0].ToString().ToUpper() + searchStyle.Substring(1).ToLower() + " style books");
            Book.ListBooksWithStyle(books, searchStyle);
            //ListBooksWithStyle(ebooks, searchStyle);
            Console.WriteLine("Average price of " + searchStyle + " style books: " + Book.AveragePrice(books, searchStyle));

            //MEGOLDASOK HELYE


            //MEGOLDASOK HELYE


            double unitPrice = 20;

            //Book.SelectAuthors(books, unitPrice);

            //Console.WriteLine("Sum of sales: " + Book.SumGrossPrice(books));

            //Book.ChangeCurrency(books);

            Console.WriteLine("List of books after changecurrency:");

            //Book.ListBookArray(books);

        }

        public static void ListBookArray(Book[] book)
        {
            foreach (Book b in book)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine();
        }
        private static int ReadInteger()
        {
            //IMPLEMENTALNI
            /*int test = 0;
            var foo=Console.ReadLine();
            if (int.TryParse(foo, out int number1))
            {
                Console.WriteLine($"{number1} is a number");
            }
            else
            {
                Console.WriteLine($"{foo} is not a number");
            }*/
            int szam;
            do
            {
                Console.WriteLine("Give me a number between 1 and 10");
            } while (!int.TryParse(Console.ReadLine(), out szam) || !(szam >= 1 && szam <= 10));
            return szam;
            //return number1;
        }
    }
}