using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ClientesController : Controller
    {
        [HttpPost]
        public JsonResult Cat_Clientes_Listar_IdEmpresa(Models.Empresas empresas, Application.Cat_Clientes APCat_Clientes)
        {
            List<Models.Cat_Clientes> Clientes = APCat_Clientes.Cat_Clientes_Seleccionar_IdEmpresa(empresas);
            return Json(Clientes);
        }

        [HttpPost]
        public JsonResult Clientes_Listar(Application.Cat_Clientes APCat_Clientes)
        {
            List<Models.Cat_Clientes> Clientes = APCat_Clientes.Cat_Clientes_Seleccionar();
            return Json(Clientes);
        }

        [HttpPost]
        public JsonResult Clientes_Agregar(Models.Cat_Clientes cat_Clientes, Application.Cat_Clientes APCat_Clientes)
        {
            Models.Cat_Clientes DBClientes = APCat_Clientes.Cat_Clientes_Agregar(cat_Clientes);
            return Json(DBClientes);
        }
    }
}
