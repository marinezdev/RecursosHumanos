using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProspectoMensajeController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ProspectoMensaje_Agregar(Models.ProspectoMensaje prospectoMensaje, Application.ProspectoMensaje APProspectoMensaje)
        {
            prospectoMensaje.Usuarios = Usuarios;
            Models.ProspectoMensaje DBProspectoMensaje = APProspectoMensaje.ProspectoMensaje_Agregar(prospectoMensaje);
            return Json(DBProspectoMensaje);
        }


        [HttpPost]
        public JsonResult ProspectoMensaje_Actualizar(Models.ProspectoMensaje prospectoMensaje, Application.ProspectoMensaje APPprospectoMensaje)
        {
            Models.ProspectoMensaje R = new Models.ProspectoMensaje();

            prospectoMensaje.Usuarios = Usuarios;
            R = APPprospectoMensaje.ProspectoMensaje_Actualizar(prospectoMensaje);
            return Json(R);
        }

        [HttpPost]
        public JsonResult Prospecto_EliminarMensaje(Models.ProspectoMensaje prospectoMensaje, Application.ProspectoMensaje APPprospectoMensaje)
        {
            prospectoMensaje.Usuarios = Usuarios;
            Models.ProspectoMensaje DBVacante = APPprospectoMensaje.Prospecto_EliminarMensaje(prospectoMensaje);
            return Json(DBVacante);
        }
    }
}
