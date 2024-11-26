using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ProyectoBase.Controllers
{
    public class ProspectosController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Application.Menu menu = new Application.Menu();

        public ActionResult EditarProspecto(Application.Prospecto APprospecto, Application.ProspectoArchivo APprospectoArchivo)
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Application.UrlCifrardo.Desencriptar(Request.QueryString["Id"]));
                    Models.Prospecto prospecto = new Models.Prospecto();
                    prospecto.Id = Id;

                    int Idv = Convert.ToInt32(Application.UrlCifrardo.Desencriptar(Request.QueryString["Idv"]));
                    Models.Vacante vacante = new Models.Vacante();
                    vacante.Id = Idv;

                    Models.Prospecto dbprospecto = new Models.Prospecto();
                    dbprospecto = APprospecto.Prospecto_Seleccionar_Id(prospecto);
                    List<Models.ProspectoArchivo> ListProspectoArchivo = APprospectoArchivo.ProspectoArchivo_Seleccionar_IdProspecto(dbprospecto);

                    ViewBag.Prospecto = dbprospecto;
                    ViewBag.ProspectoArchivo = ListProspectoArchivo;
                    ViewBag.Vacante = vacante;

                    return View();
                }
                else { return RedirectToAction("Index", "Prospectos"); }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }

        }

        // GET: Prospectos
        public ActionResult Index(Application.Prospecto APprospecto)
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                List<Models.Consultas.Prospectos> DBProspecto = APprospecto.Prospecto_Seleccionar();
                ViewBag.Prospectos = DBProspecto;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult Prospecto(Application.Prospecto APprospecto, Application.Vacante APvacante, Application.Cat_EstatusProspecto APcat_EstatusProspecto, Application.ProspectoBitacora APprospectoBitacora, Application.ProspectoExperiencia APprospectoExperiencia, Application.ProspectoArchivo APprospectoArchivo,
           Application.ProspectoEntrevista APprospectoEntrevista, Application.ProspectoNota APprospectoNota, Application.ProspectoMensaje APprospectoMensaje, Application.ProspectoCorreo APprospectoCorreo, Application.VacanteResponsable APvacanteResponsable, Application.Cat_TipoPrueba APcat_TipoPrueba, Application.Cat_EstatusPrueba APcat_EstatusPrueba,
            Application.Cat_EstatusEntrevistas APcat_EstatusEntrevistas, Application.ProspectoPrueba APprospectoPrueba)
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Request.QueryString["Id"]);
                    TimeSpan diferencia;
                    Models.Prospecto prospecto = new Models.Prospecto();
                    prospecto.Id = Id;
                    Models.Prospecto dbprospecto = new Models.Prospecto();
                    dbprospecto = APprospecto.Prospecto_Seleccionar_Id(prospecto);
                    Models.Vacante dbVacante = APvacante.Vacante_Seleccionar_Id(dbprospecto.Vacante);
                    List<Models.Cat_EstatusProspecto> ListEstatusProspecto = APcat_EstatusProspecto.Cat_EstatusProspecto_Seleccionar();
                    List<Models.Consultas.Actividad> ActividadMes = APprospectoBitacora.ProspectoBitacora_Actividad_Mes(dbprospecto);
                    List<Models.ProspectoExperiencia> ListProspectoExperiencia = APprospectoExperiencia.ProspectoExperiencia_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoArchivo> ListProspectoArchivo = APprospectoArchivo.ProspectoArchivo_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoBitacora> ListvacanteBitacora = APprospectoBitacora.ProspectoBitacora_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoEntrevista> ListProspectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoNota> ListProspectoNota = APprospectoNota.ProspectoNota_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoMensaje> ListProspectoMensaje = APprospectoMensaje.ProspectoMensaje_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoCorreo> ListProspectoCorreo = APprospectoCorreo.ProspectoCorreo_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.ProspectoPrueba> ListProspectoPrueba = APprospectoPrueba.ProspectoPrueba_Seleccionar_IdProspecto(dbprospecto);
                    List<Models.VacanteResponsable> ListVacanteResponsable = APvacanteResponsable.VacanteResponsable_Seleccionar_IdVacante(dbVacante);
                    List<Models.Cat_TipoPrueba> ListTipoPrueba = APcat_TipoPrueba.Cat_TipoPrueba_Seleccionar();
                    List<Models.Cat_EstatusPrueba> ListEstatusPrueba = APcat_EstatusPrueba.Cat_EstatusPrueba_Seleccionar();
                    List<Models.Cat_EstatusEntrevistas> ListEstatusEntrevistas = APcat_EstatusEntrevistas.Cat_EstatusEntrevistas_Seleccionar();

                    if (dbprospecto.FechaTermino.ToString() != "01/01/0001 12:00:00 a. m.")
                    {
                        diferencia = dbprospecto.FechaTermino - dbprospecto.FechaRegistro;
                    }
                    else
                    {
                        diferencia = DateTime.Today - dbprospecto.FechaRegistro;
                    }

                    ViewBag.Prospecto = dbprospecto;
                    ViewBag.Vacante = dbVacante;
                    ViewBag.EstatusProspecto = ListEstatusProspecto;
                    ViewBag.Dias = diferencia.Days;
                    ViewBag.Actividad = ActividadMes;
                    ViewBag.ProspectoExperiencia = ListProspectoExperiencia;
                    ViewBag.ProspectoArchivo = ListProspectoArchivo;

                    ViewBag.VacanteResponsable = ListVacanteResponsable;
                    ViewBag.TipoPrueba = ListTipoPrueba;
                    ViewBag.EstatusPrueba = ListEstatusPrueba;
                    ViewBag.EstatusEntrevistas = ListEstatusEntrevistas;

                    ViewBag.Bitacora = ListvacanteBitacora;
                    ViewBag.ProspectoNota = ListProspectoNota;
                    ViewBag.Entrevistas = ListProspectoEntrevista;
                    ViewBag.Mensajes = ListProspectoMensaje;
                    ViewBag.Correos = ListProspectoCorreo;
                    ViewBag.Pruebas = ListProspectoPrueba;

                    return View();
                }
                else { return RedirectToAction("Index", "Vacantes"); }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Prospecto_Actulizar_Estatus(Models.Prospecto prospecto, Application.Prospecto APProspecto)
        {
            prospecto.Usuarios = Usuarios;
            Models.Prospecto DBProspecto = APProspecto.Prospecto_Actualizar_IdEstatus(prospecto);
            return Json(DBProspecto);
        }

        [HttpPost]
        public JsonResult Prospecto_Eliminar_Id(Models.Prospecto prospecto, Application.Prospecto APProspecto)
        {
            Models.Prospecto DBProspecto = APProspecto.Prospecto_Eliminar_Id(prospecto);
            return Json(DBProspecto);
        }



        [HttpPost]
        public JsonResult Prospecto_Seleccionar_Id(Models.Prospecto Prospecto, Application.Prospecto APProspecto)
        {
            Models.Prospecto DBProspecto = APProspecto.Prospecto_Seleccionar_Id(Prospecto);
            return Json(DBProspecto);
        }

        //ACTUALIZAR PROSPECTO
        [HttpPost]
        public JsonResult Prospecto_Actualizar(Models.Prospecto Prospecto, Application.Prospecto APProspecto)
        {
            Prospecto.Usuarios = Usuarios;
            Models.Prospecto DBProspecto = APProspecto.Prospecto_Actualizar(Prospecto);
            return Json(DBProspecto);
        }


        [HttpPost]
        public JsonResult ProspectoExperiencia_Eliminar(Models.Prospecto prospecto, Application.Prospecto APProspecto)
        {
            Models.Prospecto DBProspecto = APProspecto.ProspectoExperiencia_Eliminar(prospecto);
            return Json(DBProspecto);
        }

        [HttpPost]
        public JsonResult ProspectoExperiencia_Agregar(Models.ProspectoExperiencia ProspectoExperiencia, Application.ProspectoExperiencia APprospectoExperiencia)
        {
            Models.ProspectoExperiencia R= APprospectoExperiencia.ProspectoExperiencia_Agregar(ProspectoExperiencia);
            return Json(R);
        }

    }
}
