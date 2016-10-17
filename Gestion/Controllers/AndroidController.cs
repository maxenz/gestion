using System.Data;
using System.Linq;
using System.Web.Mvc;
using Gestion.Models;
using System.Net;
using System.Web.Http;
using System;

namespace Gestion.Controllers
{
    public class AndroidController : Controller
    {
        private GestionDb context = new GestionDb();

        public JsonResult Login(string user, string password, string log)
        {
            try
            {
                HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
                setLoginLog(log);
                ClientesLicencia objLogin = context.ClientesLicencias.Where(x => ((x.Alias == user) || (x.Licencia.Serial == user)) && (x.AndroidPassword == password)).FirstOrDefault();

                if (objLogin == null)
                {
                    return Json(new { Error = true, Message = "Los datos de inicio de sesión son incorrectos." }, "application/json", JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    Serial = objLogin.Licencia.Serial,
                    AndroidUrl = objLogin.AndroidUrl
                },
                "application/json",
                JsonRequestBehavior.AllowGet
                );

            }
            catch (Exception exception)
            {
                return Json(new { Error = true, Message = exception.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetClientConnectionString(string serial)
        {
            try
            {
                HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
                ClientesLicencia license = context.ClientesLicencias.Where(x => ((x.Licencia.Serial == serial))).FirstOrDefault();

                if (license == null || license.ConnectionString == null)
                {
                    return Json(new { Error = true, Message = "No se encontró connection string para el serial solicitado" }, "application/json", JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    ConnectionString = license.ConnectionString
                },
                "application/json",
                JsonRequestBehavior.AllowGet
                );

            }
            catch (Exception exception)
            {
                return Json(new { Error = true, Message = exception.Message }, "application/json", JsonRequestBehavior.AllowGet);
            }
        }

        private void setLoginLog(string log)
        {

            LicenciasLog licenciasLog = new LicenciasLog();
            licenciasLog.SolicitudID = 3;
            licenciasLog.IP = "0.0.0.0";
            licenciasLog.GenericDescription = log;
            licenciasLog.CreatedAt = DateTime.Now;
            context.LicenciasLogs.Add(licenciasLog);
            context.SaveChanges();


        }
    }
}
