using ProyectoBase.Application;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class VacantesController : Controller
    {
        Models.Usuarios Usuarios = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Application.Menu menu = new Application.Menu();

        // GET: Vacantes
        public ActionResult EditarVacante()
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult NuevaVacante(Application.Empresas APempresas, Application.Cat_Clientes APcat_Clientes, Application.Cat_EsquemaContratacion APCat_EsquemaContratacion, Application.Cat_Estados APcat_Estados, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado, Application.Vacante APVacante,Application.Cat_Modalidad APcat_Modalidad, Application.Cat_JornadaTrabajo APcat_JornadaTrabajo)
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                List<Models.Empresas> empresas = APempresas.Empresas_Seleccionar();
                List<Models.Cat_Clientes> cat_Clientes = APcat_Clientes.Cat_Clientes_Seleccionar();
                List<Models.Cat_EsquemaContratacion> cat_EsquemaContratacion = APCat_EsquemaContratacion.Cat_EsquemaContratacion_Seleccionar();
                List<Models.Cat_Estados> cat_Estados = APcat_Estados.Cat_Estados_Seleccionar();
                List<Models.Cat_Modalidad> cat_Modalidad = APcat_Modalidad.Cat_Modalidad_Seleccionar();
                List<Models.Cat_JornadaTrabajo> cat_JornadaTrabajo = APcat_JornadaTrabajo.Cat_JornadaTrabajo_Seleccionar();
                List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleado = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();

                ViewBag.Empresas = empresas;
                ViewBag.Clientes = cat_Clientes;
                ViewBag.EsquemaContratacion = cat_EsquemaContratacion;
                ViewBag.Estados = cat_Estados;
                ViewBag.Modalidad = cat_Modalidad;
                ViewBag.JornadaTrabajo = cat_JornadaTrabajo;
                ViewBag.MotivosBajaEmpleado = cat_MotivosBajaEmpleado;
                ViewBag.CatEstados = cat_Estados;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult Index(Application.Vacante APVacante)
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                List<Models.Vacante> dbVacantes = APVacante.Vacante_Seleccionar();
                ViewBag.Vacantes = dbVacantes;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult Vacante(Application.Prospecto APprospecto, Application.Vacante APvacante, Application.VacanteBitacora APvacanteBitacora, Application.VacanteNota APvacanteNota, Application.Cat_EstatusVacante APcat_EstatusVacante, Application.ProspectoEntrevista APprospectoEntrevista,
        Application.ProspectoMensaje APprospectoMensaje, Application.ProspectoCorreo APprospectoCorreo, Application.Cat_TipoPrueba APcat_TipoPrueba, Application.Cat_EstatusPrueba APcat_EstatusPrueba, Application.VacanteResponsable APvacanteResponsable, Application.ProspectoPrueba APprospectoPrueba,
        Application.Cat_EstatusEntrevistas APcat_EstatusEntrevistas)
        {
            if (menu.ValidacionPagina(Usuarios, url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Request.QueryString["Id"]);
                    TimeSpan diferencia;
                    Models.Vacante vacante = new Models.Vacante();
                    vacante.Id = Id;
                    Models.Vacante dbVacante = APvacante.Vacante_Seleccionar_Id(vacante);
                    List<Models.Prospecto> ListProspecto = APprospecto.Prospecto_Seleccionar_IdVacante(vacante);
                    List<Models.VacanteBitacora> ListvacanteBitacora = APvacanteBitacora.VacanteBitacora_Seleccionar_IdVacante(vacante);
                    List<Models.VacanteNota> ListVacanteNota = APvacanteNota.VacanteNota_Seleccionar_IdVacante(vacante);
                    List<Models.Cat_EstatusVacante> LisCat_EstatusVacante = APcat_EstatusVacante.Cat_EstatusVacante_Seleccionar();
                    List<Models.ProspectoEntrevista> ListProspectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Seleccionar_IdVacante(vacante);
                    List<Models.ProspectoMensaje> ListProspectoMensaje = APprospectoMensaje.ProspectoMensaje_Seleccionar_IdVacante(vacante);
                    List<Models.ProspectoCorreo> ListProspectoCorreo = APprospectoCorreo.ProspectoCorreo_Seleccionar_IdVacante(vacante);
                    List<Models.ProspectoPrueba> ListprospectoPrueba = APprospectoPrueba.ProspectoPrueba_Seleccionar_IdVacante(vacante);
                    List<Models.Consultas.Actividad> ActividadMes = APvacanteBitacora.VacanteBitacora_Actividad_Mes(vacante);
                    List<Models.VacanteResponsable> ListVacanteResponsable = APvacanteResponsable.VacanteResponsable_Seleccionar_IdVacante(vacante);
                    List<Models.Cat_TipoPrueba> ListTipoPrueba = APcat_TipoPrueba.Cat_TipoPrueba_Seleccionar();
                    List<Models.Cat_EstatusPrueba> ListEstatusPrueba = APcat_EstatusPrueba.Cat_EstatusPrueba_Seleccionar();
                    List<Models.Cat_EstatusEntrevistas> ListEstatusEntrevistas = APcat_EstatusEntrevistas.Cat_EstatusEntrevistas_Seleccionar();

                    if (dbVacante.FechaCierre.ToString() != "01/01/0001 12:00:00 a. m.")
                    {
                         diferencia = dbVacante.FechaCierre - dbVacante.FechaRegistro;
                    }
                    else
                    {
                         diferencia = DateTime.Today - dbVacante.FechaRegistro;
                    }

                    ViewBag.Prospectos = ListProspecto;
                    ViewBag.Vacante = dbVacante;
                    ViewBag.Dias = diferencia.Days;
                    ViewBag.Bitacora = ListvacanteBitacora;
                    ViewBag.VacanteNota = ListVacanteNota;
                    ViewBag.VacanteResponsable = ListVacanteResponsable;
                    ViewBag.Cat_EstatusVacante = LisCat_EstatusVacante;
                    ViewBag.Entrevistas = ListProspectoEntrevista;
                    ViewBag.Mensajes = ListProspectoMensaje;
                    ViewBag.Correos = ListProspectoCorreo;
                    ViewBag.Pruebas = ListprospectoPrueba;
                    ViewBag.Actividad = ActividadMes;
                    ViewBag.TipoPrueba = ListTipoPrueba;
                    ViewBag.EstatusPrueba = ListEstatusPrueba;
                    ViewBag.EstatusEntrevistas = ListEstatusEntrevistas;

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
        public JsonResult Vacante_Seleccionar_IdUsuario(Models.Vacante vacante, Application.Vacante APvacante)
        {
            List<Models.Vacante> DBVacantes = APvacante.Vacante_Seleccionar_IdUsuario(vacante.Usuarios);
            return Json(DBVacantes);
        }

        [HttpPost]
        public JsonResult Vacante_Estatus_IdUsuario(Models.Vacante vacante, Application.Vacante APVacante)
        {
            List<Models.Cat_EstatusVacante> DBVacanteEstatus = APVacante.Vacante_Estatus_IdUsuario(vacante.Usuarios);
            return Json(DBVacanteEstatus);
        }

        [HttpPost]
        public JsonResult Vacante_Estatus_Prospectos_IdUsuario(Models.Vacante vacante, Application.Vacante APVacante)
        {
            List<Models.Cat_EstatusProspecto> DBVacanteEstatus = APVacante.Vacante_Estatus_Prospectos_IdUsuario(vacante.Usuarios);
            return Json(DBVacanteEstatus);
        }

        [HttpPost]
        public JsonResult Vacante_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes, Application.Vacante APvacante)
        {
            List<Models.Vacante> DBVacantes = APvacante.Vacante_Seleccionar_IdCliente(cat_Clientes);
            return Json(DBVacantes);
        }

        [HttpPost]
        public JsonResult Vacante_Estatus_IdCliente(Models.Cat_Clientes cat_Clientes, Application.Vacante APVacante)
        {
            List<Models.Cat_EstatusVacante> DBVacanteEstatus = APVacante.Vacante_Estatus_IdCliente(cat_Clientes);
            return Json(DBVacanteEstatus);
        }

        [HttpPost]
        public JsonResult Vacante_Estatus_Prospectos_IdCliente(Models.Cat_Clientes cat_Clientes, Application.Vacante APVacante)
        {
            List<Models.Cat_EstatusProspecto> DBVacanteEstatus = APVacante.Vacante_Estatus_Prospectos_IdCliente(cat_Clientes);
            return Json(DBVacanteEstatus);
        }

        /// <summary>
        /// ///////////////////////
        /// 

        [HttpPost]
        public JsonResult Vacante_Seleccionar_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.Vacante APvacante)
        {
            List<Models.Vacante> DBVacantes = APvacante.Vacante_Seleccionar_IdProyecto(cat_ProyectoServicios);
            return Json(DBVacantes);
        }

        [HttpPost]
        public JsonResult Vacante_Estatus_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.Vacante APVacante)
        {
            List<Models.Cat_EstatusVacante> DBVacanteEstatus = APVacante.Vacante_Estatus_IdProyecto(cat_ProyectoServicios);
            return Json(DBVacanteEstatus);
        }

        [HttpPost]
        public JsonResult Vacante_Estatus_Prospectos_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.Vacante APVacante)
        {
            List<Models.Cat_EstatusProspecto> DBVacanteEstatus = APVacante.Vacante_Estatus_Prospectos_IdProyecto(cat_ProyectoServicios);
            return Json(DBVacanteEstatus);
        }

        /// <summary>
        /// ///////////////////////
        /// 

        [HttpPost]
        public JsonResult Vacante_Actulizar_Estatus(Models.Vacante vacante, Application.Vacante APVacante)
        {
            vacante.Usuarios = Usuarios;
            Models.Vacante DBVacante = APVacante.Vacante_Actualizar_IdEstatus(vacante);
            return Json(DBVacante);
        }


        [HttpPost]
        public JsonResult Vacante_Actualizar_nota(Models.VacanteNota VacanteNota, Application.VacanteNota APPVacanteNota)
        {
            Models.VacanteNota R = new Models.VacanteNota();

            VacanteNota.Usuarios = Usuarios;
            R = APPVacanteNota.Vacante_Actualizar_nota(VacanteNota);
            return Json(R);
        }


        [HttpPost]
        public JsonResult Vacante_Eliminar_Id(Models.Vacante vacante, Application.Vacante APVacante)
        {
            Models.Vacante DBVacante = APVacante.Prospecto_Eliminar_Id(vacante);
            return Json(DBVacante);
        }





        /////EXPERIMENTANDO PARA NO CREAR MAS CONTROLLLERS
        ///
        [HttpPost]
        public JsonResult Departamentos_Seleccionar_IdEmpresa(Models.Empresas empresas, Application.EmpresasDepartamento APempresasDepartamento)
        {
            List<Models.EmpresasDepartamento> departamentos = APempresasDepartamento.EmpresasDepartamento_Seleccionar_IdEmpresa(empresas);
            return Json(departamentos);
        }

        [HttpPost]
        public JsonResult Departamentos_Seleccionar_IdDepartamento(Models.EmpresasDepartamento empresasDepartamento, Application.EmpresaPuestos APEmpresaPuestos)
        {
            List<Models.EmpresaPuestos> departamentos = APEmpresaPuestos.EmpresaPuestos_Seleccionar_IdDepartamento(empresasDepartamento);
            return Json(departamentos);
        }

        [HttpPost]
        public JsonResult ClienteDirecciones_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes, Application.ClienteDireciones APclienteDireciones)
        {
            List<Models.ClienteDireciones> DBClienteDireciones = APclienteDireciones.ClienteDirecciones_Seleccionar_IdCliente(cat_Clientes);
            return Json(DBClienteDireciones);
        }


        [HttpPost]
        public JsonResult Vacante_Agregar(Models.Vacante vacante, Application.Vacante APVacante)
        {
            Models.Vacante _vacante = new Models.Vacante();
            vacante.Usuarios = Usuarios;
            _vacante = APVacante.Vacante_Agregar(vacante);
            return Json(_vacante);
        }


        [HttpPost]
        public JsonResult Nota_Eliminar_Id(Models.Vacante vacante, Application.Vacante APVacante)
        {
            Models.Vacante DBVacante = APVacante.Prospecto_Eliminar_Id(vacante);
            return Json(DBVacante);
        }
    }

}
