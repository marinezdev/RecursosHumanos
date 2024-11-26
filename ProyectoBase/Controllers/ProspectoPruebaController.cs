using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ProspectoPruebaController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ProspectoPrueba_Agregar(Models.ProspectoPrueba prospectoPrueba, Application.ProspectoPrueba APProspectoPrueba)
        {
            prospectoPrueba.Usuarios = Usuarios;
            Models.ProspectoPrueba DBProspectoPrueba = APProspectoPrueba.ProspectoPrueba_Agregar(prospectoPrueba);
            
            return Json(DBProspectoPrueba);
        }

        [HttpPost]
        public JsonResult ProspectoPrueba_Agregar_Nueva(Models.ProspectoPrueba prospectoPrueba, Application.ProspectoPrueba APProspectoPrueba)
        {
            prospectoPrueba.Usuarios = Usuarios;
            Models.Cat_EstatusPrueba cat_EstatusPrueba = new Models.Cat_EstatusPrueba();
            cat_EstatusPrueba.Id = 1;
            prospectoPrueba.Cat_EstatusPrueba = cat_EstatusPrueba;
            Models.ProspectoPrueba DBProspectoPrueba = APProspectoPrueba.ProspectoPrueba_Agregar(prospectoPrueba);

            // PROCESO DE ENVIO DE CORREO ELECTRONICO

            return Json(DBProspectoPrueba);
        }

        [HttpPost]
        public JsonResult ProspectoPrueba_Actualizar_IdEstatus(Models.ProspectoPrueba prospectoPrueba, Application.ProspectoPrueba APProspectoPrueba)
        {
            prospectoPrueba.Usuarios = Usuarios;
            Models.ProspectoPrueba DBProspectoPrueba = APProspectoPrueba.ProspectoPrueba_Actualizar_IdEstatus(prospectoPrueba);
            return Json(DBProspectoPrueba);
        }


        [HttpPost]
        public JsonResult ProspectoPrueba_EliminarPrueba(Models.ProspectoPrueba prospectoPrueba, Application.ProspectoPrueba APProspectoPrueba)
        {
            prospectoPrueba.Usuarios = Usuarios;
            Models.ProspectoPrueba DBVacante = APProspectoPrueba.ProspectoPrueba_EliminarPrueba(prospectoPrueba);
            return Json(DBVacante);
        }
    }
}
