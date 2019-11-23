using System;
namespace Task_10._1
{
    class Program
    {
        public delegate void Del();
        class Converter
        {
            public event Del Event;
            private double dollars;
            private double euros;
            public Converter()
            {
                dollars = 0;
                euros = 0;
            }
            public Converter(double dollars,double euros)
            {
                this.dollars = dollars;
                this.euros = euros;
            }
            public double Dollars
            {
                set { dollars = value; }
                get { return dollars; }
            }
            public double Euros
            {
                set { euros = value; }
                get { return euros; }
            }
            public decimal DollarToEuro()
            {
                decimal result = 0;
                result = (decimal)0.9 * (decimal)dollars;
                result=Math.Round(result, 2);
                if (dollars>10000)
                {
                    Event();
                }
                return result;   
            }
            public decimal EuroToDollar()
            {
                decimal result = 0;
                result = (decimal)1.11 * (decimal)euros;
                result= Math.Round(result, 2);
                if (euros>10000)
                {
                    Event();
                }
                return result;
                
            }
        }
        static void Print()
        {
            Console.WriteLine("Pay attention!10000 is much money");
        }
        static void Main()
        {
            Converter converter = new Converter(1315.15,10000.23);
            converter.Event += new Del(Print);
            Console.WriteLine("{0} dollars in euros is:{1}", converter.Dollars, converter.DollarToEuro());
            Console.WriteLine();
            Console.WriteLine("{0} euros in dollars is:{1}", converter.Euros, converter.EuroToDollar());
        }
    }
}
