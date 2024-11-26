using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class VacanteNotaController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        [HttpPost]
        public JsonResult Nota_VacanteNota_Agregar(Models.VacanteNota vacanteNota, Application.VacanteNota APVacanteNota)
        {
            vacanteNota.Usuarios = Usuario;
            Models.VacanteNota dbNota = APVacanteNota.VacanteNota_Agregar(vacanteNota);
            return Json(dbNota);
        }

        [HttpPost]
        public JsonResult Nota_Eliminar_Id(Models.VacanteNota vacanteNota, Application.VacanteNota APVacanteNota)
        {
            vacanteNota.Usuarios = Usuario;
            Models.VacanteNota DBVacante = APVacanteNota.Vacante_EliminarNota(vacanteNota);
            return Json(DBVacante);
        }
    }
}
