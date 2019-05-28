using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    [Authorize(Roles = RoleName.CanManageIgrackas)]
    public class KategorijasController : Controller
    {
        private ApplicationDbContext _context;

        public KategorijasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Kategorijas
        public ActionResult Index()
        {
            var kategorijas = _context.Kategorijas.ToList();

            return View(kategorijas);
        }

        public ActionResult Details(int id)
        {
            var kategorija = _context.Kategorijas.SingleOrDefault(k => k.Id == id);

            if(kategorija == null)
            {
                return HttpNotFound();
            }

            return View(kategorija);
        }
    }
}