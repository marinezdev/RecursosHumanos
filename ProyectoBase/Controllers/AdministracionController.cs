using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class AdministracionController : Controller
    {
        public ActionResult Index(Application.Menu menu, Application.Empleados APempleados, Application.PersonasDocumentos APpersonasDocumentos, Application.Empresas APempresas)
        {
            //try
            //{
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuario, url))
            {
                Models.Consultas.EmpleadosGrafica EmpleadosTotalEmpleados = APempleados.Empleados_Total_Empleados();
                Models.Consultas.EmpleadosGrafica EmpleadosTotalActivos = APempleados.Empleados_Total_Activos();
                Models.Consultas.EmpleadosGrafica EmpleadosTotalInactivos = APempleados.Empleados_Total_Inactivos();
                Models.Consultas.EmpleadosGrafica EmpleadosContratosVencidos = APempleados.Empleados_ContratosVencidos();
                Models.Consultas.EmpleadosGrafica EmpleadosContratosPorVencer = APempleados.Empleados_ContratosPorVencer();
                Models.Consultas.EmpleadosGrafica EmpleadosDocumentosNoentregados = APempleados.Empleados_DocumentosNoentregados();
                Models.Consultas.EmpleadosGrafica EmpleadosDocumentosPendiente = APempleados.Empleados_DocumentosPendiente();
                List<Models.Consultas.EmpleadosGrafica> EmpleadosCliente = APempleados.Empleados_Cliente();
                List<Models.Consultas.EmpleadosGrafica> EmpleadosProyecto = APempleados.Empleados_Proyecto();
                List<Models.Consultas.PersonasDocumento_Procentaje> personasDocumentosPorcentaje = APpersonasDocumentos.PersonasDocumento_Documento_Procentaje();
                Models.Empresas empresas = new Models.Empresas();
                empresas.Id = 1;
                List<Models.Consultas.PersonasDocumento_Procentaje> personasDocumentosPorcentajeAsae = APpersonasDocumentos.PersonasDocumento_Documento_Procentaje_IdEmpresa(empresas);
                empresas.Id = 2;
                List<Models.Consultas.PersonasDocumento_Procentaje> personasDocumentosPorcentajeZaar = APpersonasDocumentos.PersonasDocumento_Documento_Procentaje_IdEmpresa(empresas);
                List<Models.Empresas> Empresas = APempresas.Empresas_Seleccionar();


                ViewBag.Nombre = Usuario.Nombre; 
                ViewBag.Rol = Usuario.NombreRol;

                ViewBag.EmpleadosTotalEmpleados = EmpleadosTotalEmpleados;
                ViewBag.EmpleadosTotalActivos = EmpleadosTotalActivos;
                ViewBag.EmpleadosTotalInactivos = EmpleadosTotalInactivos;
                ViewBag.EmpleadosContratosVencidos = EmpleadosContratosVencidos;
                ViewBag.EmpleadosContratosPorVencer = EmpleadosContratosPorVencer;
                ViewBag.EmpleadosDocumentosNoentregados = EmpleadosDocumentosNoentregados;
                ViewBag.EmpleadosDocumentosPendiente = EmpleadosDocumentosPendiente;
                ViewBag.EmpleadosCliente = EmpleadosCliente;
                ViewBag.EmpleadosProyecto = EmpleadosProyecto;
                ViewBag.DocumentosPorcentaje = personasDocumentosPorcentaje;
                ViewBag.DocumentosPorcentajeAsae = personasDocumentosPorcentajeAsae;
                ViewBag.DocumentosPorcentajeZaar = personasDocumentosPorcentajeZaar;
                ViewBag.Empresas = Empresas;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }

            //}
            //catch
            //{
            //    return RedirectToAction("Index", "Home");
            //}

        }

        [HttpPost]
        public JsonResult Empleados_Cliente_IdEmprea(Models.Empresas empresas, Application.Empleados APempleados)
        {
            List<Models.Consultas.EmpleadosGrafica> _EmpleadosGrafica = new List<Models.Consultas.EmpleadosGrafica>();
            _EmpleadosGrafica = APempleados.Empleados_Cliente_IdEmprea(empresas);
            return Json(_EmpleadosGrafica);
        }

        [HttpPost]
        public JsonResult Empleados_PersonasDocumento_Cliente_Empresas(Models.Empresas empresas, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.Consultas.PersonasDocumento_Clientes> personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Clientes_IdEmpresa(empresas);
            return Json(personasDocumentos1);
        }
    }
}
