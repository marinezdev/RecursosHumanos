using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Consulta_Empresas(Application.Empresas APempresas)
        {
            List<Models.Empresas> empresas = APempresas.Empresas_Seleccionar();
            return Json(empresas);
        }

        [HttpPost]
        public JsonResult Empresas_Agregar(Models.Empresas empresas, Application.Empresas APempresas)
        {
            Models.Empresas Dtempresas = APempresas.Empresas_Agregar(empresas);
            return Json(Dtempresas);
        }

        [HttpPost]
        public JsonResult Consulta_Departamentos(Models.Empresas empresas, Application.EmpresasDepartamento APempresasDepartamento)
        {
            List<Models.EmpresasDepartamento> departamentos = APempresasDepartamento.EmpresasDepartamento_Seleccionar(empresas);
            return Json(departamentos);
        }

        [HttpPost]
        public JsonResult EmpresasDepartamento_Agregar(Models.EmpresasDepartamento empresasDepartamento, Application.EmpresasDepartamento APempresasDepartamento)
        {
            Models.EmpresasDepartamento departamento = APempresasDepartamento.EmpresasDepartamento_Agregar(empresasDepartamento);
            return Json(departamento);
        }

        [HttpPost]
        public JsonResult Consulta_Puestos(Models.EmpresasDepartamento empresasDepartamento, Application.EmpresaPuestos APempresaPuestos)
        {
            List<Models.EmpresaPuestos> puestos = APempresaPuestos.EmpresaPuestos_Seleccionar(empresasDepartamento);
            return Json(puestos);
        }

        [HttpPost]
        public JsonResult EmpresaPuestos_Agregar(Models.EmpresaPuestos empresaPuestos, Application.EmpresaPuestos APempresaPuestos)
        {
            Models.EmpresaPuestos puesto = APempresaPuestos.EmpresaPuestos_Agregar(empresaPuestos);
            return Json(puesto);
        }

    }
}
