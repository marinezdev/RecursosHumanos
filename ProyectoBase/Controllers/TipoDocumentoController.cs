using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class TipoDocumentoController : Controller
    {
        [HttpPost]
        public JsonResult Cat_TipoDocumento_Agregar(Models.Cat_TipoDocumento cat_TipoDocumento, Application.Cat_TipoDocumento APtipoDocumento)
        {
            Models.Cat_TipoDocumento DBTipoDocumento = APtipoDocumento.Cat_TipoDocumento_Agregar(cat_TipoDocumento);
            return Json(DBTipoDocumento);
        }

        [HttpPost]
        public JsonResult Cat_TipoDocumento_Listar(Application.Cat_TipoDocumento ApCatTipoDocumento)
        {
            List<Models.Cat_TipoDocumento> TipoDocumento = ApCatTipoDocumento.Cat_TipoDocumento_Selecionar();
            return Json(TipoDocumento);
        }
    }
}
