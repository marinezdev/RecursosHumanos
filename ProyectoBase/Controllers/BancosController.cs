using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class BancosController : Controller
    {
        [HttpPost]
        public JsonResult Cat_Banco_Agregar(Models.Cat_Banco cat_Banco, Application.Cat_Banco ApCatBanco)
        {
            Models.Cat_Banco Banco = ApCatBanco.Cat_Banco_Agregar(cat_Banco);
            return Json(Banco);
        }

        [HttpPost]
        public JsonResult Cat_Banco_Listar(Application.Cat_Banco ApCatBanco)
        {
            List<Models.Cat_Banco> Bancos = ApCatBanco.Cat_Banco_Selecionar_Listar();
            return Json(Bancos);
        }
    }
}
