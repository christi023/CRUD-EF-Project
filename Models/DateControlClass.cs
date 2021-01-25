using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DateControlClass
    {
      
        DateTime InputTime;
        bool expierProduct = false;
        DateTime PresentTme;
      
        private bool getDate;
        private string calcDate;


        public DateControlClass()
        {


        }

       

        public bool GetGetDate(DateTime dt)
        {

            PresentTme = DateTime.Now;

            TimeSpan ts = PresentTme - dt;

            int remainingTime = System.Convert.ToInt32(ts.TotalDays);
            if (remainingTime >= 1005)
            {

                expierProduct = true;
            }
            else
            {
                expierProduct = false;
            }
            return getDate;

        }


        public string CalctDate(DateTime dt)
        {

            PresentTme = DateTime.Now;

            TimeSpan ts = PresentTme - dt;

            int remainingTime = System.Convert.ToInt32(ts.TotalDays);
            if (remainingTime >= 1005)
            {
                calcDate = "This Product Got Expired";

            }
            else
            {
                int a;
                a = System.Convert.ToInt32(ts.TotalDays);

                calcDate = string.Format("{0:F0}", a);
            }
            return calcDate;

        }

    }
}