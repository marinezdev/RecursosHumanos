using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ArchivoProspectoController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ArchivoProspecto_Agregar(Models.ArchivoProspecto archivoProspecto, Application.ArchivoProspecto APArchivoProspecto)
        {
            archivoProspecto.Usuarios = Usuario;
            Models.ArchivoProspecto dbProspectoArchivo = APArchivoProspecto.ArchivoProspecto_Agregar(archivoProspecto);
            return Json(dbProspectoArchivo);
        }
    } 
}
