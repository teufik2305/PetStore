using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    [AllowAnonymous]
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _context;
        private readonly string strKorpa = "Korpa";

        public ShoppingCartController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
                
            }

            if (Session[strKorpa] == null)
            {
                List<Korpa> korpas = new List<Korpa>
                {
                    new Korpa(_context.Igrackas.Find(id),1)
                };
                Session[strKorpa] = korpas;
            }
            else
            {
                List<Korpa> korpas = (List<Korpa>)Session[strKorpa];
                int check = IsExistingCheck(id);
                if(check == -1)
                {
                    korpas.Add(new Korpa(_context.Igrackas.Find(id), 1));
                }
                else
                {
                    korpas[check].Quantity++;
                }
                Session[strKorpa] = korpas;
            }
            return View("Index");
        }

        private int IsExistingCheck(int? id)
        {
            List<Korpa> korpas = (List<Korpa>)Session[strKorpa];
            for (int i = 0; i < korpas.Count; i++)
            {
                if (korpas[i].Igracka.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            int check = IsExistingCheck(id);
            List<Korpa> korpas = (List<Korpa>)Session[strKorpa];
            korpas.RemoveAt(check);
            return View("Index");
        }

        public ActionResult UpdateKorpa(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Korpa> korpas = (List<Korpa>)Session[strKorpa];
            for(int i = 0; i < korpas.Count; i++)
            {
                korpas[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strKorpa] = korpas;
            return View("Index");
        }


    }
}