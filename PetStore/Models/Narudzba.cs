using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Narudzba
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        [Display(Name = "Datum narudžbe")]
        public DateTime DatumNarudzbe { get; set; }

        [Display(Name = "Broj kartice")]
        public string NacinPlacanja { get; set; }

        public string Status { get; set; }

        [Display(Name = "Ime i prezime")]
        public string ImeKupca { get; set; }

        [Display(Name = "Broj telefona")]
        public string BrojKupca { get; set; }

        [Display(Name = "Email adresa")]
        public string EmailKupca { get; set; }

        [Display(Name = "Adresa dostavljanja")]
        public string AdresaKupca { get; set; }

        public virtual ICollection<NarudzbaDetalji> NarudzbaDetalji { get; set; }

    }
}