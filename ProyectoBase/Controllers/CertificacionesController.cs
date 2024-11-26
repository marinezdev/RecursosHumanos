using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class CertificacionesController : Controller
    {
        [HttpPost]
        public JsonResult Cat_Certificaciones_Agregar(Models.Cat_Certificaciones cat_Certificaciones, Application.Cat_Certificaciones ApCertificaciones)
        {
            Models.Cat_Certificaciones Certificaciones = ApCertificaciones.Cat_Diplomados_Agregar(cat_Certificaciones);
            return Json(Certificaciones);
        }

        [HttpPost]
        public JsonResult Cat_Certificaciones_Listar(Application.Cat_Certificaciones ApCat_Certificaciones)
        {
            List<Models.Cat_Certificaciones> Certificaciones = ApCat_Certificaciones.Cat_Certificaciones_Seleccionar();
            return Json(Certificaciones);
        }

        [HttpPost]
        public JsonResult Certificaciones_NuevoEmpleado_agregar(Models.PersonasCertificacion personasCertificaciones, Application.Control_Archivos APcontrol_Archivos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            List<Models.PersonasCertificacion> ListaPersonasCertificaciones = new List<Models.PersonasCertificacion>();
            personasCertificaciones.Id = APcontrol_Archivos.Entrevistas_NuevoId().Id;

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            if (personasCDC.PersonasCertificaciones is null)
            {
                ListaPersonasCertificaciones.Add(personasCertificaciones);
            }
            else
            {
                ListaPersonasCertificaciones = personasCDC.PersonasCertificaciones;
                ListaPersonasCertificaciones.Add(personasCertificaciones);
            }

            ListaPersonasCertificaciones.Sort((x, y) => string.Compare(x.Cat_Certificaciones.Nombre, y.Cat_Certificaciones.Nombre));
            personasCDC.PersonasCertificaciones = ListaPersonasCertificaciones;
            Session["ListaCDC"] = personasCDC;

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_NuevoEmpleado_Actualizar(Models.PersonasCertificacion personasCertificacion)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCertificaciones.Count; i++)
            {
                if (personasCDC.PersonasCertificaciones[i].Id == personasCertificacion.Id)
                {
                    personasCDC.PersonasCertificaciones[i].NmArchivo = personasCertificacion.NmArchivo;
                    personasCDC.PersonasCertificaciones[i].NmOriginal = personasCertificacion.NmOriginal;
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_NuevoEmpleado_Eliminar_Archivo(Models.PersonasCertificacion personasCertificacion)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCertificaciones.Count; i++)
            {
                if (personasCDC.PersonasCertificaciones[i].Id == personasCertificacion.Id)
                {
                    personasCDC.PersonasCertificaciones[i].NmArchivo = null;
                    personasCDC.PersonasCertificaciones[i].NmOriginal = null;
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_NuevoEmpleado_Mostrar(Models.PersonasCertificacion personasCertificacion)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCertificaciones.Count; i++)
            {
                if (personasCDC.PersonasCertificaciones[i].Id == personasCertificacion.Id)
                {
                    personasCertificacion.NmArchivo = personasCDC.PersonasCertificaciones[i].NmArchivo;
                }
            }
            personasCertificacion.NmArchivo = DirectorioURL + personasCertificacion.NmArchivo;
            return Json(personasCertificacion);
        }

        [HttpPost]
        public JsonResult Certificaciones_NuevoEmpleado_Eliminar(Models.PersonasCertificacion personasCertificacion)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCertificaciones.Count; i++)
            {
                if (personasCDC.PersonasCertificaciones[i].Id == personasCertificacion.Id)
                {
                    personasCDC.PersonasCertificaciones.Remove(personasCDC.PersonasCertificaciones[i]);
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_EditarEmpleado_agregar(Models.PersonasCertificacion personasCertificaciones, Application.PersonasCertificaciones APpersonasCertificaciones, 
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCertificaciones.PersonasCertificacion_Agregar(personasCertificaciones);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCertificaciones.Personas); ;
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCertificaciones.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCertificaciones.Personas);

            return Json(personasCDC);
        }
        [HttpPost]
        public JsonResult Certificaciones_EditarEmpleado_Eliminar(Models.PersonasCertificacion personasCertificaciones, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCertificaciones.PersonasCertificacion_Eliminar(personasCertificaciones);
           
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCertificaciones.Personas); ;
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCertificaciones.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCertificaciones.Personas);

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_EditarEmpleado_Actualizar(Models.PersonasCertificacion personasCertificaciones, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCertificaciones.PersonasCertificacion_Editar_ActualizarArchivo(personasCertificaciones);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCertificaciones.Personas); ;
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCertificaciones.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCertificaciones.Personas);

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_EditarEmpleado_Eliminar_Archivo(Models.PersonasCertificacion personasCertificaciones, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCertificaciones.PersonasCertificacion_Editar_EliminarArchivo(personasCertificaciones);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCertificaciones.Personas); ;
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCertificaciones.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCertificaciones.Personas);

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Certificaciones_EditarEmpleado_Mostrar(Models.PersonasCertificacion personasCertificaciones, Application.PersonasCertificaciones APpersonasCertificaciones)
        {
            Models.PersonasCertificacion personasCertificaciones1 = APpersonasCertificaciones.PersonasCertificacion_Editar_Selecionar_Id(personasCertificaciones);
            string DirectorioURL = "";
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + personasCertificaciones1.NmArchivo;
            return Json(DirectorioURL);
        }
    }
}
