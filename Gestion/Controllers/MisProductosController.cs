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
    [Authorize(Roles = "Cliente,Administrador")]
    public class MisProductosController : Controller
    {
        private GestionDb db = new GestionDb();

        //
        // GET: /MisProductos/

        public ActionResult Index(int ClienteID = 0)
        {

            if (User.IsInRole("Administrador"))
            {
                if (ClienteID == 0)
                {
                    return HttpNotFound("Los productos solicitados no existen");
                }
                else
                {
                    Cliente cli = db.Clientes.Find(ClienteID);
                    if (setProductos(cli))
                    {
                        return PartialView("Index");
                    }
                    else
                    {
                        return PartialView("_NoProductos");
                    }

                }
            }
            else
            {
                var userName = User.Identity.Name;
                var userID = db.UserProfiles.Where(x => x.UserName == userName).FirstOrDefault().UserId;

                Cliente cliente = db.ClientesUsuarios.Where(x => x.UsuarioID == userID).FirstOrDefault().Cliente;
                if (setProductos(cliente))
                {
                    return View("Index");
                }
                else
                {
                    return View("_NoProductos");
                }
            }

        }

        private bool setProductos(Cliente cliente)
        {
            var cliLic = db.Clientes.Find(cliente.ID).ClientesLicencias.FirstOrDefault();
            if (cliLic == null)
            {
                return false;
            }
            else
            {
                var prod = cliLic.ClientesLicenciasProductos.ToList();
                if (prod == null)
                {
                    return false;
                }
                else
                {
                    foreach (var x in prod)
                    {
                        if (x.Producto.Descripcion == "Shaman Express")
                        {
                            ViewBag.Express = 1;
                        }
                        else if (x.Producto.Descripcion == "Shaman Full")
                        {
                            ViewBag.Full = 1;
                        }
                    }

                    return true;
                }
            }
        }

        //
        // GET: /MisProductos/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MisProductos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MisProductos/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MisProductos/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MisProductos/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MisProductos/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MisProductos/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
