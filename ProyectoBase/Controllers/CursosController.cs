using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class CursosController : Controller
    {
        [HttpPost]
        public JsonResult Cat_Cursos_Agregar(Models.Cat_Cursos cat_Cursos, Application.Cat_Cursos ApCursos)
        {
            Models.Cat_Cursos Cursos = ApCursos.Cat_Cursos_Agregar(cat_Cursos);
            return Json(Cursos);
        }

        [HttpPost]
        public JsonResult Cat_Cursos_Listar(Application.Cat_Cursos ApCursos)
        {
            List<Models.Cat_Cursos> Cursos = ApCursos.Cat_Cursos_Seleccionar();
            return Json(Cursos);
        }

        [HttpPost]
        public JsonResult Cursos_NuevoEmpleado_agregar(Models.PersonasCursos personasCursos, Application.Control_Archivos APcontrol_Archivos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            List<Models.PersonasCursos> ListaPersonasCursos = new List<Models.PersonasCursos>();
            personasCursos.Id = APcontrol_Archivos.Entrevistas_NuevoId().Id;

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            if(personasCDC.PersonasCursos is null)
            {
                ListaPersonasCursos.Add(personasCursos);
            }
            else
            {
                ListaPersonasCursos = personasCDC.PersonasCursos;
                ListaPersonasCursos.Add(personasCursos);
            }

            ListaPersonasCursos.Sort((x, y) => string.Compare(x.Cat_Cursos.Nombre, y.Cat_Cursos.Nombre));
            personasCDC.PersonasCursos = ListaPersonasCursos;
            Session["ListaCDC"] = personasCDC;

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_NuevoEmpleado_Actualizar(Models.PersonasCursos personasCursos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCursos.Count; i++)
            {
                if (personasCDC.PersonasCursos[i].Id == personasCursos.Id)
                {
                    personasCDC.PersonasCursos[i].NmArchivo = personasCursos.NmArchivo;
                    personasCDC.PersonasCursos[i].NmOriginal = personasCursos.NmOriginal;
                }
            }
            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_NuevoEmpleado_Eliminar_Archivo(Models.PersonasCursos personasCursos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCursos.Count; i++)
            {
                if (personasCDC.PersonasCursos[i].Id == personasCursos.Id)
                {
                    personasCDC.PersonasCursos[i].NmArchivo = null;
                    personasCDC.PersonasCursos[i].NmOriginal = null;
                }
            }
            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_NuevoEmpleado_Mostrar(Models.PersonasCursos personasCursos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";

            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCursos.Count; i++)
            {
                if (personasCDC.PersonasCursos[i].Id == personasCursos.Id)
                {
                    personasCursos.NmArchivo = personasCDC.PersonasCursos[i].NmArchivo;
                }
            }
            personasCursos.NmArchivo = DirectorioURL + personasCursos.NmArchivo;
            return Json(personasCursos);
        }

        [HttpPost]
        public JsonResult Cursos_NuevoEmpleado_Eliminar(Models.PersonasCursos personasCursos)
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }

            for (int i = 0; i < personasCDC.PersonasCursos.Count; i++)
            {
                if (personasCDC.PersonasCursos[i].Id == personasCursos.Id)
                {
                    personasCDC.PersonasCursos.Remove(personasCDC.PersonasCursos[i]);
                }
            }

            Session["ListaCDC"] = personasCDC;
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_EditarEmpleado_agregar(Models.PersonasCursos personasCursos, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCursos.PersonasCursos_Agregar(personasCursos);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCursos.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCursos.Personas); ;
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCursos.Personas);

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_EditarEmpleado_Eliminar(Models.PersonasCursos personasCursos, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCursos.PersonasCursos_Eliminar(personasCursos);
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCursos.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCursos.Personas); ;
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCursos.Personas);

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_EditarEmpleado_Actualizar(Models.PersonasCursos personasCursos, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCursos.PersonasCursos_Editar_ActualizarArchivo(personasCursos);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCursos.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCursos.Personas); ;
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCursos.Personas);

            return Json(personasCDC);
        }
        
        [HttpPost]
        public JsonResult Cursos_EditarEmpleado_Eliminar_Archivo(Models.PersonasCursos personasCursos, Application.PersonasCertificaciones APpersonasCertificaciones,
            Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado)
        {
            APpersonasCursos.PersonasCursos_Editar_EliminarArchivo(personasCursos);

            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personasCursos.Personas);
            personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(personasCursos.Personas); ;
            personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personasCursos.Personas);

            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Cursos_EditarEmpleado_Mostrar(Models.PersonasCursos personasCursos, Application.PersonasCursos APpersonasCursos)
        {
            Models.PersonasCursos personaCursos1 = APpersonasCursos.PersonasCursos_Editar_Selecionar_Id(personasCursos);
            string DirectorioURL = "";
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + personaCursos1.NmArchivo;
            return Json(DirectorioURL);
        }

    }
}
