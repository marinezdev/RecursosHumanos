using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class AplicacionesController : Controller
    {
        // GET: Aplicaciones
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: AccesoAplicaciones
        public ActionResult Index(Application.Menu menu, Application.Cat_Aplicaciones APcat_Aplicaciones, Application.Empresas APempresas)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Cat_Aplicaciones> cat_Aplicaciones = APcat_Aplicaciones.Cat_Aplicaciones_Seleccionar();
                ViewBag.Aplicaciones = cat_Aplicaciones;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Aplicaciones_Agregar(Models.Cat_Aplicaciones cat_Aplicaciones, Application.Cat_Aplicaciones APcat_Aplicaciones)
        {
            Models.Cat_Aplicaciones DBAplicacion = APcat_Aplicaciones.Cat_Aplicaciones_Agregar(cat_Aplicaciones);
            return Json(DBAplicacion);
        }

        [HttpPost]
        public JsonResult Aplicaciones_Eliminar(Models.Cat_Aplicaciones cat_Aplicaciones, Application.Cat_Aplicaciones APcat_Aplicaciones)
        {
            Models.Cat_Aplicaciones DBAplicaciones = APcat_Aplicaciones.Cat_Aplicaciones_Elimnar(cat_Aplicaciones);
            return Json(DBAplicaciones);
        }

        [HttpPost]
        public JsonResult Aplicaciones_NuevoEmpleado_Lista_Default(Models.EmpresaPuestos empresaPuestos, Application.PuestoAplicacion APpuestoAplicacion)
        {
            List<Models.PersonasAplicaciones> ListPersonasAplicaciones = new List<Models.PersonasAplicaciones>();
            List<Models.PuestoAplicacion> puestoAplicacions = APpuestoAplicacion.PuestoAplicacion_Seleccionar_IdPuesto(empresaPuestos);

            if (puestoAplicacions[0].Id > -1)
            {
                foreach (var PuestoAplicacion in puestoAplicacions)
                {
                    Models.PersonasAplicaciones personaAplicacion = new Models.PersonasAplicaciones();
                    personaAplicacion.Cat_Aplicaciones = PuestoAplicacion.Cat_Aplicaciones;
                    ListPersonasAplicaciones.Add(personaAplicacion);
                }
                ListPersonasAplicaciones.Sort((x, y) => string.Compare(x.Cat_Aplicaciones.Nombre, y.Cat_Aplicaciones.Nombre));
                Session["ListaAplicaciones"] = ListPersonasAplicaciones;
            }
            return Json(ListPersonasAplicaciones);
        }

        [HttpPost]
        public JsonResult Aplicaciones_NuevoEmpleado_Eliminar(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            List<Models.PersonasAplicaciones> LstPersonasAplicaciones = new List<Models.PersonasAplicaciones>();

            if (Session["ListaAplicaciones"] != null)
            {
                LstPersonasAplicaciones = (List<Models.PersonasAplicaciones>)Session["ListaAplicaciones"];
            }

            for (int i = 0; i < LstPersonasAplicaciones.Count; i++)
            {
                if (LstPersonasAplicaciones[i].Cat_Aplicaciones.Id == cat_Aplicaciones.Id)
                {
                    LstPersonasAplicaciones.Remove(LstPersonasAplicaciones[i]);
                }
            }

            LstPersonasAplicaciones.Sort((x, y) => string.Compare(x.Cat_Aplicaciones.Nombre, y.Cat_Aplicaciones.Nombre));
            Session["ListaAplicaciones"] = LstPersonasAplicaciones;

            return Json(LstPersonasAplicaciones);
        }

        [HttpPost]
        public JsonResult Aplicaciones_NuevoEmpleado_Agregar(Models.Cat_Aplicaciones cat_Aplicaciones, Application.Cat_Aplicaciones APCat_Aplicaciones)
        {
            List<Models.PersonasAplicaciones> LstPersonasAplicaciones = new List<Models.PersonasAplicaciones>();

            if (Session["ListaAplicaciones"] != null)
            {
                LstPersonasAplicaciones = (List<Models.PersonasAplicaciones>)Session["ListaAplicaciones"];
            }

            bool Agregar = false;
            for (int i = 0; i < LstPersonasAplicaciones.Count; i++)
            {
                if (LstPersonasAplicaciones[i].Cat_Aplicaciones.Id == cat_Aplicaciones.Id)
                {
                    Agregar = true;
                }
            }

            if (!Agregar)
            {
                Models.PersonasAplicaciones personaAplicacion = new Models.PersonasAplicaciones();
                Models.Cat_Aplicaciones cat_Aplicaciones1 = APCat_Aplicaciones.Cat_Aplicaciones_Seleccionar_Id(cat_Aplicaciones);
                personaAplicacion.Cat_Aplicaciones = cat_Aplicaciones1;
                LstPersonasAplicaciones.Add(personaAplicacion);
            }

            LstPersonasAplicaciones.Sort((x, y) => string.Compare(x.Cat_Aplicaciones.Nombre, y.Cat_Aplicaciones.Nombre));
            Session["ListaAplicaciones"] = LstPersonasAplicaciones;

            return Json(LstPersonasAplicaciones);
        }

        [HttpPost]
        public JsonResult Aplicaciones_Editar_Eliminar(Models.PersonasAplicaciones personasAplicaciones, Application.PersonasAplicaciones APpersonasAplicaciones)
        {
            Models.PersonasAplicaciones DBPersonaAplicacion = APpersonasAplicaciones.PersonasAplicaciones_Eliminar(personasAplicaciones);
            return Json(DBPersonaAplicacion);
        }

        [HttpPost]
        public JsonResult Aplicaciones_Editar_Agregar(Models.PersonasAplicaciones personasAplicaciones, Application.PersonasAplicaciones APpersonasAplicaciones)
        {
            Models.PersonasAplicaciones DBPersonaAplicacion = APpersonasAplicaciones.PersonasAplicaciones_Agregar(personasAplicaciones);
            return Json(DBPersonaAplicacion);
        }

        [HttpPost]
        public JsonResult Aplicaciones_Editar_Listar(Models.Personas personas, Application.PersonasAplicaciones APpersonasAplicaciones)
        {
            List<Models.PersonasAplicaciones> DBPersonaAplicacion = APpersonasAplicaciones.PersonasAplicaciones_Seleccionar_IdPersona(personas);
            return Json(DBPersonaAplicacion);
        }




    }
}
