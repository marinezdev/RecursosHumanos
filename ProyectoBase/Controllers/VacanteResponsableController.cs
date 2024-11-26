using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class VacanteResponsableController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        [HttpPost]
        public JsonResult VacanteResponsable_Agregar(Models.VacanteResponsable vacanteResponsable, Application.VacanteResponsable APVacanteResponsable)
        {
            vacanteResponsable.Usuarios = Usuario;
            Models.VacanteResponsable dbVacanteResponsable = APVacanteResponsable.VacanteResponsable_Agregar(vacanteResponsable);
            return Json(dbVacanteResponsable);
        }

        [HttpPost]
        public JsonResult VacanteResponsable_Eliminar(Models.VacanteResponsable VacanteResponsable, Application.VacanteResponsable APPVacanteResponsable)
        {
            VacanteResponsable.Usuarios = Usuario;
            Models.VacanteResponsable DBVacante = APPVacanteResponsable.VacanteResponsable_Eliminar(VacanteResponsable);
            return Json(DBVacante);
        }
    }
}
