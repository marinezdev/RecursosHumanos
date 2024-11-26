using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(Application.Usuarios usuarios)
        {
            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (Usuairo != null)
            {
                switch (Usuairo.IdRol)
                {
                    case 1:
                        // code block
                        return RedirectToAction("Index", "Administracion");
                    //case 2:
                    //    // code block
                    //    return RedirectToAction("PrincipalA", "Home");
                    //case 3:
                    //    // code block
                    //    return RedirectToAction("PrincipalA", "Home");
                    default:
                        // code block
                        break;
                }
            }

            ViewBag.rd = Request.QueryString["rd"];
            ViewBag.rdv = Request.QueryString["rdv"];
            return View();
        }

        [HttpPost]
        public JsonResult IniciarSesion(Models.NuevoRegistro NuevoUsuario, Application.Usuarios usuario, Application.Menu menu)
        {
            if (NuevoUsuario != null)
            {
                Models.Usuarios DataUser = usuario.Iniciar(NuevoUsuario.usuarios);
                if (DataUser.Id > 0)
                {
                    Session["Sesion"] = DataUser;

                    if (NuevoUsuario.usuarios.Session)
                    {
                        Response.Cookies["SesionDT"].Value = Application.UrlCifrardo.Encrypt(DataUser.ClaveCoo);
                    }
                }

                if (!String.IsNullOrEmpty(NuevoUsuario.usuarios.Ruta))
                {
                    string url = Application.UrlCifrardo.Decrypt(NuevoUsuario.usuarios.Ruta);
                    if (menu.ValidacionPagina(DataUser, url))
                    {
                        string Nu = Application.UrlCifrardo.Decrypt(NuevoUsuario.usuarios.RutaAcceso);
                        DataUser.RutaAcceso = Nu;
                    }
                }

                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }

        [HttpPost]
        public JsonResult CerrarSesion()
        {
            Models.Usuarios DataUser = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Response.Cookies["SesionDT"].Value = null;

            Session.Abandon();

            if (DataUser != null)
            {
                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }
    }
}