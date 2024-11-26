using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class DiplomadosController : Controller
    {
        [HttpPost]
        public JsonResult Cat_Diplomados_Agregar(Models.Cat_Diplomados cat_Diplomados, Application.Cat_Diplomados ApDiplomados)
        {
            Models.Cat_Diplomados Diplomados = ApDiplomados.Cat_Diplomados_Agregar(cat_Diplomados);
            return Json(Diplomados);
        }

        [HttpPost]
        public JsonResult Cat_Diplomados_Listar(Application.Cat_Diplomados ApDiplomados)
        {
            List<Models.Cat_Diplomados> Diplomados = ApDiplomados.Cat_Diplomados_Seleccionar();
            return Json(Diplomados);
        }

        [HttpPost]
        public JsonResult Diplomados_NuevoEmpleado_agregar(Models.PersonasDiplomados personasDiplomados, Application.Control_Archivos APcontrol_Archivos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            List<Models.PersonasDiplomados> ListaPersonasDiplomados = new List<Models.PersonasDiplomados>();
            personasDiplomados.Id = APcontrol_Archivos.Entrevistas_NuevoId().Id;

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            if (personasCDC.PersonasDiplomados is null)
            {
                ListaPersonasDiplomados.Add(personasDiplomados);
            }
            else
            {
                ListaPersonasDiplomados = personasCDC.PersonasDiplomados;
                ListaPersonasDiplomados.Add(personasDiplomados);
            }

            ListaPersonasDiplomados.Sort((x, y) => string.Compare(x.Cat_Diplomados.Nombre, y.Cat_Diplomados.Nombre));
            personasCDC.PersonasDiplomados = ListaPersonasDiplomados;
            Session["ListaCDC"] = personasCDC;

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_NuevoEmpleado_Actualizar(Models.PersonasDiplomados personasDiplomados)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasDiplomados.Count; i++)
            {
                if (personasCDC.PersonasDiplomados[i].Id == personasDiplomados.Id)
                {
                    personasCDC.PersonasDiplomados[i].NmArchivo = personasDiplomados.NmArchivo;
                    personasCDC.PersonasDiplomados[i].NmOriginal = personasDiplomados.NmOriginal;
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_NuevoEmpleado_Eliminar_Archivo(Models.PersonasDiplomados personasDiplomados)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasDiplomados.Count; i++)
            {
                if (personasCDC.PersonasDiplomados[i].Id == personasDiplomados.Id)
                {
                    personasCDC.PersonasDiplomados[i].NmArchivo = null;
                    personasCDC.PersonasDiplomados[i].NmOriginal = null;
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_NuevoEmpleado_Mostrar(Models.PersonasDiplomados personasDiplomados)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasDiplomados.Count; i++)
            {
                if (personasCDC.PersonasDiplomados[i].Id == personasDiplomados.Id)
                {
                    personasDiplomados.NmArchivo = personasCDC.PersonasDiplomados[i].NmArchivo;
                }
            }
            personasDiplomados.NmArchivo = DirectorioURL + personasDiplomados.NmArchivo;
            return Json(personasDiplomados);
        }

        [HttpPost]
        public JsonResult Diplomados_NuevoEmpleado_Eliminar(Models.PersonasDiplomados personasDiplomados)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasDiplomados.Count; i++)
            {
                if (personasCDC.PersonasDiplomados[i].Id == personasDiplomados.Id)
                {
                    personasCDC.PersonasDiplomados.Remove(personasCDC.PersonasDiplomados[i]);
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_EditarEmpleado_agregar(Models.PersonasDiplomados personasDiplomados, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasDiplomado.PersonasDiplomado_Agregar(personasDiplomados);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasDiplomados.Personas); ;

            return Json(personasCDC);
        }
        [HttpPost]
        public JsonResult Diplomados_EditarEmpleado_Eliminar(Models.PersonasDiplomados personasDiplomados, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasDiplomado.PersonasDiplomado_Eliminar(personasDiplomados);
            
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasDiplomados.Personas); ;

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_EditarEmpleado_Actualizar(Models.PersonasDiplomados personasDiplomados, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasDiplomado.PersonasDiplomados_Editar_ActualizarArchivo(personasDiplomados);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasDiplomados.Personas); ;

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_EditarEmpleado_Eliminar_Archivo(Models.PersonasDiplomados personasDiplomados, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasDiplomado.PersonasDiplomados_Editar_EliminarArchivo(personasDiplomados);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasDiplomados.Personas);
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasDiplomados.Personas); ;

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Diplomados_EditarEmpleado_Mostrar(Models.PersonasDiplomados personasDiplomados, Application.PersonasDiplomado APpersonasDiplomado)
        {
            Models.PersonasDiplomados personasDiplomados1 = APpersonasDiplomado.PersonasDiplomados_Editar_Selecionar_Id(personasDiplomados);
            string DirectorioURL = "";
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + personasDiplomados1.NmArchivo;
            return Json(DirectorioURL);
        }
    }
}
