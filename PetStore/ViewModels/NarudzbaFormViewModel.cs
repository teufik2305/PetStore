using System;
using PetStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetStore.ViewModels
{
    public class NarudzbaFormViewModel
    {
        [Required]
        public int? Id { get; set; }

        public string Naziv { get; set; }

        public DateTime DatumNarudzbe { get; set; }

        [Display(Name = "Broj kartice")]
        [Required(ErrorMessage = "Molimo vas unesite vaš broj kartice.")]
        public string NacinPlacanja { get; set; }

        public string Status { get; set; }

        [Display(Name = "Ime i prezime")]
        [Required(ErrorMessage = "Molimo vas unesite vaše ime i prezime.")]
        public string ImeKupca { get; set; }

        [Display(Name = "Vaš broj telefona")]
        [Required(ErrorMessage = "Molimo vas unesite vaš broj telefona")]
        public string BrojKupca { get; set; }

        [Display(Name = "Vaša email adresa")]
        [Required(ErrorMessage = "Molimo vas unesite vašu email adresu.")]
        public string EmailKupca { get; set; }

        [Display(Name = "Vaša adresa dostavljanja")]
        [Required(ErrorMessage = "Molimo vas unesite vašu adresu dostavljanja.")]
        public string AdresaKupca { get; set; }

        public NarudzbaFormViewModel()
        {
            Id = 0;
        }

        public NarudzbaFormViewModel(Narudzba narudzba)
        {
            Id = narudzba.Id;
            ImeKupca = narudzba.ImeKupca;
            AdresaKupca = narudzba.AdresaKupca;
            EmailKupca = narudzba.EmailKupca;
            BrojKupca = narudzba.BrojKupca;
            NacinPlacanja = narudzba.NacinPlacanja;
        }
    }
}