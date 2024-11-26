using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProspectoArchivoController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ProspectoArchivo_Agregar(Models.ProspectoArchivo prospectoArchivo, Application.ProspectoArchivo APProspectoArchivo)
        {
            prospectoArchivo.Usuarios = Usuarios;
            Models.ProspectoArchivo dbProspectoArchivo = APProspectoArchivo.ProspectoArchivo_Agregar(prospectoArchivo);
            return Json(dbProspectoArchivo);
        }

        [HttpPost]
        public JsonResult ProspectoArchivo_Seleccionar_Id(Models.ProspectoArchivo prospectoArchivo, Application.ProspectoArchivo APProspectoArchivo)
        {
            Models.ProspectoArchivo dbProspectoArchivo = APProspectoArchivo.ProspectoArchivo_Seleccionar_Id(prospectoArchivo);
            return Json(dbProspectoArchivo);
        }
    }
}
