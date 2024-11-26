using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProspectoEntrevistaController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ProspectoEntrevista_Agregar(Models.ProspectoEntrevista prospectoEntrevista, Application.ProspectoEntrevista APProspectoEntrevista)
        {
            prospectoEntrevista.Usuarios = Usuarios;
            Models.ProspectoEntrevista DBProspectoEntrevista = APProspectoEntrevista.ProspectoEntrevista_Agregar(prospectoEntrevista);
            return Json(DBProspectoEntrevista);
        }

        [HttpPost]
        public JsonResult ProspectoEntrevista_Actualizar_IdEstatus(Models.ProspectoEntrevista prospectoEntrevista, Application.ProspectoEntrevista APProspectoEntrevista)
        {
            prospectoEntrevista.Usuarios = Usuarios;
            Models.ProspectoEntrevista DBProspectoEntrevista = APProspectoEntrevista.ProspectoEntrevista_Actualizar_IdEstatus(prospectoEntrevista);
            return Json(DBProspectoEntrevista);
        }

        [HttpPost]
        public JsonResult Vacante_Actualizar_entrevista(Models.ProspectoEntrevista prospectoEntrevista, Application.ProspectoEntrevista APPprospectoEntrevista)
        {
            Models.ProspectoEntrevista R = new Models.ProspectoEntrevista();

            prospectoEntrevista.Usuarios = Usuarios;
            R = APPprospectoEntrevista.Vacante_Actualizar_entrevista(prospectoEntrevista);
            return Json(R);
        }

        [HttpPost]
        public JsonResult Prospecto_EliminarEntrevista(Models.ProspectoEntrevista prospectoEntrevista, Application.ProspectoEntrevista APPprospectoEntrevista)
        {
            prospectoEntrevista.Usuarios = Usuarios;
            Models.ProspectoEntrevista DBVacante = APPprospectoEntrevista.Prospecto_EliminarEntrevista(prospectoEntrevista);
            return Json(DBVacante);
        }

    }
}
