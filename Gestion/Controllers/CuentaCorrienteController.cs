﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion.Models;
using Gestion.ViewModels;

namespace Gestion.Controllers
{

    [Authorize(Roles = "Cliente,Administrador")]
    public class CuentaCorrienteController : Controller
    {

        private GestionDb db = new GestionDb();

      
        public ActionResult Index(int ClienteID = 0)
        {

            //si el que accede a cuentasCorrientes es Administrador
            if (User.IsInRole("Administrador"))
            {
                if (ClienteID == 0)
                {
                    //Si en la url paso un cliente cualquiera
                    return HttpNotFound("La cuenta corriente solicitada no existe");
                }
                else
                {
                    Cliente cli = db.Clientes.Find(ClienteID);
                    var ctaCorrID = cli.CuentaCorrienteID;
                    //El cliente tiene cuenta corriente id?
                    if (ctaCorrID == null)
                    {
                        return PartialView("NoCuentaCorriente");
                    }
                    else
                    {
                        //Le paso al partial de cuentas corrientes el objeto de cuenta corriente
                        int cc = Convert.ToInt32(ctaCorrID);
                        return PartialView("_PartialVistaGeneral", setCuentaCorriente(cc));
                    }
                }
            }
            else
            {
                //El que está ingresando a la vista es el mismo cliente que quiere ver su cuenta corriente

                string actualUser = User.Identity.Name;
                ClientesUsuario cliUsr = db.ClientesUsuarios
                            .Where(x => x.Usuario.UserName == actualUser)
                            .FirstOrDefault();

                var ctaCorrID = cliUsr.Cliente.CuentaCorrienteID;

                if (ctaCorrID == null)
                {
                    return View("NoCuentaCorriente");
                }
                else
                {
                    int cc = Convert.ToInt32(ctaCorrID);
                    return View("Index", setCuentaCorriente(cc));
                }
            }

        }

        private List<CuentaCorrienteViewModel> setCuentaCorriente(int ctaCorrID)
        {

            try
            {
                wsCuentaCorriente.ClientesDocumentos svcCliDoc = new wsCuentaCorriente.ClientesDocumentos();

                var ctaCorr = new List<CuentaCorrienteViewModel>();

                string facturacion = svcCliDoc.GetCuentaCorriente((int)ctaCorrID, true);

                string[] vFacturacion = facturacion.Split('$');

                double acSaldo = 0;

                foreach (string factura in vFacturacion)
                {
                    string[] vFactura = factura.Split('^');

                    string fecha = getFormattedDate(vFactura[0]).ToShortDateString();
                    double debe = Convert.ToDouble(vFactura[3].Replace('.', ','));
                    double haber = Convert.ToDouble(vFactura[4].Replace('.', ','));
                    double saldo = debe - haber;
                    acSaldo += saldo;

                    ctaCorr.Add(new CuentaCorrienteViewModel
                    {
                        Fecha = getFormattedDate(vFactura[0]).ToShortDateString(),
                        TipoComprobante = vFactura[1],
                        NroComprobante = vFactura[2],
                        Debe = debe,
                        Haber = haber,
                        Saldo = acSaldo
                    });
                }

                if (acSaldo < 0)
                {
                    CuentaCorrienteViewModel lastCta = ctaCorr
                                                        .Where(x => x.TipoComprobante == "FAC").Last();

                    DateTime fecUltFactura = Convert.ToDateTime(lastCta.Fecha);

                    DateTime fec = DateTime.Now.AddDays(-60);

                    if (fecUltFactura < fec)
                    {
                        ViewBag.Deudor = 1;
                    }
                }

                ViewBag.Saldo = acSaldo;

                return ctaCorr;
            }
            catch (Exception e)
            {
                var ctaCorr = new List<CuentaCorrienteViewModel>();
                return ctaCorr;
            }

        }

        private DateTime getFormattedDate(string strFecha)
        {

            int year = Convert.ToInt32(strFecha.Substring(0, 4));
            int month = Convert.ToInt32(strFecha.Substring(4, 2));
            int day = Convert.ToInt32(strFecha.Substring(6, 2));

            DateTime dtFecha = new DateTime(year, month, day);

            return dtFecha;

        }

    }
}
