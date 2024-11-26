using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class PsicometricosController : Controller
    {
        [HttpPost]
        public JsonResult Psicometricos_NuevoEmpleado_Agregarn(Models.PersonasPsicometrico personasPsicometrico)
        {
            Session["Prueba"] = personasPsicometrico;

            return Json(personasPsicometrico);
        }

        [HttpPost]
        public JsonResult Psicometricos_NuevoEmpleado_Eliminar()
        {
            Session["Prueba"] = null;

            return Json("");
        }

        [HttpPost]
        public JsonResult Psicometricos_NuevoEmpleado_Mostrar()
        {
            string DirectorioURL = ""; 
            Models.PersonasPsicometrico _PersonasPsicometrico = new Models.PersonasPsicometrico();
            if (Session["Prueba"] != null)
            {
                _PersonasPsicometrico = (Models.PersonasPsicometrico)Session["Prueba"];
            }
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + _PersonasPsicometrico.NmArchivo;
            return Json(DirectorioURL);
        }

        [HttpPost]
        public JsonResult Psicometricos_EditarEmpleado_Agregar(Models.PersonasPsicometrico personasPsicometrico, Application.PersonasPsicometrico APpersonasPsicometrico, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.PersonasPsicometrico RegistroPsicometrico = new Models.PersonasPsicometrico();
            Models.PersonasPsicometrico _PersonasPsicometrico = new Models.PersonasPsicometrico();
            string DirectorioUsuario = HttpContext.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            if (Session["Prueba"] != null)
            {
                _PersonasPsicometrico = (Models.PersonasPsicometrico)Session["Prueba"];
            }

            _PersonasPsicometrico.Califico = personasPsicometrico.Califico;
            _PersonasPsicometrico.Personas = personasPsicometrico.Personas;
            _PersonasPsicometrico.FechaAplicacion = personasPsicometrico.FechaAplicacion;
            _PersonasPsicometrico.Observaciones = personasPsicometrico.Observaciones;

            RegistroPsicometrico = APpersonasPsicometrico.PersonasPsicometrico_Agregar(_PersonasPsicometrico);
            if (RegistroPsicometrico.Id > 0)
            {
                if (!String.IsNullOrEmpty(_PersonasPsicometrico.NmArchivo))
                {
                    if (!Directory.Exists(folderPath + @"\" + personasPsicometrico.Personas.PersonasFolio.FolioCompuesto + @"\EXAMEN"))
                    {
                        Directory.CreateDirectory(folderPath + @"\" + personasPsicometrico.Personas.PersonasFolio.FolioCompuesto + @"\EXAMEN");
                    }
                    string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, _PersonasPsicometrico.NmArchivo);
                    string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + personasPsicometrico.Personas.PersonasFolio.FolioCompuesto + @"\EXAMEN", _PersonasPsicometrico.NmArchivo);
                    System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                }
            }

            Session["NuevoPrueba"] = _PersonasPsicometrico;
            return Json(_PersonasPsicometrico);
        }

        [HttpPost]
        public JsonResult Psicometricos_EditarEmpleado_Eliminar_Prueba(Models.PersonasPsicometrico personasPsicometrico, Application.PersonasPsicometrico APpersonasPsicometrico)
        {
            Models.PersonasPsicometrico Psicometrico1 = APpersonasPsicometrico.PersonasPsicometrico_Eliminar(personasPsicometrico);
            return Json(Psicometrico1);
        }

        [HttpPost]
        public JsonResult Psicometricos_EditarEmpleado_Eliminar_NuevaPrueba(Application.PersonasPsicometrico APpersonasPsicometrico)
        {
            Models.PersonasPsicometrico NuevoPsicometrico = new Models.PersonasPsicometrico();
            Models.PersonasPsicometrico Psicometrico1 = new Models.PersonasPsicometrico();
            if (Session["NuevoPrueba"] != null)
            {
                NuevoPsicometrico = (Models.PersonasPsicometrico)Session["NuevoPrueba"];
                Psicometrico1 = APpersonasPsicometrico.PersonasPsicometrico_Eliminar(NuevoPsicometrico);
                Session["NuevoPrueba"] = null;
            }
            else
            {
                Psicometrico1.Id = -1;
            }
            return Json(Psicometrico1);
        }

        [HttpPost]
        public JsonResult Psicometricos_EditarEmpleado_Actualizar_Prueba(Models.PersonasPsicometrico personasPsicometrico, Application.PersonasPsicometrico APpersonasPsicometrico)
        {
            Models.PersonasPsicometrico SecionePrueba = new Models.PersonasPsicometrico();
            if (Session["Prueba"] != null)
            {
                SecionePrueba = (Models.PersonasPsicometrico)Session["Prueba"];
            }
            personasPsicometrico.NmArchivo = SecionePrueba.NmArchivo;
            personasPsicometrico.NmOriginal = SecionePrueba.NmOriginal;

            Models.PersonasPsicometrico examen1 = APpersonasPsicometrico.PersonasPsicometrico_Actualizar(personasPsicometrico);

            return Json(examen1);
        }
    }
}
