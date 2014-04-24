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
    public class LocalidadesController : Controller
    {
        private GestionDb db = new GestionDb();

        //
        // GET: /Localidades/

        public ActionResult Index(int PaisID, int ProvinciaID, String searchName = null, int page = 1)
        {
            var qLoc = from l in db.Localidades where l.ProvinciaID == ProvinciaID select l;

            if (qLoc == null)
            {
                return HttpNotFound();
            }

            if (!String.IsNullOrEmpty(searchName))
            {

                qLoc = qLoc.Where(p => p.Descripcion.ToUpper().Contains(searchName.ToUpper()));
            }

            qLoc = qLoc.OrderBy(p => p.Descripcion);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Localidades", qLoc.ToPagedList(page, 6));
            }

            ViewBag.PaisID = PaisID;
            ViewBag.ProvinciaID = ProvinciaID;
            ViewBag.Provincia = db.Provincias.Find(ProvinciaID).Descripcion.ToString();

            return View(qLoc.ToPagedList(page, 6));
        }

        //
        // GET: /Localidades/Details/5

        public ActionResult Details(int id = 0)
        {
            Localidad localidad = db.Localidades.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        //
        // GET: /Localidades/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Localidades/Create

        [HttpPost]
        public ActionResult Create(Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Localidades.Add(localidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localidad);
        }

        //
        // GET: /Localidades/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Localidad localidad = db.Localidades.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        //
        // POST: /Localidades/Edit/5

        [HttpPost]
        public ActionResult Edit(Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localidad);
        }

        //
        // GET: /Localidades/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Localidad localidad = db.Localidades.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        //
        // POST: /Localidades/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Localidad localidad = db.Localidades.Find(id);
            db.Localidades.Remove(localidad);
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