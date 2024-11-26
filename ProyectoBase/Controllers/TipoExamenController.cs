using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class TipoExamenController : Controller
    {
        [HttpPost]
        public JsonResult Cat_TipoExamen_Listar(Application.Cat_TipoExamen ApCatTipoExamen)
        {
            List<Models.Cat_TipoExamen> TipoExamen = ApCatTipoExamen.Cat_TipoExamen_Seleccionar();
            return Json(TipoExamen);
        }

        [HttpPost]
        public JsonResult Cat_TipoExamen_Agregar(Models.Cat_TipoExamen cat_TipoExamen, Application.Cat_TipoExamen ApCatTipoExamen)
        {
            Models.Cat_TipoExamen DBtipoExamen = ApCatTipoExamen.Cat_TipoExamen_Agregar(cat_TipoExamen);
            return Json(DBtipoExamen);
        }
    }
}
