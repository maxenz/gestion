using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion.Models;
using PagedList;

namespace Gestion.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PaisesController : Controller
    {
        private GestionDb db = new GestionDb();

        //
        // GET: /Paises/

        public ActionResult Index(string searchName = null, int page = 1)
        {
            var qPaises = from p in db.Paises select p;

            if (!String.IsNullOrEmpty(searchName))
            {

                qPaises = qPaises.Where(p => p.Descripcion.ToUpper().Contains(searchName.ToUpper()));
            }

            qPaises = qPaises.OrderBy(p => p.Descripcion);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Paises", qPaises.ToPagedList(page,6));
            }

            return View(qPaises.ToPagedList(page,6));
        }

        //
        // GET: /Paises/Details/5

        public ActionResult Details(int id = 0)
        {
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // GET: /Paises/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Paises/Create

        [HttpPost]
        public ActionResult Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        //
        // GET: /Paises/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Paises/Edit/5

        [HttpPost]
        public ActionResult Edit(Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        //
        // GET: /Paises/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Paises/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = db.Paises.Find(id);
            db.Paises.Remove(pais);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}