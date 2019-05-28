using PetStore.Models;
using PetStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    [Authorize(Roles = RoleName.CanManageIgrackas)]
    public class IgrackasController : Controller
    {
        private ApplicationDbContext _context;

        public IgrackasController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Igrackas
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageIgrackas))
            {
                var igrackas = _context.Igrackas.Include(k => k.Kategorija).ToList();
                return View("List",igrackas);
            }
            else
            {
                var igrackas = _context.Igrackas.Include(k => k.Kategorija).ToList();
                return View("ReadOnlyList",igrackas);
            }
            
        }
        [Authorize(Roles = RoleName.CanManageIgrackas)]
        public ActionResult New()
        {
            var kategorijas = _context.Kategorijas.ToList();
            var viewModel = new IgrackaFormViewModel()
            {
                Kategorijas = kategorijas
            };
            return View("IgrackaForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageIgrackas)]
        public ActionResult Save(Igracka igracka)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new IgrackaFormViewModel(igracka)
                {
                    Kategorijas = _context.Kategorijas.ToList()
                };
                return View("IgrackaForm", viewModel);
            }

            string fileName = Path.GetFileNameWithoutExtension(igracka.File.FileName);
            string extension = Path.GetExtension(igracka.File.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            igracka.SlikaPath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/")+fileName);
            igracka.File.SaveAs(fileName);
            
            

            if (igracka.Id == 0)
            {
                _context.Igrackas.Add(igracka);
            }
            else
            {
                var igrackaInDb = _context.Igrackas.Single(i => i.Id == igracka.Id);
                
                igrackaInDb.SlikaPath = igracka.SlikaPath;
                igrackaInDb.File = igracka.File;
                igrackaInDb.Naziv = igracka.Naziv;
                igrackaInDb.KategorijaId = igracka.KategorijaId;
                igrackaInDb.Opis = igracka.Opis;
                igrackaInDb.Cijena = igracka.Cijena;

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Igrackas");
        }

        [Authorize(Roles = RoleName.CanManageIgrackas)]
        public ActionResult Edit(int id)
        {
            var igracka = _context.Igrackas.SingleOrDefault(i => i.Id == id);

            if (igracka == null)
            {
                return HttpNotFound();
            }

            var viewModel = new IgrackaFormViewModel(igracka)
            {
                Kategorijas = _context.Kategorijas.ToList()
            };

            return View("IgrackaForm", viewModel);
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var igracka = _context.Igrackas.SingleOrDefault(i => i.Id == id);

            if (igracka == null)
            {
                return HttpNotFound();
            }

            return View(igracka);
        }

        [Authorize(Roles = RoleName.CanManageIgrackas)]
        public ActionResult Delete(int id)
        {
            var igracka = _context.Igrackas.SingleOrDefault(i => i.Id == id);

            if (igracka == null)
            {
                return HttpNotFound();
            }

            _context.Igrackas.Remove(igracka);
            _context.SaveChanges();

            return RedirectToAction("Index","Igrackas");
        }

        // Ne radi listanje po kategorijama

        /*public ActionResult SortByKategorija(int? kId)
        {
            if(kId != null)
            {
                ViewBag.kId = kId;
                var igrackaList = _context.Igrackas
                                          .OrderByDescending(i => i.Id)
                                          .Where(k => k.KategorijaId == kId);
                return View(igrackaList);
            }
            else
            {
                var igrackaList = _context.Igrackas.OrderByDescending(i => i.Id);
                return View(igrackaList);
            }
            
        }*/
    }
}