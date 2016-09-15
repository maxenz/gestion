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
                //context.Configuration.ProxyCreationEnabled = false;
                setLoginLog(log);
                ClientesLicencia objLogin = context.ClientesLicencias.Where(x => ((x.Alias == user) || (x.Licencia.Serial == user)) && (x.AndroidPassword == password)).FirstOrDefault();

                if (objLogin == null)
                {

                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
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
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
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
