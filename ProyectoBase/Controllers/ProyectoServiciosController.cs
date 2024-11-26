using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProyectoServiciosController : Controller
    {
        [HttpPost]
        public JsonResult ProyectoServicios_Listar(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.Cat_ProyectoServicios APcat_ProyectoServicios)
        {
            List<Models.Cat_ProyectoServicios> proyectoServicios = APcat_ProyectoServicios.Cat_ProyectoServicios_Seleccionar(cat_ProyectoServicios);
            return Json(proyectoServicios);
        }

        [HttpPost]
        public JsonResult ProyectoServicios_Agregar(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.Cat_ProyectoServicios APcat_ProyectoServicios)
        {
            Models.Cat_ProyectoServicios DBProyectoServicios = APcat_ProyectoServicios.Cat_ProyectoServicios_Agregar(cat_ProyectoServicios);
            return Json(DBProyectoServicios);
        }

        [HttpPost]
        public JsonResult ProyectoServicios_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes, Application.Cat_ProyectoServicios APCat_ProyectoServicios)
        {
            List<Models.Cat_ProyectoServicios> cat_ProyectoServicios = APCat_ProyectoServicios.Cat_ProyectoServicios_Seleccionar_IdCliente(cat_Clientes);
            return Json(cat_ProyectoServicios);
        }
    }
}
