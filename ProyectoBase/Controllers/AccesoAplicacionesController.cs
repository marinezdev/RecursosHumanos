using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class AccesoAplicacionesController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: AccesoAplicaciones
        public ActionResult Index(Application.Menu menu, Application.Cat_Aplicaciones APcat_Aplicaciones, Application.Empresas APempresas)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Cat_Aplicaciones> cat_Aplicaciones = APcat_Aplicaciones.Cat_Aplicaciones_Seleccionar();
                List<Models.Empresas> Empresas = APempresas.Empresas_Seleccionar();
                ViewBag.Aplicaciones = cat_Aplicaciones;
                ViewBag.Empresas = Empresas;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult AccesoAplicaciones_Listar(Models.EmpresaPuestos empresaPuestos, Application.PuestoAplicacion APpuestoAplicacion)
        {
            List<Models.PuestoAplicacion> AplicacionesPuesto = APpuestoAplicacion.PuestoAplicacion_Seleccionar_IdPuesto(empresaPuestos);
            return Json(AplicacionesPuesto);
        }

        [HttpPost]
        public JsonResult AccesoAplicaciones_Agregar(Models.PuestoAplicacion puestoAplicacion, Application.PuestoAplicacion APpuestoAplicacion)
        {
            Models.PuestoAplicacion AplicacionPuesto = APpuestoAplicacion.PuestoAplicacion_Agregar(puestoAplicacion);
            return Json(AplicacionPuesto);
        }

        [HttpPost]
        public JsonResult AccesoAplicaciones_Eliminar(Models.PuestoAplicacion puestoAplicacion, Application.PuestoAplicacion APpuestoAplicacion)
        {
            Models.PuestoAplicacion AplicacionPuesto = APpuestoAplicacion.PuestoAplicacion_Elimnar(puestoAplicacion);
            return Json(AplicacionPuesto);
        }
        
    }
}
