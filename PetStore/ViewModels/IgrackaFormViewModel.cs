using PetStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.ViewModels
{
    public class IgrackaFormViewModel
    {
        public IEnumerable<Kategorija> Kategorijas { get; set; }

        public int? Id { get; set; }
        
        [NotMapped]
        [Display(Name = "Slika")]
        [Required(ErrorMessage = "Molimo vas odaberite sliku!")]
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite ime igracke.")]
        [StringLength(255)]
        public string Naziv { get; set; }

        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Molimo vas odaberite kategoriju igračke.")]
        public byte? KategorijaId { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Molimo vas unesite cijenu igračke.")]
        public double? Cijena { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Uredi igračke" : "Dodaj novu igračku";
            }
        }

        public IgrackaFormViewModel()
        {
            Id = 0;
        }

        public IgrackaFormViewModel(Igracka igracka)
        {
            Id = igracka.Id;
            File = igracka.File;
            Naziv = igracka.Naziv;
            KategorijaId = igracka.KategorijaId;
            Opis = igracka.Opis;
            Cijena = igracka.Cijena;
        }
    }
}