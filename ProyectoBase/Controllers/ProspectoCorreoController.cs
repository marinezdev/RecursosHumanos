using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProspectoCorreoController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ProspectoCorreo_Agregar(Models.ProspectoCorreo prospectoCorreo, Application.ProspectoCorreo APProspectoCorreo)
        {
            prospectoCorreo.Usuarios = Usuarios;
            Models.ProspectoCorreo DBProspectoCorreo = APProspectoCorreo.ProspectoCorreo_Agregar(prospectoCorreo);
            return Json(DBProspectoCorreo);
        }


        [HttpPost]
        public JsonResult ProspectoCorreo_Actualizar(Models.ProspectoCorreo prospectoCorreo, Application.ProspectoCorreo APProspectoCorreo)
        {
            Models.ProspectoCorreo R = new Models.ProspectoCorreo();

            prospectoCorreo.Usuarios = Usuarios;
            R = APProspectoCorreo.ProspectoCorreo_Actualizar(prospectoCorreo);
            return Json(R);
        }


        [HttpPost]
        public JsonResult Prospecto_EliminarCorreo(Models.ProspectoCorreo prospectoCorreo, Application.ProspectoCorreo APProspectoCorreo)
        {
            prospectoCorreo.Usuarios = Usuarios;
            Models.ProspectoCorreo DBVacante = APProspectoCorreo.Prospecto_EliminarCorreo(prospectoCorreo);
            return Json(DBVacante);
        }
    }
}
