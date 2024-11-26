using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class EmpleadosController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        // GET: Empleados
        public ActionResult Index(Application.Menu menu, Application.Empleados ApEmpleados)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                int Id = 0;
                List<Models.Consultas.Empleados> empleados = new List<Models.Consultas.Empleados>();
                if (!String.IsNullOrEmpty(Request.QueryString["count"]))
                {
                    Id = Convert.ToInt32(Request.QueryString["count"].ToString());
                    empleados = ApEmpleados.Empleados_Listar_Consulta(Id);
                }
                else
                {
                    empleados = ApEmpleados.Empleados_Listar();
                }


                ViewBag.Empleados = empleados;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult NuevoEmpleado(Application.Menu menu, Application.Cat_Banco cat_Banco, Application.Cat_EstadoCivil cat_EstadoCivil, Application.Cat_Estados cat_Estados, Application.Cat_EstatusEstudios cat_EstatusEstudios, Application.Cat_Estudios cat_Estudios, Application.Cat_TipoCredito cat_TipoCredito, Application.Cat_NivelIngles cat_NivelIngles, Application.Empresas APempresas,
            Application.Cat_EsquemaContratacion APcat_EsquemaContratacion, Application.Cat_TipoExamen APcat_TipoExamen, Application.Cat_FuenteReclutamiento APfuenteReclutamiento, Application.Cat_TipoDocumento APtipoDocumento,
            Application.Cat_Cursos APcat_Cursos, Application.Cat_Diplomados APcat_Diplomados, Application.Cat_Certificaciones APcat_Certificaciones, Application.Cat_Aplicaciones APcat_Aplicaciones)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Cat_Banco> Bancos = cat_Banco.Cat_Banco_Selecionar_Listar();
                List<Models.Cat_EstadoCivil> EstadoCivil = cat_EstadoCivil.Cat_EstadoCivil_Selecionar_Listar();
                List<Models.Cat_Estados> Estados = cat_Estados.Cat_Estados_Seleccionar();
                List<Models.Cat_EstatusEstudios> EstatusEstudios = cat_EstatusEstudios.Cat_EstatusEstudios_Selecionar_Listar();
                List<Models.Cat_Estudios> Estudios = cat_Estudios.Cat_Estudios_Selecionar_Listar();
                List<Models.Cat_TipoCredito> TipoCredito = cat_TipoCredito.Cat_TipoCredito_Selecionar_Listar();
                List<Models.Cat_NivelIngles> NivelIngles = cat_NivelIngles.Cat_NivelIngles_Selecionar_Listar();
                List<Models.Empresas> Empresas = APempresas.Empresas_Seleccionar();
                List<Models.Cat_EsquemaContratacion> EsquemaContratacion = APcat_EsquemaContratacion.Cat_EsquemaContratacion_Seleccionar();
                List<Models.Cat_TipoExamen> TipoExamen = APcat_TipoExamen.Cat_TipoExamen_Seleccionar();
                List<Models.Cat_FuenteReclutamiento> FuenteReclutamiento = APfuenteReclutamiento.Cat_FuenteReclutamiento_Seleccionar();
                List<Models.Cat_TipoDocumento> TipoDocumento = APtipoDocumento.Cat_TipoDocumento_Selecionar();
                //List<Models.Cat_Clientes> Clientes = APcat_Clientes.Cat_Clientes_Seleccionar();
                List<Models.Cat_Cursos> Cursos = APcat_Cursos.Cat_Cursos_Seleccionar();
                List<Models.Cat_Diplomados> Diplomados = APcat_Diplomados.Cat_Diplomados_Seleccionar();
                List<Models.Cat_Certificaciones> Certificaciones = APcat_Certificaciones.Cat_Certificaciones_Seleccionar();
                List<Models.Cat_Aplicaciones> cat_Aplicaciones = APcat_Aplicaciones.Cat_Aplicaciones_Seleccionar();

                Session["ListaDocumentos"] = null;
                Session["Prueba"] = null;
                Session["Examen"] = null;
                Session["ListaCDC"] = null;
                Session["PersonasIMG"] = null;
                Session["ListaAplicaciones"] = null;
                Session["LstPersonaEstudio"] = null;

                ViewBag.Bancos = Bancos;
                ViewBag.EstadoCivil = EstadoCivil;
                ViewBag.CatEstados = Estados;
                ViewBag.EstatusEstudios = EstatusEstudios;
                ViewBag.Estudios = Estudios;
                ViewBag.TipoCredito = TipoCredito;
                ViewBag.NivelIngles = NivelIngles;
                ViewBag.Empresas = Empresas;
                ViewBag.EsquemaContratacion = EsquemaContratacion;
                ViewBag.TipoExamen = TipoExamen;
                ViewBag.FuenteReclutamiento = FuenteReclutamiento;
                ViewBag.TipoDocumento = TipoDocumento;
                //ViewBag.Clientes = Clientes;
                ViewBag.Cursos = Cursos;
                ViewBag.Diplomados = Diplomados;
                ViewBag.Certificaciones = Certificaciones;
                ViewBag.Aplicaciones = cat_Aplicaciones;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }

        }

        [HttpPost]
        public JsonResult Empleados_ConsultaCURP(Models.Personas personas, Application.Personas APPersonas)
        {
            Models.Personas _personas = new Models.Personas();
            _personas = APPersonas.Empleados_ConsultaCURP(personas);
            return Json(_personas);
        }

        [HttpPost]
        public JsonResult CDC_NuevoEmpleado_Consultar()
        {
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            if (Session["ListaCDC"] != null)
            {
                personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
            }
            return Json(personasCDC);
        }

        [HttpPost]
        public JsonResult Empleados_NuevoEmpleado_AgregarImagen(Models.PersonasDetalle personasDetalle)
        {
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";
            Models.PersonasDetalle _PersonasDetalle = new Models.PersonasDetalle();
            string IMG = "";
            _PersonasDetalle = personasDetalle;
            _PersonasDetalle.NmArchivo = personasDetalle.NmArchivo;
            Session["PersonasIMG"] = _PersonasDetalle;
            IMG = DirectorioURL + _PersonasDetalle.NmArchivo;
            return Json(IMG);
        }

        [HttpPost]
        public JsonResult Empleados_NuevoEmpleado_ConsultarImagen()
        {
            Models.PersonasDetalle _PersonasDetalle = new Models.PersonasDetalle();
            if (Session["PersonasIMG"] != null)
            {
                _PersonasDetalle = (Models.PersonasDetalle)Session["PersonasIMG"];
            }
            return Json(_PersonasDetalle);
        }

        [HttpPost]
        public JsonResult Empleado_agregar(Models.Personas personas, Application.Personas APpersonas, Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado,
            Application.PersonasCertificaciones APpersonasCertificaciones, Application.PersonasEntrevistas APpersonasEntrevistas, Application.PersonasExamen personasExamen, Application.PersonasPsicometrico APpersonasPsicometrico, Application.PersonasDocumentos APpersonasDocumentos,
            Application.Cat_Almacenamiento APcat_Almacenamiento, Application.PersonasEstudios APpersonasEstudios, Application.PersonasAplicaciones APpersonasAplicaciones)
        {
            Models.PersonasDetalle _PersonasDetalle = new Models.PersonasDetalle();
            Models.PersonasExamen examen = new Models.PersonasExamen();
            Models.PersonasPsicometrico personasPsicometrico = new Models.PersonasPsicometrico();
            Models.PersonasCDC personasCDC = new Models.PersonasCDC();
            List<Models.PersonasEntrevistas> ListaEntrevitas = new List<Models.PersonasEntrevistas>();
            List<Models.PersonasDocumentos> LstPersonasDocumentos = new List<Models.PersonasDocumentos>();
            List<Models.Consultas.PersonaEstudio> LstPersonaEstudio = new List<Models.Consultas.PersonaEstudio>();
            List<Models.PersonasAplicaciones> ListaPersonasAplicaciones = new List<Models.PersonasAplicaciones>();

            string DirectorioUsuario = HttpContext.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            if (Session["PersonasIMG"] != null)
            {
                _PersonasDetalle = (Models.PersonasDetalle)Session["PersonasIMG"];
                personas.PersonasDetalle.NmOriginal = _PersonasDetalle.NmOriginal;
                personas.PersonasDetalle.NmArchivo = _PersonasDetalle.NmArchivo;
            }
            else
            {
                personas.PersonasDetalle.NmOriginal = "user4.png";
                personas.PersonasDetalle.NmArchivo = "394B1560E33CDE974FC7F49B9142D46BD000000000003.png";
            }

            personas.PersonasDetalle.Usuarios = Usuario;
            Models.Personas persona = APpersonas.Personas_Nuevo_Empleado(personas);

            if (persona.Id > 0)
            {
                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\FOTO"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\FOTOS");
                }
                // ALMACENAMIENTO DE IMAGEN
                string sourceFile = System.IO.Path.Combine(DirectorioUsuario, personas.PersonasDetalle.NmArchivo);
                string destFile = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\FOTOS", personas.PersonasDetalle.NmArchivo);

                System.IO.File.Copy(sourceFile, destFile, true);

                
                if(personas.PersonasDetalle.Estudios == 1)
                {
                    if (Session["LstPersonaEstudio"] != null)
                    {
                        LstPersonaEstudio = (List<Models.Consultas.PersonaEstudio>)Session["LstPersonaEstudio"];

                        foreach (var dt in LstPersonaEstudio)
                        {
                            dt.Personas = persona;
                            APpersonasEstudios.PersonasEstudios_Agregar(dt);

                            if (dt.NmArchivo != null)
                            {
                                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\ESTUDIOS"))
                                {
                                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\ESTUDIOS");
                                    string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, dt.NmArchivo);
                                    string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\ESTUDIOS", dt.NmArchivo);
                                    System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                                }
                            }
                        }

                    }
                }
                
                
                if (personas.PersonasDetalle.CDC == 1)
                {
                    if (Session["ListaCDC"] != null)
                    {
                        personasCDC = (Models.PersonasCDC)Session["ListaCDC"];
                    }

                    if (!(personasCDC.PersonasCursos is null))
                    {
                        foreach (var dt in personasCDC.PersonasCursos)
                        {
                            dt.Personas = persona;
                            APpersonasCursos.PersonasCursos_Agregar(dt);

                            if (dt.NmArchivo != null)
                            {
                                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CURSOS"))
                                {
                                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CURSOS");
                                    string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, dt.NmArchivo);
                                    string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CURSOS", dt.NmArchivo);
                                    System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                                }
                            }
                        }
                    }

                    if (!(personasCDC.PersonasDiplomados is null))
                    {
                        foreach (var dt in personasCDC.PersonasDiplomados)
                        {
                            dt.Personas = persona;
                            APpersonasDiplomado.PersonasDiplomado_Agregar(dt);

                            if (dt.NmArchivo != null)
                            {
                                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DIPLOMADOS"))
                                {
                                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DIPLOMADOS");
                                    string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, dt.NmArchivo);
                                    string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DIPLOMADOS", dt.NmArchivo);
                                    System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                                }
                            }
                        }
                    }

                    if (!(personasCDC.PersonasCertificaciones is null))
                    {
                        foreach (var dt in personasCDC.PersonasCertificaciones)
                        {
                            dt.Personas = persona;
                            APpersonasCertificaciones.PersonasCertificacion_Agregar(dt);

                            if (dt.NmArchivo != null)
                            {
                                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CERTIFICACIONES"))
                                {
                                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CERTIFICACIONES");
                                    string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, dt.NmArchivo);
                                    string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CERTIFICACIONES", dt.NmArchivo);
                                    System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                                }
                            }
                        }
                    }
                }

                
                if (Session["ListaEntrevitas"] != null)
                {
                    ListaEntrevitas = (List<Models.PersonasEntrevistas>)Session["ListaEntrevitas"];
               
                    foreach (var dt in ListaEntrevitas)
                    {
                        dt.Personas = persona;
                        APpersonasEntrevistas.PersonasEntrevistas_Agregar(dt);
                    }
                }

                if (Session["ListaAplicaciones"] != null)
                {
                    ListaPersonasAplicaciones = (List<Models.PersonasAplicaciones>)Session["ListaAplicaciones"];
                    foreach (var dt in ListaPersonasAplicaciones)
                    {
                        dt.Personas = persona;
                        APpersonasAplicaciones.PersonasAplicaciones_Agregar(dt);
                    }
                }

                if (personas.PersonasExamen.Id == 1)
                {
                    if (Session["Examen"] != null)
                    {
                        examen = (Models.PersonasExamen)Session["Examen"];
                        examen.Personas = persona;
                        examen.Cat_TipoExamen = personas.PersonasExamen.Cat_TipoExamen;
                        examen.Calificacion = personas.PersonasExamen.Calificacion;
                        examen.Califico = personas.PersonasExamen.Califico;
                        examen.FechaAplicacion = personas.PersonasExamen.FechaAplicacion;
                        examen.Observaciones = personas.PersonasExamen.Observaciones;
                        personasExamen.PersonasExamen_Agregar(examen);

                        if (examen.NmArchivo != null)
                        {
                            // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                            if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\EXAMEN"))
                            {
                                Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\EXAMEN");
                                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, examen.NmArchivo);
                                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\EXAMEN", examen.NmArchivo);
                                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                            }
                        }
                    }
                }

                if (personas.PersonasPsicometrico.Id == 1)
                {
                    if (Session["Prueba"] != null)
                    {
                        personasPsicometrico = (Models.PersonasPsicometrico)Session["Prueba"];
                        personasPsicometrico.Personas = persona;
                        personasPsicometrico.Califico = personas.PersonasPsicometrico.Califico;
                        personasPsicometrico.FechaAplicacion = personas.PersonasPsicometrico.FechaAplicacion;
                        personasPsicometrico.Observaciones = personas.PersonasPsicometrico.Observaciones;
                        APpersonasPsicometrico.PersonasPsicometrico_Agregar(personasPsicometrico);

                        if (personasPsicometrico.NmArchivo != null)
                        {
                            // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                            if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO"))
                            {
                                Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO");
                                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasPsicometrico.NmArchivo);
                                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO", personasPsicometrico.NmArchivo);
                                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
                            }
                        }

                    }
                }

                if (Session["ListaDocumentos"] != null)
                {
                    LstPersonasDocumentos = (List<Models.PersonasDocumentos>)Session["ListaDocumentos"];
                
                    if (LstPersonasDocumentos.Count > 0)
                    {
                        if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS"))
                        {
                            Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS");
                        }

                        foreach (var Docuemnto in LstPersonasDocumentos)
                        {
                            Models.DocumentoVersiones documentoVersiones = new Models.DocumentoVersiones();
                            documentoVersiones.Version = "1.0";

                            Docuemnto.Personas = persona;
                            Docuemnto.Usuarios = Usuario;
                            Docuemnto.DocumentoVersiones = documentoVersiones;
                            APpersonasDocumentos.PersonasDocumento_Agregar(Docuemnto);

                            if (Docuemnto.DocumentoVersiones.NmArchivo != null)
                            {
                                string sourceFileDoc = System.IO.Path.Combine(DirectorioUsuario, Docuemnto.DocumentoVersiones.NmArchivo);
                                string destFileDoc = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS", Docuemnto.DocumentoVersiones.NmArchivo);
                                System.IO.File.Copy(sourceFileDoc, destFileDoc, true);
                            }
                        }
                    }
                }
            }

            if (persona.Id > 0)
            {
                Session["LstPersonaEstudio"] = null;
                Session["ListaEntrevitas"] = null;
                Session["ListaDocumentos"] = null;
                Session["Prueba"] = null;
                Session["Examen"] = null;
                Session["ListaCDC"] = null;
                Session["PersonasIMG"] = null;
            }

            return Json(persona);
        }

        public ActionResult Editar(Application.Menu menu, Application.Cat_Banco cat_Banco, Application.Cat_EstadoCivil cat_EstadoCivil, Application.Cat_Estados cat_Estados, Application.Cat_EstatusEstudios cat_EstatusEstudios, Application.Cat_Estudios cat_Estudios, Application.Cat_TipoCredito cat_TipoCredito, Application.Cat_NivelIngles cat_NivelIngles, Application.Empresas APempresas,
            Application.Cat_EsquemaContratacion APcat_EsquemaContratacion, Application.Cat_TipoExamen APcat_TipoExamen, Application.Cat_FuenteReclutamiento APfuenteReclutamiento, Application.Cat_TipoDocumento APtipoDocumento, Application.Cat_Clientes APcat_Clientes,
            Application.Cat_Cursos APcat_Cursos, Application.Cat_Diplomados APcat_Diplomados, Application.Cat_Certificaciones APcat_Certificaciones, Application.PersonasEMails APpersonasEMails, Application.Personas APpersonas, Application.PersonasDirecciones APpersonasDirecciones,
            Application.PersonasExperiencia APpersonasExperiencia, Application.PersonasEntrevistas APpersonasEntrevistas, Application.PersonasExamen APpersonasExamen, Application.PersonasPsicometrico APpersonasPsicometrico, Application.PersonasDocumentos APPersonasDocumentos, Application.Cat_EstatusDocumento APcat_EstatusDocumento,
            Application.PersonasCertificaciones APpersonasCertificaciones, Application.PersonasCursos APpersonasCursos, Application.PersonasDiplomado APpersonasDiplomado, Application.PersonasEstudios APpersonasEstudios, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado, Application.PersonasAplicaciones APpersonasAplicaciones, Application.Cat_Aplicaciones APcat_Aplicaciones
            )
        
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                Models.Personas Persona = new Models.Personas();
                int IdPersona = 0;

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    string EmailPersonal = "";
                    string EmailCorporativo = "";
                    string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\DocumentosTemporales\\";

                    IdPersona = Convert.ToInt32(Request.QueryString["Id"].ToString());
                    Persona.Id = IdPersona;

                    List<Models.Cat_Banco> Bancos = cat_Banco.Cat_Banco_Selecionar_Listar();
                    List<Models.Cat_EstadoCivil> EstadoCivil = cat_EstadoCivil.Cat_EstadoCivil_Selecionar_Listar();
                    List<Models.Cat_Estados> Estados = cat_Estados.Cat_Estados_Seleccionar();
                    List<Models.Cat_EstatusEstudios> EstatusEstudios = cat_EstatusEstudios.Cat_EstatusEstudios_Selecionar_Listar();
                    List<Models.Cat_Estudios> Estudios = cat_Estudios.Cat_Estudios_Selecionar_Listar();
                    List<Models.Cat_TipoCredito> TipoCredito = cat_TipoCredito.Cat_TipoCredito_Selecionar_Listar();
                    List<Models.Cat_NivelIngles> NivelIngles = cat_NivelIngles.Cat_NivelIngles_Selecionar_Listar();
                    List<Models.Empresas> Empresas = APempresas.Empresas_Seleccionar();
                    List<Models.Cat_EsquemaContratacion> EsquemaContratacion = APcat_EsquemaContratacion.Cat_EsquemaContratacion_Seleccionar();
                    List<Models.Cat_TipoExamen> TipoExamen = APcat_TipoExamen.Cat_TipoExamen_Seleccionar();
                    List<Models.Cat_FuenteReclutamiento> FuenteReclutamiento = APfuenteReclutamiento.Cat_FuenteReclutamiento_Seleccionar();
                    List<Models.Cat_TipoDocumento> TipoDocumento = APtipoDocumento.Cat_TipoDocumento_Selecionar();
                    List<Models.Cat_Clientes> Clientes = APcat_Clientes.Cat_Clientes_Seleccionar();
                    List<Models.Cat_Cursos> Cursos = APcat_Cursos.Cat_Cursos_Seleccionar();
                    List<Models.Cat_Diplomados> Diplomados = APcat_Diplomados.Cat_Diplomados_Seleccionar();
                    List<Models.Cat_Certificaciones> Certificaciones = APcat_Certificaciones.Cat_Certificaciones_Seleccionar();
                    List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleados = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();
                    List<Models.Cat_Aplicaciones> cat_Aplicaciones = APcat_Aplicaciones.Cat_Aplicaciones_Seleccionar();


                    Models.Personas personas = APpersonas.Personas_Editar_Seleccionar_Id(Persona);
                    List<Models.PersonasEMails> personasEMails = APpersonasEMails.PersonasEMails_Seleccionar_IdPersona(Persona);

                    List<Models.Consultas.PersonaEstudio> personasEstudios = APpersonasEstudios.PersonasEstudios_Seleccionar_Editar_IdPersona(Persona);

                    Models.PersonasCDC personasCDC = new Models.PersonasCDC();
          
                    personasCDC.PersonasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(Persona); ;
                    personasCDC.PersonasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(Persona); ;
                    personasCDC.PersonasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(Persona); ;

                    Models.PersonasDirecciones personasDirecciones = APpersonasDirecciones.PersonasDirecciones_Editar_IdPersona(Persona);
                    Models.PersonasExperiencia personasExperiencia = APpersonasExperiencia.PersonasExperiencia_Editar_IdPersona(Persona);

                    List<Models.PersonasEntrevistas> personasEntrevistas = APpersonasEntrevistas.PersonasEntrevistas_Seleccionar_IdPersona(Persona);
                    Models.PersonasExamen personasExamen = APpersonasExamen.PersonasExamen_Editar_IdPersona(Persona);
                    Models.PersonasPsicometrico personasPsicometrico = APpersonasPsicometrico.PersonasPsicometrico_Editar_IdPersona(Persona);

                    List<Models.PersonasDocumentos> LstDocumentos = APPersonasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(Persona);

                    List<Models.PersonasAplicaciones> LstPersonasAplicaciones = APpersonasAplicaciones.PersonasAplicaciones_Seleccionar_IdPersona(Persona);

                    Session["PersonasIMG"] = personas.PersonasDetalle;
                    Session["Examen"] = personasExamen;
                    Session["Prueba"] = personasPsicometrico;

                    
                    if (personasExamen == null)
                    {
                        Models.Cat_TipoExamen cat_TipoExamen = new Models.Cat_TipoExamen();
                        Models.PersonasExamen personasExamen2 = new Models.PersonasExamen();
                        cat_TipoExamen.Id = 0;
                        personasExamen2.Id = 0;
                        personasExamen2.Cat_TipoExamen = cat_TipoExamen;
                        personasExamen = personasExamen2;
                    }

                    if (personasPsicometrico == null)
                    {
                        Models.PersonasPsicometrico personasPsicometrico2 = new Models.PersonasPsicometrico();
                        personasPsicometrico2.Id = 0;
                        personasPsicometrico = personasPsicometrico2;
                    }

                    foreach (var dt in personasEMails)
                    {
                        if (dt.Tipo == "Personal")
                        {
                            EmailPersonal = dt.EMail;
                        }

                        if (dt.Tipo == "Trabajo")
                        {
                            EmailCorporativo = dt.EMail;
                        }
                    }

                    ViewBag.Personas = personas;
                    ViewBag.PersonasCDC = personasCDC;
                    ViewBag.PersonasEstudios = personasEstudios;
                    ViewBag.Bancos = Bancos;
                    ViewBag.EstadoCivil = EstadoCivil;
                    ViewBag.CatEstados = Estados;
                    ViewBag.EstatusEstudios = EstatusEstudios;
                    ViewBag.Estudios = Estudios;
                    ViewBag.TipoCredito = TipoCredito;
                    ViewBag.Empresas = Empresas;
                    ViewBag.EsquemaContratacion = EsquemaContratacion;
                    ViewBag.TipoExamen = TipoExamen;
                    ViewBag.FuenteReclutamiento = FuenteReclutamiento;
                    ViewBag.TipoDocumento = TipoDocumento;
                    ViewBag.Clientes = Clientes;
                    ViewBag.Cursos = Cursos;
                    ViewBag.Diplomados = Diplomados;
                    ViewBag.Certificaciones = Certificaciones;
                    ViewBag.PersonasDirecciones = personasDirecciones;
                    ViewBag.PersonasExperiencia = personasExperiencia;
                    ViewBag.Entrevistas = personasEntrevistas;
                    ViewBag.Examen = personasExamen;
                    ViewBag.MotivosBajaEmpleados = cat_MotivosBajaEmpleados;
                    ViewBag.PersonasAplicaciones = LstPersonasAplicaciones;
                    ViewBag.Prueba = personasPsicometrico;
                    ViewBag.LstDocumentos = LstDocumentos;
                    ViewBag.Aplicaciones = cat_Aplicaciones;

                    ViewBag.EmailPersonal = EmailPersonal;
                    ViewBag.EmailCorporativo = EmailCorporativo;

                    ViewBag.Foto = DirectorioURL + personas.PersonasDetalle.NmArchivo;
                    
                    Session["NuevoExamen"] = null;
                    Session["NuevoPrueba"] = null;

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Empleados");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Empleados_Actualizar_Informacion_Basica(Models.Personas personas, Application.Personas APpersonas)
        {
            Models.Personas personas1 = new Models.Personas();
            personas1 = APpersonas.Personas_Actualizar_InformacionBasica(personas);
            return Json(personas1);
        }

        [HttpPost]
        public JsonResult Empleados_Actualizar_Direccion(Models.Personas Persona, Application.PersonasDirecciones APpersonasDirecciones)
        {
            Models.PersonasDirecciones personasDirecciones = APpersonasDirecciones.PersonasDirecciones_Actualizar_Direccion(Persona);
            return Json(personasDirecciones);
        }

        [HttpPost]
        public JsonResult Empleados_Actualizar_PuestoExperiencia(Models.Personas personas, Application.Personas APpersonas)
        {
            Models.Personas persona = APpersonas.Empleados_Actualizar_PuestoExperiencia(personas);
            return Json(persona);
        }

        [HttpPost]
        public JsonResult Empleados_Actualizar_InformacionIngreso(Models.Personas personas, Application.Personas APpersonas)
        {
            Models.PersonasDetalle _PersonasDetalle = new Models.PersonasDetalle();
            if (Session["PersonasIMG"] != null)
            {
                _PersonasDetalle = (Models.PersonasDetalle)Session["PersonasIMG"];
            }
            personas.PersonasDetalle.NmArchivo = _PersonasDetalle.NmArchivo;
            personas.PersonasDetalle.NmOriginal = _PersonasDetalle.NmOriginal;

            Models.Personas personas1 = APpersonas.PersonasDetalle_Actualizar_IdPersona(personas);
            return Json(personas1);
        }

        public ActionResult Consulta(Application.Menu menu, Application.Personas APpersonas, Application.PersonasEMails APpersonasEMails, Application.PersonasCursos APpersonasCursos,
            Application.PersonasDiplomado APpersonasDiplomado, Application.PersonasCertificaciones APpersonasCertificaciones, Application.PersonasDirecciones APpersonasDirecciones,
            Application.PersonasExperiencia APpersonasExperiencia, Application.PersonasEntrevistas APpersonasEntrevistas, Application.PersonasExamen APpersonasExamen, Application.PersonasPsicometrico APpersonasPsicometrico,
            Application.PersonasDocumentos APpersonasDocumentos, Application.Cat_Almacenamiento APcat_Almacenamiento, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado, Application.PersonasAplicaciones APpersonasAplicaciones
            )
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            Models.Personas Persona = new Models.Personas();

            int IdPersona = 0;

            if (menu.ValidacionPagina(Usuario, url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    IdPersona = Convert.ToInt32(Request.QueryString["Id"].ToString());
                    Persona.Id = IdPersona;
                    Models.Personas personas = APpersonas.Personas_Seleccionar_Id(Persona);
                    List<Models.PersonasEMails> personasEMails = APpersonasEMails.PersonasEMails_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasCursos> personasCursos = APpersonasCursos.PersonasCursos_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasDiplomados> personasDiplomados = APpersonasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasCertificacion> personasCertificaciones = APpersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasDirecciones> personasDirecciones = APpersonasDirecciones.PersonasDirecciones_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasExperiencia> personasExperiencias = APpersonasExperiencia.PersonasExperiencia_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasEntrevistas> personasEntrevistas = APpersonasEntrevistas.PersonasEntrevistas_Seleccionar_IdPersona(Persona);
                    Models.PersonasExamen personasExamen = APpersonasExamen.PersonasExamen_Seleccionar_IdPersona(Persona);
                    Models.PersonasPsicometrico personasPsicometrico = APpersonasPsicometrico.PersonasPsicometrico_Seleccionar_IdPersona(Persona);
                    List<Models.PersonasDocumentos> LstDocumentos = APpersonasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(Persona);
                    List<Models.Consultas.PersonasDocumento_PorcentajeEstatus> DocumentoPorcentaje = APpersonasDocumentos.PersonasDocumento_Estatus_Seleccionar_IdPersona(Persona);
                    List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleados = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();
                    List<Models.PersonasAplicaciones> LstPersonasAplicaciones = APpersonasAplicaciones.PersonasAplicaciones_Seleccionar_IdPersona(Persona);

                    ViewBag.Foto = personas.PersonasDetalle.NmArchivo;
                    ViewBag.Personas = personas;
                    ViewBag.PersonasEMails = personasEMails;
                    ViewBag.PersonasCursos = personasCursos;
                    ViewBag.PersonasDiplomados = personasDiplomados;
                    ViewBag.PersonasCertificaciones = personasCertificaciones;
                    ViewBag.PersonasDirecciones = personasDirecciones;
                    ViewBag.PersonasExperiencia = personasExperiencias;
                    ViewBag.Entrevistas = personasEntrevistas;
                    ViewBag.Examen = personasExamen;
                    ViewBag.Prueba = personasPsicometrico;
                    ViewBag.Documento = LstDocumentos;
                    ViewBag.DocumentoPorcentaje = DocumentoPorcentaje;
                    ViewBag.MotivosBajaEmpleados = cat_MotivosBajaEmpleados;
                    ViewBag.PersonasAplicaciones = LstPersonasAplicaciones;

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Empleados");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Empleados_DarDeBaja(Models.Consultas.EmpleadoBaja empleadoBaja, Application.Empleados APempleados, Application.EmpleadosMotivosBaja APempleadosMotivosBaja)
        {
            Models.Empleados empleados = APempleados.Empleados_DarDeBaja(empleadoBaja.Personas);

            if (empleadoBaja.cat_MotivosBajaEmpleados is null)
            {
                
            }
            else
            {
                foreach (var Motivo in empleadoBaja.cat_MotivosBajaEmpleados)
                {
                    APempleadosMotivosBaja.EmpleadosMotivosBaja_Agregar(empleadoBaja.Personas, Motivo);
                }
            }
            
            return Json(empleados);
        }

        [HttpPost]
        public JsonResult Empleados_DarDeAlta(Models.Personas personas, Application.Empleados APEmpleados)
        {
            Models.Empleados empleados = APEmpleados.Empleados_DarDeAlta(personas);
            return Json(empleados);
        }


        public ActionResult Baja(Application.Menu menu, Application.Empleados ApEmpleados)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Consultas.Empleados> empleados = new List<Models.Consultas.Empleados>();
                empleados = ApEmpleados.Empleados_Listar_Consulta(5);
                
                ViewBag.Empleados = empleados;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }
    }
}
