using myclass;
using System;
using System.Collections.Generic;

namespace myproducts
{
    /*
Készítsen új névtérben (myinterface) adóztatható (ITaxable) interfészt.
Metódusai: getter, setter tulajdonságok az áfakulcshoz (TaxPercent), 
a double típusú adót kiszámító absztrakt metódus (GetTax()), 
és a double típusú adóval terhelt értéket kiszámító absztrakt metódus (GetTaxedValue())

A Product osztály implementálja a ITaxable interfészt és végezze el az alábbi módosításokat:
- új publikus statikus konstans: alapértelmezett adó mértéke (defaultTaxPercent, egész, értéke 27).
- új adattag: áfakulcs (taxPercent, egész, értéke az alapértelmezett adó érték)
- új adattag: devizanem (currency, string, alapértelmezett értéke "Ft")
- Legyen paraméteres konstruktora is (név, ár, áfakulcs). Az ár és az áfakulcs nem lehet negatív!
Amennyiben a megadott ár, vagy áfakulcs negatív, legyen az értéke 0 az ár esetén 
és a defaultTaxPercent alapértelmezett érték az áfakulcs esetén!
- Legyen 2 paraméteres konstruktora is (név, ár), áfakulcs a defaultTaxPercent.
- Módosítsa a ToString() metódust, tartalmazza a bruttó árat is
- Implementálja az interfész absztrakt metódusait/tulajdonságait. A beállított afakulcs mértéke csak pozitív szám lehet!
Ha 0, vagy annál kisebb érték kerülne beállításra legyen helyette a defaultTaxPercent alapértelmezett adó az értéke!
- Írjon a devizanem adattaghoz getter, setter tulajdonságot. 
A devizanem csak Euro és Ft lehet, és devizanem váltáskor át kell számítani az árat (1 Euro = 360 Ft)!
Ha ezektől eltérő devizanemet próbálnánk beállítani legyen a devizanem az alapértelmezett!
- Írjon osztályszintű metódust (ChangeCurrency()), ami átváltja egy Product tömbben a termékek árát Ft-ról Euró-ra,
illetve fordítva (a devizanem aktuális állapotától függően).
    Átalakításnál ügyeljen, hogy az értékek kerekítve legyenek és ne levágva!
- Írjon két termék árát összehasonlító osztályszintű metódust (ComparePrice()), 
amely 1-et ad vissza ha az első termék a drágább, 2-t ha a második a drágább és 0-t, ha azonos árúak
- Írjon absztrakt metódust, amely a termék egységárát fogja kiszámítani (GetUnitPrice())

A Book osztály a Product leszármazottja. Áfája 5%. 
Az örökölt absztrakt metódus definíciója: bruttó ár / oldalszám.
     Kerekítésre figyelni!
Módosítsa a ToString() metódust, legyen benne az egységár is.
- Írjon osztályszintű metódust (string[] SelectAuthors()), ami megállapítja, 
    hogy egy Book tömbben mely szerzőknek van a paraméterben megadott egységárnál (unitPrice) drágább egységárú könyve. 
  Minden ilyen szerzőt csak egyszer írjon a tömbbe!
- Írjon osztályszintű metódust (SumGrossPrice()), ami kiszámítja egy Book tömbben a könyvek adóval növelt összárát.

Az EBook osztály definíciója változatlan.

A BookProgram futtatható osztályban olvassa be n darab könyv (EBook) adatait egy tömbbe. 
n-et ellenőrzött módon olvassa be (1 és 10 közötti érték). És tesztelje a létrehozott metódusokat.
    */
    public class Book : Product
    {
        private string author;
        //private readonly int yearOfPublication;
        private string title;
        private int yearofpublication;
        private int pages;
        private string style;
        private int price;
        private bool even;

        public static string[] SelectAuthors(Book[] books, int unitPrice)
        {
            List<string> authors = new List<string>();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].GetPrice() > unitPrice&&!authors.Contains(books[i].author))
                {
                    authors.Add(books[i].GetAuthor());
                }
            }
            return authors.ToArray();
        }

        public static double SumGrossPrice(Book[] books)
        {
            double sum = 0;
            for (int i = 0; i < books.Length; i++)
            {
                sum += books[i].GetTaxedValue();
            }
            return sum;
        }

        public override void DecreasePrice(int percentage)
        {
            switch (style)
            {
                case "children":
                    percentage += 7;
                    break;
                case "guide":
                    percentage += 5;
                    break;
            }
            base.DecreasePrice(percentage);
        }


        //- Írjon osztályszintű metódust (ListBooksWithStyle()), ami kiírja a paraméterben megadott stílusú könyvek adatait egy Book tömbben,
        //és visszaadja a kilistázott könyvek számát.
        public static int ListBooksWithStyle(Book[] books, string find)
        {
            int count = 0;
            foreach (Book book in books)
            {
                if (String.Compare(book.GetStyle(), find) == 0)
                {
                    Console.WriteLine(book);
                    count++;
                }
            }

            return count;
        }



        //- Írjon osztályszintű metódust (CountStyles()), ami megszámolja hányféle különböző stílusú könyv szerepel egy Book tömbben.
        public static int CountStyles(Book[] books)
        {
            List<string> styles = new List<string>();
            styles.Add(books[0].GetStyle());
            for (int i = 1; i < books.Length; i++)
            {
                if (!styles.Contains(books[i].GetStyle())) styles.Add(books[i].GetStyle());
            }
            return styles.Count;
        }


        //- Írjon osztályszintű metódust (DiscountBooks()), ami a paraméterben megadott stílusú könyvek árát a megadott százalékkal csökkenti egy Book tömbben.

        public static void DiscountBooks(Book[] books, string find, int decrease)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (string.Compare(books[i].GetStyle(), find) == 0)
                {
                    books[i].DecreasePrice(decrease);
                }
            }
        }


        //- Írjon osztályszintű metódust (AveragePrice()), ami kiszámítja a paraméterben megadott stílusú könyvek átlagárát egy Book tömbben.
        //  Nullát ad vissza, ha nincs ilyen stílusú könyv.
        public static int AveragePrice(Book[] books, string find)
        {
            int average = 0;
            int help = 0;
            /*for (int i = 0; i < books.Length; i++)
            {
                if (string.Compare(books[i].style, find) == 0)
                {
                    average += books[i].price;
                    help+=1;
                }

            }*/
            foreach (Book book in books)
            {
                if (String.Compare(book.GetStyle(), find) == 0)
                {
                    average += book.GetPrice();
                    help++;
                }
            }
            if (help == 0)
                average = 0;
            else
                average = average / help;

            return average;
        }
        public static Book GetLonger(Book books1, Book books2)
        {
            if (books1.pages == books2.pages)
            {
                return books1;
            }
            else if (books1.pages > books2.pages)
            {
                return books1;
            }
            else
            {
                return books2;
            }
        }
        public bool HasEvenPages()
        {
            if (GetPages() % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Book GetLongestBook(Book[] books)
        {
            int longest = 0;
            for (int i = 1; i < books.Length; i++)
            {
                if (books[longest].pages < books[i].pages)
                {
                    longest = i;
                }
            }
            return books[longest];
        }
        public static Book GetLongestEvenPagesBook(Book[] books)
        {
            int help = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].pages > books[help].pages && books[i].HasEvenPages() == true || books[help].HasEvenPages() != true)
                {
                    help = i;
                }
            }
            if (books[help].GetPages() % 2 == 0)
                return books[help];
            else
                return null;
        }

        //8. heti plusz

        //Az örökölt absztrakt metódus definíciója: bruttó ár / oldalszám.
        public override int GetUnitPrice()
        {
            return (int)Math.Round(GetTaxedValue() / pages, MidpointRounding.AwayFromZero);
        }

        //- Írjon osztályszintű metódust(string[] SelectAuthors()), ami megállapítja,
        // hogy egy Book tömbben mely szerzőknek van a paraméterben megadott egységárnál(unitPrice) drágább egységárú könyve.
        //Minden ilyen szerzőt csak egyszer írjon a tömbbe!


        //- Írjon osztályszintű metódust(SumGrossPrice()), ami kiszámítja egy Book tömbben a könyvek adóval növelt összárát.
        public Book(string author, string title, int price, int pages, string style) : base(price)
        {
            this.author = author;
            this.title = title;
            if (pages < 0)
                this.pages = 0;
            else
                this.pages = pages;
            this.style = style;
            this.yearofpublication = DateTime.Now.Year;
            if (price < 0)
            {
                this.Price = 0;
            }
            else
            {
                this.Price = price;
            }
        }
        public Book(string author, string title, string style) : base()
        {
            this.author = author;
            this.title = title;
            this.style = style;
            pages = 100;
            Price = 2500;
        }
        public string Author
        {
            get { return GetAuthor(); }
            set { SetAuthor(value); }
        }

        public int Pages
        {
            get { return GetPages(); }
            set { SetPages(value); }
        }

        public string Style
        {
            get { return GetStyle(); }
            set { SetStyle(value); }
        }
        public string Title
        {
            get { return GetTitle(); }
            set { SetTitle(value); }
        }
        public int GetYearOfPublication()
        { return yearofpublication; }

        public void SetYearOfPublication()
        { yearofpublication = DateTime.Now.Year; }

        public string GetTitle()
        { return title; }

        public void SetTitle(string value)
        { title = value; }

        public string GetAuthor()
        { return author; }

        public void SetAuthor(string value)
        { author = value; }

        public string GetStyle()
        {
            return style;
        }

        public void SetStyle(string value)
        {
            style = value;
        }
        public int GetPages()
        {
            return pages;
        }

        public void SetPages(int value)
        {
            if (value > 0)
                pages = value;
        }

        public override string ToString()
        {
            return base.ToString() + $"Author: {GetAuthor()} title: {GetTitle()} pages: {GetPages()} style: {GetStyle()} year of publication: {GetYearOfPublication()} egysegar: {GetUnitPrice()}";
        }


    }
}

