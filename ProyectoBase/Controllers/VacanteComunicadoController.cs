using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class VacanteComunicadoController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult VacanteComunicado_Agregar(Models.VacanteComunicado vacanteComunicado, Application.VacanteComunicado APVacanteComunicado)
        {
            vacanteComunicado.Usuarios = Usuario;
            Models.VacanteComunicado dbvacanteComunicado = APVacanteComunicado.VacanteComunicado_Agregar(vacanteComunicado);
            return Json(dbvacanteComunicado);
        }
    }
}
