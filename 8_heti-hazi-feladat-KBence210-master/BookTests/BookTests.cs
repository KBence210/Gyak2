using Microsoft.VisualStudio.TestTools.UnitTesting;
using myclass;
using myproducts;
using System;

namespace book.Tests
{
    //NE SZERKESZD!!!!!!!!
    [TestClass()]
    public class BookTests
    {
        protected const string author = "J.K. Rowling";
        protected const string title = "Harry Potter";
        protected const int yearOfPublication = 2008;
        protected const int price = 3500;
        protected const int pages = 111;
        protected const string productName = "book";
        protected const string style = "guide";
        static Book book;
        //static Product product;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            //product = new Product(productName, price);
            book = new Book(author, title, price, pages, style);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //A Product osztály tesztjei

        [TestMethod("Az áfakulcs alapértelmezett értéke 27% legyen!")]
        public void taxPercent_ShouldBe27_ByDefault()
        {
            Assert.AreEqual(27, Product.defaultTaxPercent);
        }

        [TestMethod("A ChangeCurrency váltsa át a termékek devizanemét!")]
        public void ChangeCurrency_ShouldChangeCurrencies()
        {
            int[] prices = { 3000, 6000, 9000 };
            int[] expectedPrices = { 8, 17, 25 };

            Product[] books = {
                                new Book("A", "a", prices[0], 1, "horror"),
                                new Book("B", "b", prices[1], 1, "horror"),
                                new Book("C", "c", prices[2], 1, "scifi")
                    };

            Product.ChangeCurrency(books);

            for (int i = 0; i < books.Length; i++)
            {
                Product product = books[i];
                Assert.IsTrue(product.Currency.Equals("Euro"));
                Assert.AreEqual(expectedPrices[i], product.Price);
            }
        }

        [DataRow(1000, 1000, 0)]
        [DataRow(1100, 1000, 1)]
        [DataRow(1000, 1100, 2)]
        [TestMethod("A ComparePrice adjon vissza 0-t ha a 2 termék ára megegyezik, 1-et, ha az elsõ terméké nagyobb és 2-t egyébként!")]
        public void ComparePrice_ShouldReturn0IfPricesAreEqual1IfTheFirstIsGreaterAnd2Otherwise(int price1, int price2, int expectedComp)
        {
            Book book1 = new Book("A", "a", "style");
            book1.Price = price1;
            Book book2 = new Book("B", "b", "style");
            book2.Price = price2;

            Assert.AreEqual(expectedComp, Product.ComparePrice(book1, book2));
        }

        //A Book osztály tesztjei

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!
        [TestMethod("A SetPrice-nak az 1000 feletti értéket érintetlenül kell hagynia!")]
        public void SetPrice_Above999_ShouldNotBeChanged()
        {
            book.SetPrice(price);
            Assert.AreEqual(price, book.GetPrice());
        }

        //[TestMethod("Az IncreasePrice-nak pozitív értékre módosítania kell az árat!")]
        //public void IncreasePrice_ByAPositiveValue_ShouldChangePrice()
        //{
        //    book.SetPrice(price);
        //    int expectedIncreasedPrice = 4025;
        //    book.IncreasePrice(15);

        //    Assert.AreEqual(expectedIncreasedPrice, book.GetPrice());
        //}

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataTestMethod]
        //[DataRow(0)]
        //[DataRow(-10)]
        //[TestMethod("Az IncreasePrice-nak nem pozitív értékre nem szabad módosítania az árat!")]
        //public void IncreasePrice_By0OrNegativeValue_ShouldNotChangePrice(int priceInc)
        //{
        //    book.SetPrice(price);
        //    int expectedIncreasedPrice = book.GetPrice();
        //    book.IncreasePrice(priceInc);

        //    Assert.AreEqual(expectedIncreasedPrice, book.GetPrice());
        //}

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataTestMethod]
        //[DataRow(1004, 1104)]
        //[DataRow(1005, 1105)]
        //[DataRow(1006, 1107)]
        //[TestMethod("Az IncreasePrice-nak tört eredmény esetén kerekítenie kell a matematikai szabályoknak megfelelõen!")]
        //public void IncreasePrice_FractionalResult_ShouldBeRoundedAccordingToArithmeticRules(int originalPrice, int expectedPrice)
        //{
        //    book.SetPrice(originalPrice);
        //    book.IncreasePrice(10);

        //    Assert.AreEqual(expectedPrice, book.GetPrice());
        //}

        //[DataRow(-1001)]
        //[DataRow(-1000)]
        //[DataRow(-999)]
        //[DataRow(0)]
        //[DataRow(999)]
        //[TestMethod("Az SetPrice-nak az 1000 alatti értékeket 1000-re kell állítania")]
        //public void SetPrice_Below1000_ShouldBeCorrectedTo1000(int price)
        //{
        //    book.SetPrice(price);
        //    Assert.AreEqual(1000, book.GetPrice());
        //}

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString kimenetének tartalmaznia kell a címet")]
        public void ToString_ResultShouldContainTitle()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(title));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString kimenetének tartalmaznia kell a szerzőt")]
        public void ToString_ResultShouldContainAuthor()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(author));
        }

        [TestMethod("A ToString kimenetének tartalmaznia kell a publikáció évét")]
        public void ToString_ResultShouldContainYearOfPublication()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(DateTime.Now.Year.ToString()));
        }

        [TestMethod("A ToString kimenetének tartalmaznia kell az arat")]
        public void ToString_ResultShouldContainPrice()
        {
            book.SetPrice(price);
            string result = book.ToString();

            Assert.IsTrue(result.Contains(price.ToString()));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString kimenetének tartalmaznia kell az oldalszámot")]
        public void ToString_ResultShouldContainPages()
        {
            book.SetPrice(pages);
            string result = book.ToString();

            Assert.IsTrue(result.Contains(pages.ToString()));
        }

        [TestMethod("A ToString kimenetének tartalmaznia kell a stílust")]
        public void ToString_ResultShouldContainStyle()
        {
            string result = book.ToString();
            Assert.IsTrue(result.Contains(style),
                    "A ToString által elõállított string nem tartalmazza a stílust!");
        }

        [TestMethod("A SetPages/Pages negatív bemenetre nem szabad,hogy változtassa a pages értékét!")]
        public void SetPages_ForNegativeValues_ShouldNotChangePages()
        {
            Book book = new Book(author, title, price, pages, style);

            book.SetPages(-1);
            Assert.AreEqual(pages, book.GetPages());

            book.Pages = -1;
            Assert.AreEqual(pages, book.Pages);
        }

        [DataRow(1104, 938)]
        [DataRow(1107, 941)]
        [TestMethod("A Book DescreasePrice-nak tört eredmény esetén kerekítenie kell a matematikai szabályoknak megfelelõen!")]
        public void DecreasePrice_FractionalResult_ShouldBeRoundedAccordingToRules(int originalPrice, int expectedPrice)
        {
            book.Price = originalPrice;
            book.Style = style;
            book.DecreasePrice(10);
            Assert.AreEqual(expectedPrice, book.Price);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!
        [TestMethod("A 4 paraméteres konstruktornak a publikáció évét a jelen évre kell állítania!")]
        public void _4ParamConstructor_ShouldSetyearOfPublicationToCurrentYear()
        {
            Assert.AreEqual(DateTime.Now.Year, book.GetYearOfPublication());
        }

        [DataRow(1000, 1000)]
        [DataRow(0, 0)]
        [DataRow(-1000, 0)]
        [TestMethod("A 4 paraméteres konstruktornak az árat a megadott pozitív értékre kell állítania, vagy 0-ra, ha az nem pozitív!")]
        public void _4ParamConstructor_ShouldSetPriceToGivenPositiveValueOr0Otherwise(int setPrice, int expectedPrice)
        {
            Book book = new Book(author, title, setPrice, pages, style);
            Assert.AreEqual(expectedPrice, book.GetPrice());
        }

        [DataRow(1000, 1000)]
        [DataRow(0, 0)]
        [DataRow(-1000, 0)]
        [TestMethod("A 4 paraméteres konstruktornak az oldalszámot a megadott pozitív értékre kell állítania, vagy 0-ra, ha az nem pozitív!")]
        public void _4ParamConstructor_ShouldSetPagesToGivenPositiveValueOr0Otherwise(int setPages, int expectedPages)
        {
            Book book = new Book(author, title, price, setPages, style);
            Assert.AreEqual(expectedPages, book.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A 2 paraméteres konstruktornak az árat 2500-ra kell állítania!")]
        public void TwoParamConstructor_ShouldSetPriceTo2500()
        {
            book = new Book(author, title, style);
            Assert.AreEqual(2500, book.GetPrice());
        }

        [TestMethod("A 2 paraméteres konstruktornak 100-ra kell állítania az oldalszámot!")]
        public void TwoParamConstructor_ShouldSetPagesTo100()
        {
            book = new Book(author, title, style);
            Assert.AreEqual(100, book.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A GetLonger az elsõ könyvet adja vissza azonos oldalszám esetén!")]
        public void GetLonger_ForEqualPages_ShouldReturnFirstBook()
        {
            Book bookA = new Book(author, title, price, 1234, style);
            Book bookB = new Book(author, title, price, 1234, style);

            Book longer = Book.GetLonger(bookA, bookB);

            Assert.AreEqual(longer, bookA);
        }

        [DataRow(1, 2, 1)]
        [DataRow(2, 1, 0)]
        [TestMethod("A GetLonger a nagyobb oldalszámmal rendelkezõ könyvet adja vissza a 2 paraméter közül!")]
        public void GetLonger_ForDifferingPages_ShouldReturnTheLongerBook(int bookAPages, int bookBPages, int longerIndex)
        {
            Book[] books = {
                            new Book(author, title, price, bookAPages, style),
                            new Book(author, title, price, bookBPages, style)
                            };

            Book longer = Book.GetLonger(books[0], books[1]);

            Assert.AreEqual(longer, books[longerIndex]);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(33, false)]
        [DataRow(444, true)]
        [TestMethod("A HasEvenPages igazat ad vissza, ha páros a pages, hamisat ellenkezõ esetben!")]
        public void HasEvenPages_ShouldReturnTrueIfPagesIsEvenFalseOtherwise(int pages, bool isEven)
        {
            Book book = new Book(author, title, price, pages, style);

            Assert.AreEqual(isEven, book.HasEvenPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(1, 2, 3, 3)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(2, 3, 1, 3)]
        [DataRow(2, 1, 3, 3)]
        [TestMethod("A GetLongestBook visszaadja a leghosszabb könyvet!")]
        public void GetLongestBook_ShouldReturnTheBookWithTheMostPages(int pagesA, int pagesB, int pagesC, int longestPages)
        {
            Book[] books = {new Book(author, title, price, pagesA, style),
                            new Book(author, title, price, pagesB, style),
                            new Book(author, title, price, pagesC, style)
                            };

            Book longest = Book.GetLongestBook(books);

            Assert.AreEqual(longestPages, longest.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataRow(2, 1, 3, 3)]
        [DataRow(1, 2, 4, 5, 4)]
        [DataRow(4, 2, 1, 5, 4)]
        [DataRow(5, 4, 2, 1, 4)]
        [DataRow(2, 1, 5, 4, 4)]
        [TestMethod("A GetLongestEvenPagesBook visszaadja a leghosszabb páros oldalszámú könyvet!")]
        public void GetLongestEvenPagesBook_ShouldReturnTheBookWithTheMostEvenPages(int pagesA, int pagesB, int pagesC, int pagesD, int longestPages)
        {
            Book[] books = {new Book(author, title, price, pagesA, style),
                            new Book(author, title, price, pagesB, style),
                            new Book(author, title, price, pagesC, style),
                            new Book(author, title, price, pagesD, style)
                            };

            Book longest = Book.GetLongestEvenPagesBook(books);

            Assert.AreEqual(longestPages, longest.GetPages());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(1, 3, 5, 7)]
        [TestMethod("A GetLongestEvenPagesBook visszaadja a leghosszabb páros oldalszámú könyvet!")]
        public void GetLongestEvenPagesBook_ForArraysWithNoEvenPageBooks_ShouldReturnNull(int pagesA, int pagesB, int pagesC, int pagesD)
        {
            Book[] books = {new Book(author, title, price, pagesA, style),
                            new Book(author, title, price, pagesB, style),
                            new Book(author, title, price, pagesC, style),
                            new Book(author, title, price, pagesD, style)
                            };

            Book longest = Book.GetLongestEvenPagesBook(books);

            Assert.IsNull(longest);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A CountStyles a különbözõ stílusok számát adja vissza!")]
        public void CountStylesTest()
        {
            Book[] books = {
                            new Book(author, title, price, 1, "guide"),
                            new Book(author, title, price, 1, "guide"),
                            new Book(author, title, price, 1, "scifi")
                };
            int expectecNumberOfStyles = 2;

            Assert.AreEqual(expectecNumberOfStyles, Book.CountStyles(books));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A DiscountBooks csak az adott stílusú könyvek árát csökkenti!")]
        public void DiscountBooksTest()
        {
            Book[] books = {
                            new Book(author, title, 2000, 1, "horror"),
                            new Book(author, title, 2000, 1, "horror"),
                            new Book(author, title, 2000, 1, "scifi")
                };
            int expectedPriceHorror = 1800;
            int expectedPriceScifi = 2000;

            Book.DiscountBooks(books, "horror", 10);

            Assert.AreEqual(expectedPriceHorror, books[0].Price);
            Assert.AreEqual(expectedPriceHorror, books[1].Price);
            Assert.AreEqual(expectedPriceScifi, books[2].Price);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ListBooksWithStyle csak az adott stílusú könyveket listázza!")]
        public void ListBooksWithStyleTest()
        {
            Book[] books = {
                            new Book(author, title, 2000, 1, "horror"),
                            new Book(author, title, 2000, 1, "horror"),
                            new Book(author, title, 2000, 1, "scifi")
                    };
            int expectedSizeOfList = 2;

            Assert.AreEqual(expectedSizeOfList, Book.ListBooksWithStyle(books, "horror"));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("Az AveragePrice csak az adott stílusú könyvek átlagárát adja vissza!")]
        public void AveragePriceWitExistingStyle()
        {
            Book[] books = {
                                new Book(author, title, 2000, 1, "horror"),
                                new Book(author, title, 2000, 1, "horror"),
                                new Book(author, title, 2000, 1, "scifi")
                        };
            int expectedAvg = 2000;

            Assert.AreEqual(expectedAvg, Book.AveragePrice(books, "horror"));
        }

        [TestMethod("Az AveragePrice 0-át ad vissza, ha nincs adott stílusú könyv!")]
        public void AveragePriceWitNonExistingStyle()
        {
            Book[] books = {
                            new Book(author, title, 2000, 1, "horror"),
                            new Book(author, title, 2000, 1, "horror"),
                            new Book(author, title, 2000, 1, "scifi")
                    };
            int expectedAvg = 0;

            Assert.AreEqual(expectedAvg, Book.AveragePrice(books, "guide"));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //8. heti 

        [DataRow(10, 100)]
        [DataRow(0, 270)]
        [DataRow(-1, 270)]
        [TestMethod("A beállított adó mértéke csak pozitív szám lehet!")]
        public void SetTax_ShouldOnlySetPositiveValues(int setTax, int expectedTax)
        {
            book.Price = 1000;
            book.TaxPercent = setTax;

            Assert.AreEqual(expectedTax, book.GetTax());
        }

        [TestMethod("A pénznem alapértelmezett értéke Ft legyen!")]
        public void Currency_ShouldBeFt_ByDefault()
        {
            Assert.AreEqual("Ft", book.Currency);
        }

        [DataRow("Ft", "Ft")]
        [DataRow("Euro", "Euro")]
        [DataRow("USD", "Euro")]
        [TestMethod("A devizanem csak Ft, vagy Euro lehet! Más megadott érték esetén legyen Ft!")]
        public void SetCurrency_ShouldOnlySetFtOrEuro(string setCurrency, string expectedCurrency)
        {
            book.Currency = setCurrency;

            Assert.AreEqual(expectedCurrency, book.Currency);
        }

        [TestMethod("Az ToString kimenetének tartalmaznia kell az egységárat!")]
        public void ToString_ResultShouldContainUnitPrice()
        {
            string result = book.ToString();
            
            Assert.IsTrue(result.Contains(book.GetUnitPrice().ToString()),
                    "A ToString által elõállított string nem tartalmazza az bruttó árat!");
        }

        [TestMethod("A GetUnitPrice-nak brutto arral kell szamolnia!")]
        public void GetUnitPrice_ShouldReturnTaxedValue()
        {            
            book.Pages = 100;
            book.Currency = "Ft";
            book.Price = 2500;
            book.TaxPercent = 5;
            int expectedUnitPrice = 26;

            Assert.AreEqual(expectedUnitPrice, book.GetUnitPrice());
        }

        [TestMethod("A SelectAuthors visszaadja az összes szerzõt, akinek van a megadott egységárnál drágább könyve a tömbben!")]
        public void SelectAuthors_ShouldReturnAllAuthorsWhoHaveBooksAboveTheGivenUnitPrice()
        {
            Book[] books = {
                                    new Book("A", "a1", 2100, 1, "horror"),
                                    new Book("A", "a2", 1900, 1, "horror"),
                                    new Book("A", "a3", 2200, 1, "scifi"),
                                    new Book("B", "b", 2300, 1, "scifi"),
                                    new Book("C", "c", 1900, 1, "scifi"),
                                    new Book("D", "d", 1800, 1, "scifi"),
                            };

            string[] authors = Book.SelectAuthors(books, 2000);

            Assert.AreEqual(2, authors.Length);

            Array.Sort(authors);

            Assert.IsTrue(Array.BinarySearch(authors, "A") >= 0);
            Assert.IsTrue(Array.BinarySearch(authors, "B") >= 0);
        }


        [TestMethod("A SumGrossPrice kiszámítja egy Book tömbben a könyvek adóval növelt összárát!")]
        public void SumGrossPrice_ShouldReturnTheSumOfGrossPricesOfTheBooksInTheArray()
        {
            Book[] books = {
                                    new Book("A", "a1", 1000, 1, "horror"),
                                    new Book("A", "a2", 2000, 1, "horror"),
                                    new Book("A", "a3", 4000, 1, "scifi"),
                            };

            books[1].TaxPercent = 10;
            books[2].TaxPercent = 25;

            Assert.AreEqual(8250, Book.SumGrossPrice(books));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //Az EBoook osztály tesztjei

        [TestMethod("Az Ebook ToString kimenetének tartalmaznia kell az url-t")]
        public void ToString_ResultShouldContainUrl()
        {
            string url = "https://ebook.com";
            EBook ebook = new EBook("author", "title", 2000, 200, style, url);
            string result = ebook.ToString();

            Assert.IsTrue(result.Contains(url),
                    "A ToString által elõállított string nem tartalmazza az url-t!");
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!
    }
}