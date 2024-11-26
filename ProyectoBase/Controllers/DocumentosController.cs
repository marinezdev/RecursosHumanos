using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class DocumentosController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_Lista_Default(Application.Cat_TipoDocumento APcat_TipoDocumento, Application.Cat_EstatusDocumento APcat_EstatusDocumento, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();
            
           
            List<Models.Cat_TipoDocumento> cat_TipoDocumentos = APcat_TipoDocumento.Cat_TipoDocumento_Selecionar_Default();

            if (cat_TipoDocumentos.Count > 0)
            {
                foreach (var Cat_TipoDocumento in cat_TipoDocumentos)
                {
                    Models.PersonasDocumentos personaDocumento = new Models.PersonasDocumentos();

                    personaDocumento.Id = Cat_TipoDocumento.Id;
                    personaDocumento.Cat_TipoDocumento = APcat_TipoDocumento.Cat_TipoDocumento_Selecionar_Id(Cat_TipoDocumento);
                    personaDocumento.FechaEntrega = DateTime.Now;
                    personaDocumento.FechaVigencia = DateTime.Now;
                    personaDocumento.Cat_EstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(3);
                    personaDocumento.CatEstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Seleccionar();
                    LstPersonasDocumentos.Add(personaDocumento);
                }
                LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));
                Session["ListaDocumentos"] = LstPersonasDocumentos;
            }
            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_Agregar_Lista(Models.Cat_TipoDocumento cat_TipoDocumento, Application.Cat_TipoDocumento APcat_TipoDocumento, Application.Cat_EstatusDocumento APcat_EstatusDocumento)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();
            Models.PersonasDocumentos personaDocumento = new Models.PersonasDocumentos();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            bool Agregar = false;
            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == cat_TipoDocumento.Id)
                {
                    Agregar = true;
                }
            }

            if (!Agregar)
            {
                personaDocumento.Id = cat_TipoDocumento.Id;
                personaDocumento.Cat_TipoDocumento = APcat_TipoDocumento.Cat_TipoDocumento_Selecionar_Id(cat_TipoDocumento);
                personaDocumento.FechaEntrega = DateTime.Now;
                personaDocumento.FechaVigencia = DateTime.Now;
                personaDocumento.Cat_EstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(3);
                personaDocumento.CatEstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Seleccionar();
                LstPersonasDocumentos.Add(personaDocumento);
            }

            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));
            Session["ListaDocumentos"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);

        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_ActualizarArchivo(Models.PersonasDocumentos personasDocumentos, Application.Cat_EstatusDocumento APcat_EstatusDocumento)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    LstPersonasDocumentos[i].DocumentoVersiones = personasDocumentos.DocumentoVersiones;
                    LstPersonasDocumentos[i].Cat_EstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(1);
                }
            }

            Session["ListaDocumentos"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_Eliminar_Archivo(Models.PersonasDocumentos personasDocumentos, Application.Cat_EstatusDocumento APcat_EstatusDocumento)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    LstPersonasDocumentos[i].DocumentoVersiones = null;
                    LstPersonasDocumentos[i].Cat_EstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(2);
                }
            }

            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));
            Session["ListaDocumentos"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_Mostrar(Models.PersonasDocumentos personasDocumentos)
        {
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    personasDocumentos.DocumentoVersiones.NmArchivo = DirectorioURL + LstPersonasDocumentos[i].DocumentoVersiones.NmArchivo;
                }
            }
            return Json(personasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_Eliminar(Models.PersonasDocumentos personasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }
            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    LstPersonasDocumentos.Remove(LstPersonasDocumentos[i]);
                }
            }
            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));
            Session["LstPersonaEstudio"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_ActualizarEstatus(Models.PersonasDocumentos personasDocumentos, Application.Cat_EstatusDocumento APcat_EstatusDocumento)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    LstPersonasDocumentos[i].Cat_EstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(personasDocumentos.Cat_EstatusDocumento.Id);
                }
            }

            Session["ListaDocumentos"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_ActualizarEntrega(Models.PersonasDocumentos personasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    LstPersonasDocumentos[i].FechaEntrega = personasDocumentos.FechaEntrega;
                }
            }

            Session["ListaDocumentos"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_NuevoEmpleado_ActualizarVigencia(Models.PersonasDocumentos personasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            if (Session["ListaDocumentos"] != null)
            {
                LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
            }

            for (int i = 0; i < LstPersonasDocumentos.Count; i++)
            {
                if (LstPersonasDocumentos[i].Id == personasDocumentos.Id)
                {
                    LstPersonasDocumentos[i].FechaVigencia = personasDocumentos.FechaVigencia;
                }
            }

            Session["ListaDocumentos"] = LstPersonasDocumentos;

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_EditarEmpleado_Agregar_Lista(Models.PersonasDocumentos personasDocumentos, Application.PersonasDocumentos APpersonasDocumentos, Application.Cat_EstatusDocumento APcat_EstatusDocumento)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();

            Models.PersonasDocumentos Docuemnto = new Models.PersonasDocumentos();
            Models.DocumentoVersiones documentoVersiones = new Models.DocumentoVersiones();
            documentoVersiones.Version = "1.0";

            Docuemnto.Personas = personasDocumentos.Personas;
            Docuemnto.Cat_TipoDocumento = personasDocumentos.Cat_TipoDocumento;
            Docuemnto.Usuarios = Usuario;
            Docuemnto.DocumentoVersiones = documentoVersiones;
            Docuemnto.Cat_EstatusDocumento = APcat_EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(2);
            APpersonasDocumentos.PersonasDocumento_Agregar(Docuemnto);


            LstPersonasDocumentos = APpersonasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(personasDocumentos.Personas);
            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_EditarEmpleado_Eliminar(Models.PersonasDocumentos personasDocumentos, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();
            APpersonasDocumentos.PersonasDocumentos_Editar_Eliminar(personasDocumentos);
            LstPersonasDocumentos = APpersonasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(personasDocumentos.Personas);
            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_EditarEmpleado_ActulizarArchivo(Models.PersonasDocumentos personasDocumentos, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();
            APpersonasDocumentos.PersonasDocumentos_Editar_ActualizarArchivo(personasDocumentos);
            LstPersonasDocumentos = APpersonasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(personasDocumentos.Personas);
            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_EditarEmpleado_Eliminar_Archivo(Models.PersonasDocumentos personasDocumentos, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();
            APpersonasDocumentos.PersonasDocumentos_Editar_EliminarArchivo(personasDocumentos);
            LstPersonasDocumentos = APpersonasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(personasDocumentos.Personas);
            LstPersonasDocumentos.Sort((x, y) => string.Compare(x.Cat_TipoDocumento.Nombre, y.Cat_TipoDocumento.Nombre));

            return Json(LstPersonasDocumentos);
        }
        [HttpPost]
        public JsonResult Documento_EditarEmpleado_Mostrar(Models.PersonasDocumentos personasDocumentos, Application.PersonasDocumentos APpersonasDocumentos)
        {
            Models.PersonasDocumentos personasDocumentos1 = APpersonasDocumentos.PersonasDocumentos_Editar_Selecionar(personasDocumentos);
            string DirectorioURL = "";
            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\" + personasDocumentos1.DocumentoVersiones.NmArchivo;
            return Json(DirectorioURL);
        }

        [HttpPost]
        public JsonResult PersonasDocumento_Procentaje(Application.PersonasDocumentos APpersonasDocumentos)
        {
            Models.Consultas.PersonasDocumento_Procentaje personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Procentaje();
            return Json(personasDocumentos1);
        }

        [HttpPost]
        public JsonResult PersonasDocumento_Procentaje_IdEmpresa(Models.Empresas empresas, Application.PersonasDocumentos APpersonasDocumentos)
        {
            Models.Consultas.PersonasDocumento_Procentaje personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Procentaje_IdEmpresa(empresas);
            return Json(personasDocumentos1);
        }

        [HttpPost]
        public JsonResult PersonasDocumento_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes, Application.PersonasDocumentos APpersonasDocumentos)
        {
            Models.Consultas.PersonasDocumento_Procentaje personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Procentaje_Cliente(cat_Clientes);
            return Json(personasDocumentos1);
        }

        [HttpPost]
        public JsonResult PersonasDocumento_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.PersonasDocumentos APpersonasDocumentos)
        {
            Models.Consultas.PersonasDocumento_Procentaje personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Procentaje_Cliente_ProyectoServicio(cat_ProyectoServicios);
            return Json(personasDocumentos1);
        }

        [HttpPost]
        public JsonResult Reporte_Empleados_Documentos_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes, Application.Reportes APReportes)
        {
            DataTable table = APReportes.Reporte_Empleados_Documentos_Procentaje_Cliente(cat_Clientes);
            return Json(DataTableToJsonWithJsonNet(table));
        }

        [HttpPost]
        public JsonResult Reporte_Empleados_Documentos_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.Reportes APReportes)
        {
            DataTable table = APReportes.Reporte_Empleados_Documentos_Procentaje_Cliente_ProyectoServicio(cat_ProyectoServicios);
            return Json(DataTableToJsonWithJsonNet(table));
        }

        [HttpPost]
        public JsonResult PersonasDocumento_Documento_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.Consultas.PersonasDocumento_Procentaje> personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Documento_Procentaje_Cliente(cat_Clientes);
            return Json(personasDocumentos1);
        }

        [HttpPost]
        public JsonResult PersonasDocumento_Documento_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios, Application.PersonasDocumentos APpersonasDocumentos)
        {
            List<Models.Consultas.PersonasDocumento_Procentaje> personasDocumentos1 = APpersonasDocumentos.PersonasDocumento_Documento_Procentaje_Cliente_ProyectoServicio(cat_ProyectoServicios);
            return Json(personasDocumentos1);
        }

        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
    }
}
