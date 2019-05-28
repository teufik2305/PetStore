using PetStore.Models;
using PetStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    [Authorize(Roles = RoleName.CanManageIgrackas)]
    public class NarudzbaController : Controller
    {
        private ApplicationDbContext _context;

        public NarudzbaController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
                var narudzbas = _context.Narudzbas.ToList();
                return View("NarudzbaList", narudzbas);
        }

        public ActionResult Details(int? id)
        {
            var narudzba = _context.Narudzbas.Find(id);

            if (narudzba == null)
            {
                return HttpNotFound();
            }

            return View(narudzba);
        }
        [AllowAnonymous]
        public ActionResult NarudzbaForm()
        {
            var viewModel = new NarudzbaFormViewModel();

            return View("NarudzbaForm", viewModel);
        }
        [AllowAnonymous]
        public ActionResult Kupi(Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NarudzbaFormViewModel(narudzba);

                return View("NarudzbaForm", viewModel);
            }

            List<Korpa> korpas = (List<Korpa>)Session["Korpa"];

            // Spremanje narudzbe u tablicu

            narudzba.DatumNarudzbe = DateTime.Now;
            narudzba.Status = "U tijeku";
            _context.Narudzbas.Add(narudzba);
            _context.SaveChanges();

            // Spremanje detalja narudzbe u tablicu
            foreach(Korpa korpa in korpas)
            {
                NarudzbaDetalji narudzbaDetalji = new NarudzbaDetalji()
                {
                    NarudzbaId = narudzba.Id,
                    IgrackaId = korpa.Igracka.Id,
                    Kolicina = korpa.Quantity,
                    Cijena = korpa.Igracka.Cijena,
                };
                _context.NarudzbaDetaljis.Add(narudzbaDetalji);
                _context.SaveChanges();
            }

            // Uklanjanje Shopping Cart session
            Session.Remove("Korpa");

            return View("NarudzbaUspjesna");
        }
    }
}