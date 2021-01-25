using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class MobileClass
    {

        public MobileClass()
        {
            ID = System.Guid.NewGuid();
        }



        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        [System.ComponentModel.DataAnnotations.Schema.Column("Id")]
        public System.Guid ID { get; set; }




        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        [System.ComponentModel.DataAnnotations.Schema.Column("Office ")]
        public string Office { get; set; }




        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        [System.ComponentModel.DataAnnotations.Schema.Column("Brand")]
        public string Brand { get; set; }



        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        [System.ComponentModel.DataAnnotations.Schema.Column("Model")]
        public string Model { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.Column("PurchaseDate")]
        public DateTime PurchaseDate { get; set; }



        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        [System.ComponentModel.DataAnnotations.Schema.Column("ExpirationDate")]
        public string ExpirationDate { get; set; }



        [System.ComponentModel.DataAnnotations.Schema.Column("PurchasePrice")]
        public double PurchasePrice { get; set; }





        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        [System.ComponentModel.DataAnnotations.Schema.Column("Currency ")]
        public string Currency { get; set; }






        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        [System.ComponentModel.DataAnnotations.Schema.Column("ExchangeRate")]
        public string ExchangeRate { get; set; }



        //public string LDisplayName
        //{
        //    get
        //    {
        //        string strResult =
        //            string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} -{7}  ", Brand, Model, PurchaseDate, ExpirationDate, PurchasePrice, Currency, ExchangeRate);

        //        return (strResult);
        //    }
        //}
    }
}

