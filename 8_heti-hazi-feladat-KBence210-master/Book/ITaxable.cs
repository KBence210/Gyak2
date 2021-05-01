
namespace myinterface
{
    /*
     Készítsen új névtérben (myinterface) adóztatható (ITaxable) interfészt.
    Metódusai: getter, setter tulajdonságok az áfakulcshoz (TaxPercent), 
    a double típusú adót kiszámító absztrakt metódus (GetTax()), 
    és a double típusú adóval terhelt értéket kiszámító absztrakt metódus (GetTaxedValue())
     */
    interface ITaxable
    {

        public abstract double GetTaxedValue();

        public abstract double GetTax();

        /*double SetTax(double value)
        {
            Tax = value * TaxPercent / 100;
        }*/

        public int TaxPercent
        {
            get { return GetTaxPercent(); }
            set { SetTaxPercent(value); }
        }

        public void SetTaxPercent(int value)
        {
            TaxPercent = value;
        }

        public int GetTaxPercent()
        {
            return TaxPercent;
        }


    }
}
