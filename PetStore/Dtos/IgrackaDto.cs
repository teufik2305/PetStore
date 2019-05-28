using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Dtos
{
    public class IgrackaDto
    {
        public int Id { get; set; }

        public string SlikaPath { get; set; }

        [NotMapped]
        [Required]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
        
        [Required]
        public byte KategorijaId { get; set; }

        public KategorijaDto Kategorija { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        public double? Cijena { get; set; }
    }
}