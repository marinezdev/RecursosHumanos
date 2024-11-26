using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class DireccionesController : Controller
    {
        // GET: Direcciones
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Consulta_Estados(Application.Cat_Estados cat_Estados)
        {
            List<Models.Cat_Estados> estados = cat_Estados.Cat_Estados_Seleccionar();
            return Json(estados);
        }

        [HttpPost]
        public JsonResult Consulta_DelegacionMunicipio(Models.Cat_Poblacion cat_Poblacion, Application.Cat_Poblacion APcatPoblacion)
        {
            List<Models.Cat_Poblacion> Poblaciones = APcatPoblacion.Cat_Poblaciones_Seleccionar(cat_Poblacion.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_Colonias(Models.Cat_Colonias cat_Colonias, Application.Cat_Colonias APcat_Colonias)
        {
            List<Models.Cat_Colonias> Poblaciones = APcat_Colonias.Cat_Colonias_Seleccionar(cat_Colonias.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_CP(Models.Cat_Colonias cat_Colonias, Application.Cat_CP catCP)
        {
            List<Models.Cat_CP> Poblaciones = catCP.Cat_CP_Seleccionar(cat_Colonias.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult CP_Busqueda(Models.Cat_CP cat_CP, Application.Cat_CP APcatCP)
        {
            List<Models.Direcciones> Poblaciones = APcatCP.Cat_CP_Busqueda(cat_CP.CP);
            return Json(Poblaciones);
        }
    }
}
