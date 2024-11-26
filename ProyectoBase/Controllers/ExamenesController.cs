using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ExamenesController : Controller
    {
        [HttpPost]
        public JsonResult Examenes_NuevoEmpleado_Agregarn(Models.PersonasExamen personasExamen)
        {
            Session["Examen"] = personasExamen;
            return Json(personasExamen);
        }
        [HttpPost]
        public JsonResult Examenes_NuevoEmpleado_Eliminar()
        {
            Session["Examen"] = null;
            return Json("");
        }
        [HttpPost]
        public JsonResult Examenes_NuevoEmpleado_Mostrar()
        {
            string DirectorioURL = ""; 
            Models.PersonasExamen _PersonasExamen = new Models.PersonasExamen();

            if (Session["Examen"] != null)
            {
                _PersonasExamen = (Models.PersonasExamen)Session["Examen"];
            }

            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + _PersonasExamen.NmArchivo;

            return Json(DirectorioURL);
        }

        [HttpPost]
        public JsonResult Examenes_EditarEmpleado_Agregar(Models.PersonasExamen personasExamen, Application.PersonasExamen APpersonasExamen, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.PersonasExamen RegistroExamen = new Models.PersonasExamen();
            Models.PersonasExamen _PersonasExamen = new Models.PersonasExamen();
            string DirectorioUsuario = HttpContext.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            if (Session["Examen"] != null)
            {
                _PersonasExamen = (Models.PersonasExamen)Session["Examen"];
            }

            _PersonasExamen.Personas = personasExamen.Personas;
            _PersonasExamen.Cat_TipoExamen = personasExamen.Cat_TipoExamen;
            _PersonasExamen.Calificacion = personasExamen.Calificacion;
            _PersonasExamen.Califico = personasExamen.Califico;
            _PersonasExamen.FechaAplicacion = personasExamen.FechaAplicacion;
            _PersonasExamen.Observaciones = personasExamen.Observaciones;

            RegistroExamen = APpersonasExamen.PersonasExamen_Agregar(_PersonasExamen);
            if (RegistroExamen.Id > 0)
            {
                if (!String.IsNullOrEmpty(_PersonasExamen.NmArchivo))
                {
                    if (!Directory.Exists(folderPath + @"\" + personasExamen.Personas.PersonasFolio.FolioCompuesto + @"\EXAMEN"))
                    {
                        Directory.CreateDirectory(folderPath + @"\" + personasExamen.Personas.PersonasFolio.FolioCompuesto + @"\EXAMEN");
                    }
                    string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, _PersonasExamen.NmArchivo);
                    string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + personasExamen.Personas.PersonasFolio.FolioCompuesto + @"\EXAMEN", _PersonasExamen.NmArchivo);
                    System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                }
            }

            Session["NuevoExamen"] = _PersonasExamen;

            return Json(RegistroExamen);
        }

        [HttpPost]
        public JsonResult Examenes_EditarEmpleado_Eliminar_Examen(Models.PersonasExamen personasExamen, Application.PersonasExamen APpersonasExamen)
        {
            Models.PersonasExamen examen1 = APpersonasExamen.PersonasExamen_Eliminar(personasExamen);
            return Json(examen1);
        }

        [HttpPost]
        public JsonResult Examenes_EditarEmpleado_Eliminar_NuevoExamen(Application.PersonasExamen APpersonasExamen)
        {
            Models.PersonasExamen NuevoExamen = new Models.PersonasExamen();
            Models.PersonasExamen examen1 = new Models.PersonasExamen();
            if (Session["NuevoExamen"] != null)
            {
                NuevoExamen = (Models.PersonasExamen)Session["NuevoExamen"];
                examen1 = APpersonasExamen.PersonasExamen_Eliminar(NuevoExamen);
                Session["NuevoExamen"] = null;
            }
            else
            {
                examen1.Id = -1;
            }
            return Json(examen1);
        }

        [HttpPost]
        public JsonResult Examenes_EditarEmpleado_Actualizar_Examen(Models.PersonasExamen personasExamen, Application.PersonasExamen APpersonasExamen)
        {
            Models.PersonasExamen SecioneExamen = new Models.PersonasExamen();
            if (Session["Examen"] != null)
            {
                SecioneExamen = (Models.PersonasExamen)Session["Examen"];
            }
            personasExamen.NmArchivo = SecioneExamen.NmArchivo;
            personasExamen.NmOriginal = SecioneExamen.NmOriginal;

            Models.PersonasExamen examen1 = APpersonasExamen.PersonasExamen_Actualizar(personasExamen);

            return Json(examen1);
        }


    }
}
