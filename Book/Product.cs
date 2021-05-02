using myinterface;
using System;

namespace myclass
{
    /*
A Product osztály implementálja a ITaxable interfészt és végezze el az alábbi módosításokat:
- új publikus statikus konstans: alapértelmezett adó mértéke (defaultTaxPercent, egész, értéke 27).
- új adattag: áfakulcs (taxPercent, egész, értéke az alapértelmezett adó érték)
- új adattag: devizanem (currency, string, alapértelmezett értéke "Ft")
- Legyen paraméteres konstruktora is (név, ár, áfakulcs). Az ár és az áfakulcs nem lehet negatív!
Amennyiben a megadott ár, vagy áfakulcs negatív, legyen az értéke 0 az ár esetén 
és a defaultTaxPercent alapértelmezett érték az áfakulcs esetén!
- Legyen 2 paraméteres konstruktora is (név, ár), áfakulcs a defaultTaxPercent.
- Módosítsa a ToString() metódust, tartalmazza a bruttó árat is
formatum: name: nev, price: ar, tax: ado%, grossPrice: nettoar devizanem
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
	 */
    public abstract class Product : ITaxable
    {
        //- név, ár (egész) adata
        //adattagok, fields
        private string name;
        private int price;
        private int taxPercent;
        private string currency="Ft";
        public static int defaultTaxPercent = 27;
        //property, getter/setter helyett
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Price
        {
            get { return GetPrice(); }
            set
            {
                if (value > 0)
                    SetPrice(value);
            }
        }

        public int TaxPercent
        {
            get { return taxPercent; }
            set
            {
                if (value > 0)
                    taxPercent = value;
                else
                    taxPercent = defaultTaxPercent;
            }
        }

        public string Currency
        {
            get { return GetCurrency(); }
            set{
                SetCurrency(value);
            }
        }

        public int GetPrice()
        { return price; }

        public void SetPrice(int value)
        {
            if (value < 0)
                price = value;
            else
                price = value;

        }

        public string GetCurrency()
        {
            return currency;
        }

        public void SetCurrency(string value)
        {
            if (value.Equals("Euro") || value.Equals("Ft"))
                currency = value;
        }

        //- konstruktor, amely mindkét adata megadásával inicializálja az adatokat
        public Product(string name, int price, int taxpercent)
        {
            this.name = name;

            if (price < 0)
                this.price = 0;
            else
                this.price = price;

            if (taxPercent < 0)
                this.taxPercent = 0;
            else
                this.taxPercent = taxpercent;
        }
        public Product(string name, int price)
        {
            this.name = name;

            if (price < 0)
                this.price = 0;
            else
                this.price = price;

            this.taxPercent = defaultTaxPercent;
            this.currency = GetCurrency();
        }
        public Product(int price)
        {
            if (price < 0)
                this.price = 0;
            else
                this.price = price;

            if (taxPercent < 0)
                this.taxPercent = 0;
            else
                this.taxPercent = taxpercent;
        }
        public Product()
        {
        }
        /*public override string ToString()
        {
            return $"Name:{Name} , price:{price}";
        }*/
        public override string ToString()
        {
            return $"Name: {name}, price: {Price} ";
        }

        //- metódus, amely paraméterben megadott százalék értékkel növeli a nettó árat
        public int IncreasePrice(int percentage)
        {
            if (percentage > 0)
            {
                price += (int)Math.Round(price * percentage / 100.0, MidpointRounding.AwayFromZero);
            }
            else
            {
                return price;
            }
            return price;
        }
        //virtual kulcsoval jelezzuk, hogy kesobb feluldefinialhatjuk
        //public virtual void DecreasePrice(int percentage)
        public virtual void DecreasePrice(int percentage)
        {
            if (percentage > 0)
            {
                //price = Convert.ToInt32(price - (price * percentage / 100.0));
                price -= (int)Math.Round(price * percentage / 100.0, MidpointRounding.AwayFromZero);
            }
            else
            {
                price = price;
            }
        }

        public double GetTaxedValue()
        {
            return price + GetTax();
        }

        public double GetTax()
        {
            //return price * taxPercent / 100.0;
            return (double)Math.Round(price * taxPercent / 100.0, MidpointRounding.AwayFromZero);
        }
        public abstract int GetUnitPrice();

        public static Product[] ChangeCurrency(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                products[i].SetCurrency("Euro");
                //if (products[i].currency.Equals("Euro"))
                //products[i].Currency = "Euro";
                products[i].price = (int)Math.Round(products[i].price / 360.0, MidpointRounding.AwayFromZero);
            }
            return products;
        }
        public static int ComparePrice(Product prod1, Product prod2)
        {
            if (prod1.price == prod2.price)
            {
                return 0;
            }
            else if (prod1.price > prod2.price)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}

