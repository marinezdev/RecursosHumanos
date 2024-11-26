using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class VacanteBitacoraController : Controller
    {
        [HttpPost]
        public JsonResult VacanteBitacora_Seleccionar_IdVacante(Models.Vacante vacante, Application.VacanteBitacora APVacanteBitacora)
        {
            List<Models.VacanteBitacora> DBVacanteBitacora = APVacanteBitacora.VacanteBitacora_Seleccionar_IdVacante(vacante);
            return Json(DBVacanteBitacora);
        }
    }
}
