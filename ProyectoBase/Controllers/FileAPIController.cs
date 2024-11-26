using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProyectoBase.Controllers
{
    public class FileAPIController : ApiController
    {
        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesExamen")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            Models.PersonasExamen personasExamen = new Models.PersonasExamen();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                personasExamen = control_Archivos.NuevoArchivoExamen(POT, DirectorioUsuario);
                
            }
            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, personasExamen);
        }

        [Route("api/FileAPI/UploadFilesDocumento")]
        [HttpPost]
        public HttpResponseMessage UploadFilesDocumento()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            Models.DocumentoVersiones Documentos = new Models.DocumentoVersiones();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Documentos = control_Archivos.NuevoArchivoDocumento(POT, DirectorioUsuario);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Documentos);
        }

        [Route("api/FileAPI/UploadFilesImagen")]
        [HttpPost]
        public HttpResponseMessage UploadFilesImagen()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            Models.PersonasDetalle personasDetalle = new Models.PersonasDetalle();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                personasDetalle = control_Archivos.NuevaImagen(POT, DirectorioUsuario);
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, personasDetalle);
        }

        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesEstudios")]
        [HttpPost]
        public HttpResponseMessage UploadFilesEstudios()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            Models.PersonasEstudios _Estudios = new Models.PersonasEstudios(); 

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                _Estudios = control_Archivos.NuevoArchivoEstudio(POT, DirectorioUsuario);
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, _Estudios);
        }

        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesIMSS")]
        [HttpPost]
        public HttpResponseMessage UploadFilesIMSS()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosIMSS\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.ArchivoQuincena> LstArchivosQuincenas = new List<Models.ArchivoQuincena>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.ArchivoQuincena _ArchivoQuincena = new Models.ArchivoQuincena();
                _ArchivoQuincena = control_Archivos.NuevoArchivoIMSS(POT, DirectorioUsuario);
                if (_ArchivoQuincena.NmArchivo != null)
                {
                    LstArchivosQuincenas.Add(_ArchivoQuincena);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstArchivosQuincenas);
        }

        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesProspectos")]
        [HttpPost]
        public HttpResponseMessage UploadFilesProspectos()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosProspectos\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.ArchivoProspecto> LstArchivoProspecto = new List<Models.ArchivoProspecto>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.ArchivoProspecto _ArchivoProspecto = new Models.ArchivoProspecto();
                _ArchivoProspecto = control_Archivos.NuevoArchivoProspectos(POT, DirectorioUsuario);
                if (_ArchivoProspecto.NmArchivo != null)
                {
                    LstArchivoProspecto.Add(_ArchivoProspecto);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstArchivoProspecto);
        }

        [Route("api/FileAPI/UploadFilesCVProspecto")]
        [HttpPost]
        public HttpResponseMessage UploadFilesCVProspecto()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            Models.ProspectoArchivo Documentos = new Models.ProspectoArchivo();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Documentos = control_Archivos.NuevoArchivoCVProspectos(POT, DirectorioUsuario);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Documentos);
        }
    }
}
