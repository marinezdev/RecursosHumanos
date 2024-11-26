using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ClaveMovimientoController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ClaveMovimiento_Agregar(Models.ClaveMovimiento claveMovimiento, Application.ClaveMovimiento APclaveMovimiento)
        {
            claveMovimiento.Usuarios = Usuarios;
            Models.ClaveMovimiento DBClaveMovimiento = APclaveMovimiento.ClaveMovimiento_Agregar(claveMovimiento);
            return Json(DBClaveMovimiento);
        }
    }
}
