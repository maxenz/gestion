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
    public class ProvinciasController : Controller
    {
        private GestionDb db = new GestionDb();

        //
        // GET: /Provincias/
        public ActionResult Index(int PaisID ,String searchName = null, int page = 1)
        {

            var qProv = from p in db.Provincias where p.PaisID == PaisID select p;

            if (qProv == null)
            {
                return HttpNotFound();
            }

            if (!String.IsNullOrEmpty(searchName))
            {

                qProv = qProv.Where(p => p.Descripcion.ToUpper().Contains(searchName.ToUpper()));
            }

            qProv = qProv.OrderBy(p => p.Descripcion);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Provincias", qProv.ToPagedList(page, 6));
            }

            return View(qProv.ToPagedList(page, 6));
        }

        //
        // GET: /Provincias/Details/5

        public ActionResult Details(int id = 0)
        {
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        //
        // GET: /Provincias/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Provincias/Create

        [HttpPost]
        public ActionResult Create(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincias.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provincia);
        }

        //
        // GET: /Provincias/Edit/5

        public ActionResult Edit(int id = 0)
        {

            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        //
        // POST: /Provincias/Edit/5

        [HttpPost]
        public ActionResult Edit(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provincia);
        }

        //
        // GET: /Provincias/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        //
        // POST: /Provincias/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = db.Provincias.Find(id);
            db.Provincias.Remove(provincia);
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