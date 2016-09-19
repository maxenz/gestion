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

                    Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return Json( new { Message = "Los datos de inicio de sesión son incorrectos."}, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    Serial = objLogin.Licencia.Serial,
                    AndroidUrl = objLogin.AndroidUrl
                },
                JsonRequestBehavior.AllowGet
                );

            }
            catch (Exception exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { Message = exception.Message }, JsonRequestBehavior.AllowGet);
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
