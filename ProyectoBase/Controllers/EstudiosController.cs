using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class EstudiosController : Controller
    {
        [HttpPost]
        public JsonResult Estudios_NuevoEmpleado_Agregar(Models.Consultas.PersonaEstudio personaEstudio, Application.Cat_Estudios APcat_Estudios, Application.Cat_EstatusEstudios APcat_EstatusEstudios)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();

            if (Session["LstPersonaEstudio"] != null)
            {
                LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];
            }

            personaEstudio.Cat_Estudios = APcat_Estudios.Cat_Estudios_Selecionar_Id(personaEstudio.Cat_Estudios.Id);
            personaEstudio.Cat_EstatusEstudios = APcat_EstatusEstudios.Cat_EstatusEstudios_Selecionar_Id(personaEstudio.Cat_EstatusEstudios.Id);
            LstPersonaEstudio.Add(personaEstudio);

            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));

            Session["LstPersonaEstudio"] = LstPersonaEstudio;

            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_NuevoEmpleado_Actualizar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();

            if (Session["LstPersonaEstudio"] != null)
            {
                LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];
            }

            LstPersonaEstudio[personaEstudio.Id].NmArchivo = personaEstudio.NmArchivo;
            LstPersonaEstudio[personaEstudio.Id].NmOriginal = personaEstudio.NmOriginal;

            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));

            Session["LstPersonaEstudio"] = LstPersonaEstudio;

            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_NuevoEmpleado_Eliminar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();

            if (Session["LstPersonaEstudio"] != null)
            {
                LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];
            }

            LstPersonaEstudio.Remove(LstPersonaEstudio[personaEstudio.Id]);
            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));
            Session["LstPersonaEstudio"] = LstPersonaEstudio;

            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_NuevoEmpleado_Eliminar_Archivo(Models.Consultas.PersonaEstudio personaEstudio)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();

            if (Session["LstPersonaEstudio"] != null)
            {
                LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];
            }
            LstPersonaEstudio[personaEstudio.Id].NmOriginal = null;
            LstPersonaEstudio[personaEstudio.Id].NmArchivo = null;

            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));
            Session["LstPersonaEstudio"] = LstPersonaEstudio;

            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_NuevoEmpleado_Mostrar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();
            string DirectorioURL = ""; 
            if (Session["LstPersonaEstudio"] != null)
            {
                LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];
            }
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\"  + LstPersonaEstudio[personaEstudio.Id].NmArchivo;
            return Json(DirectorioURL);
        }

        [HttpPost]
        public JsonResult Estudios_NuevoEmpleado_Consulta()
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();

            if (Session["LstPersonaEstudio"] != null)
            {
                LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];
            }

            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_EditarEmpleado_Agregar(Models.Consultas.PersonaEstudio personaEstudio, Application.PersonasEstudios APpersonasEstudios)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();
            APpersonasEstudios.PersonasEstudios_Agregar(personaEstudio);
            LstPersonaEstudio = APpersonasEstudios.PersonasEstudios_Seleccionar_Editar_IdPersona(personaEstudio.Personas);
            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));
            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_EditarEmpleado_Eliminar(Models.Consultas.PersonaEstudio personaEstudio, Application.PersonasEstudios APpersonasEstudios)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();
            APpersonasEstudios.PersonasEstudios_Editar_Eliminar(personaEstudio);
            LstPersonaEstudio = APpersonasEstudios.PersonasEstudios_Seleccionar_Editar_IdPersona(personaEstudio.Personas);
            if (LstPersonaEstudio ==  null)
            {
                return Json(0);
            }
            else
            {
                return Json(LstPersonaEstudio);
            }
        }

        [HttpPost]
        public JsonResult Estudios_EditarEmpleado_ActulizarArchivo(Models.Consultas.PersonaEstudio personaEstudio, Application.PersonasEstudios APpersonasEstudios)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();
            APpersonasEstudios.PersonasEstudios_Editar_ActualizarArchivo(personaEstudio);
            LstPersonaEstudio = APpersonasEstudios.PersonasEstudios_Seleccionar_Editar_IdPersona(personaEstudio.Personas);
            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));
            return Json(LstPersonaEstudio);
        }
        [HttpPost]
        public JsonResult Estudios_EditarEmpleado_Eliminar_Archivo(Models.Consultas.PersonaEstudio personaEstudio, Application.PersonasEstudios APpersonasEstudios)
        {
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();
            APpersonasEstudios.PersonasEstudios_Editar_EliminarArchivo(personaEstudio);
            LstPersonaEstudio = APpersonasEstudios.PersonasEstudios_Seleccionar_Editar_IdPersona(personaEstudio.Personas);
            LstPersonaEstudio.Sort((x, y) => string.Compare(x.Cat_Estudios.Nombre, y.Cat_Estudios.Nombre));
            return Json(LstPersonaEstudio);
        }

        [HttpPost]
        public JsonResult Estudios_EditarEmpleado_Mostrar(Models.Consultas.PersonaEstudio personaEstudio, Application.PersonasEstudios APpersonasEstudios)
        {
            Models.Consultas.PersonaEstudio personaEstudio1 = APpersonasEstudios.PersonasEstudios_Editar_Selecionar(personaEstudio);
            string DirectorioURL = "";
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + personaEstudio1.NmArchivo;
            return Json(DirectorioURL);
        }
    }
}
