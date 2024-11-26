using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class CentroTrabajoController : Controller
    {
        [HttpPost]
        public JsonResult CentroTrabajo_Agregar(Models.ClienteDireciones clienteDireciones, Application.ClienteDireciones APclienteDireciones)
        {
            Models.ClienteDireciones DBClienteDireciones = APclienteDireciones.ClienteDirecciones_Agregar(clienteDireciones);
            return Json(DBClienteDireciones);
        }

        [HttpPost]
        public JsonResult CentroTrabajo_Listar(Models.Cat_Clientes cat_Clientes, Application.ClienteDireciones APclienteDireciones)
        {
            List<Models.ClienteDireciones> DBClienteDireciones = APclienteDireciones.ClienteDirecciones_Seleccionar_IdCliente(cat_Clientes);
            return Json(DBClienteDireciones);
        }


    }
}
