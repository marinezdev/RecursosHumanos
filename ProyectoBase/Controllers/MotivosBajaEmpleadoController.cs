using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class MotivosBajaEmpleadoController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        // GET: MotivosBajaEmpleado
        public ActionResult Index(Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado, Application.Menu menu)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleados = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();
                ViewBag.MotivosBajaEmpleados = cat_MotivosBajaEmpleados;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult MotivosBajaEmpleado_Eliminar(Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado)
        {
            Models.Cat_MotivosBajaEmpleado DBMotivosBajaEmpleado = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Elimnar(cat_MotivosBajaEmpleado);
            return Json(DBMotivosBajaEmpleado);
        }

        [HttpPost]
        public JsonResult MotivosBajaEmpleado_Agregar(Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado)
        {
            Models.Cat_MotivosBajaEmpleado DBMotivosBajaEmpleado = APcat_MotivosBajaEmpleado.MotivosBajaEmpleado_Agregar(cat_MotivosBajaEmpleado);
            return Json(DBMotivosBajaEmpleado);
        }

    }
}
