using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class VacanteConsultaController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Application.Menu menu = new Application.Menu();
        // GET: VacanteConsulta
        public ActionResult Index(Application.Vacante APvacante, Application.Empresas APempresas)
        {
            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Vacante> dbUsuarios = APvacante.Vacante_Seleccionar_Usuarios();
                List<Models.Empresas> Empresas = APempresas.Empresas_Seleccionar();

                ViewBag.Usuarios = dbUsuarios;
                ViewBag.Empresas = Empresas;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult Consulta(Application.Vacante APvacante)
        {
            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Cat_EstatusVacante> LisvacanteEstatus = APvacante.Vacante_Estatus_Seleccionar();
                List<Models.Cat_Clientes> LisvacanteClientes = APvacante.Vacante_Clientes_Seleccionar();
                List<Models.Cat_EstatusProspecto> LisProspectoEstatus = APvacante.Vacante_Estatus_Prospectos();
                List<Models.Vacante> dbVacantes = APvacante.Vacante_Seleccionar_Reporte();

                ViewBag.VacanteEstatus = LisvacanteEstatus;
                ViewBag.VacanteClientes = LisvacanteClientes;
                ViewBag.EstatusProspectos = LisProspectoEstatus;
                ViewBag.Vacantes = dbVacantes;
                ViewBag.Usuario = Usuario;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }
    }
}
