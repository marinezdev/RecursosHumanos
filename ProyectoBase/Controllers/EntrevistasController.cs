using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class EntrevistasController : Controller
    {
        [HttpPost]
        public JsonResult Entrevistas_NuevoEmpleado_Agregar(Models.PersonasEntrevistas  personasEntrevistas, Application.Control_Archivos APcontrol_Archivos)
        {
            List<Models.PersonasEntrevistas> ListaEntrevitas = new List<Models.PersonasEntrevistas>();
            if (Session["ListaEntrevitas"] != null)
            {
                ListaEntrevitas = (List<Models.PersonasEntrevistas>)Session["ListaEntrevitas"];
            }

            personasEntrevistas.Id = APcontrol_Archivos.Entrevistas_NuevoId().Id;
            ListaEntrevitas.Add(personasEntrevistas);
            Session["ListaEntrevitas"] = ListaEntrevitas;

            return Json(ListaEntrevitas);
        }
        [HttpPost]
        public JsonResult Entrevistas_NuevoEmpleado_Listar()
        {
            List<Models.PersonasEntrevistas> ListaEntrevitas = new List<Models.PersonasEntrevistas>();
            if (Session["ListaEntrevitas"] != null)
            {
                ListaEntrevitas = (List<Models.PersonasEntrevistas>)Session["ListaEntrevitas"];
            }
            return Json(ListaEntrevitas);
        }
        [HttpPost]
        public JsonResult Entrevistas_NuevoEmpleado_Eliminar(Models.PersonasEntrevistas personasEntrevistas)
        {
            List<Models.PersonasEntrevistas> ListaEntrevitas = new List<Models.PersonasEntrevistas>();
            if (Session["ListaEntrevitas"] != null)
            {
                ListaEntrevitas = (List<Models.PersonasEntrevistas>)Session["ListaEntrevitas"];
            }

            for (int i = 0; i < ListaEntrevitas.Count; i++)
            {
                if (ListaEntrevitas[i].Id == personasEntrevistas.Id)
                {
                    ListaEntrevitas.Remove(ListaEntrevitas[i]);
                }
            }

            Session["ListaEntrevitas"] = ListaEntrevitas;

            return Json(ListaEntrevitas);
        }
        [HttpPost]
        public JsonResult Entrevistas_EditarEmpleado_Agregar(Models.PersonasEntrevistas personasEntrevistas, Application.PersonasEntrevistas APpersonasEntrevistas)
        {
            List<Models.PersonasEntrevistas> ListaEntrevitas = new List<Models.PersonasEntrevistas>();
            APpersonasEntrevistas.PersonasEntrevistas_Agregar(personasEntrevistas);
            ListaEntrevitas = APpersonasEntrevistas.PersonasEntrevistas_Seleccionar_IdPersona(personasEntrevistas.Personas);
            return Json(ListaEntrevitas);
        }
        [HttpPost]
        public JsonResult Entrevistas_EditarEmpleado_Eliminar(Models.PersonasEntrevistas personasEntrevistas, Application.PersonasEntrevistas APpersonasEntrevistas)
        {
            List<Models.PersonasEntrevistas> ListaEntrevitas = new List<Models.PersonasEntrevistas>();
            APpersonasEntrevistas.PersonasEntrevistas_Eliminar(personasEntrevistas);
            ListaEntrevitas = APpersonasEntrevistas.PersonasEntrevistas_Seleccionar_IdPersona(personasEntrevistas.Personas);
            return Json(ListaEntrevitas);
        }
    }
}
