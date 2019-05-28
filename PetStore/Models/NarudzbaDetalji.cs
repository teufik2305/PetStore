using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class NarudzbaDetalji
    {
        public int Id { get; set; }
        public int NarudzbaId { get; set; }
        public int IgrackaId { get; set; }
        public double Cijena { get; set; }
        public int Kolicina { get; set; }

        public virtual Narudzba Narudzba { get; set; }
        public virtual Igracka Igracka { get; set; }
    }
}