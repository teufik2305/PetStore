using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Igracka
    {
        public int Id { get; set; }

        [Display(Name = "Slika")]
        public string SlikaPath { get; set; }

        [NotMapped]
        [Display(Name = "Slika")]
        [Required(ErrorMessage = "Molimo vas odaberite sliku!")]
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite ime igracke.")]
        [StringLength(255)]
        public string Naziv { get; set; }

        public Kategorija Kategorija { get; set; }

        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Molimo vas odaberite kategoriju igračke.")]
        public byte KategorijaId { get; set; }

        [Required(ErrorMessage = "Molimo vas odaberite kategoriju igračke.")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite cijenu igračke.")]
        public double Cijena { get; set; }

    }
}