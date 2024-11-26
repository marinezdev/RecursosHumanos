using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProspectoNotaController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        [HttpPost]
        public JsonResult ProspectoNota_Agregar(Models.ProspectoNota prospectoNota, Application.ProspectoNota APProspectoNota)
        {
            prospectoNota.Usuarios = Usuario;
            Models.ProspectoNota dbProspectoNota = APProspectoNota.ProspectoNota_Agregar(prospectoNota);
            return Json(dbProspectoNota);
        }

        [HttpPost]
        public JsonResult Prospecto_EliminarNota(Models.ProspectoNota prospectoNota, Application.ProspectoNota APprospectoNota)
        {
            prospectoNota.Usuarios = Usuario;
            Models.ProspectoNota DBVacante = APprospectoNota.Prospecto_EliminarNota(prospectoNota);
            return Json(DBVacante);
        }


        //Vacantes.Prospecto_Actualizar_nota


        [HttpPost]
        public JsonResult Prospecto_Actualizar_nota(Models.ProspectoNota prospectoNota, Application.ProspectoNota APPprospectoNota)
        {
            Models.ProspectoNota R = new Models.ProspectoNota();

            prospectoNota.Usuarios = Usuario;
            R = APPprospectoNota.Prospecto_Actualizar_nota(prospectoNota);
            return Json(R);
        }

    }
}
