using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetStore.Models;

namespace PetStore.ViewModels
{
    public class KategorijasViewModel
    {
        public IEnumerable<Kategorija> Kategorija { get; set; }
        public byte? KategorijaId { get; set; }
    }
}