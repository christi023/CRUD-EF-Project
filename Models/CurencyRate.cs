using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
 public class CurencyRate
    {
        string currency;
        double dollars, result = 0;

        public CurencyRate()
        {


        }

        public string Currency { get => currency; set => currency = value; }
        public double Dollars { get => dollars; set => dollars = value; }
        public double Result { get => result; set => result = value; }




        public double CurencyGet(string currency, double dollars)
        {


            if (currency == "euros")
            {
                result = dollars * 1.02;
            }
            else if (currency == "krone")
            {
                result = dollars * 120;
            }

            else if (currency == "pesos")
            {
                result = dollars * 10;
            }
            else
            {

                Console.WriteLine("Error");
            }
            return result;
        }
    }
}

