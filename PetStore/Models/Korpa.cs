using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Korpa
    {
        public Igracka Igracka { get; set; }
        public int Quantity { get; set; }

        public Korpa(Igracka igracka, int quantity)
        {
            Igracka = igracka;
            Quantity = quantity;
        }
    }
}