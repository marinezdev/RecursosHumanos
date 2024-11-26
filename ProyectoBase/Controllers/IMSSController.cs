using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace ProyectoBase.Controllers
{
    public class IMSSController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: IMSS
        public ActionResult Index(Application.Menu menu)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                Session["LstArchivosIMSS"] = null;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult Descarga(Application.Menu menu, Application.Cat_Cuatrimestre APcat_Cuatrimestre, Application.ArchivoQuincena AParchivoQuincena)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Cat_Cuatrimestre> cat_Cuatrimestres = APcat_Cuatrimestre.Cat_Cuatrimestre_Seleccionar();
                List<Models.ArchivoQuincena> archivoQuincenas = AParchivoQuincena.ArchivoQuincena_Consultar_Years();
                ViewBag.cat_Cuatrimestres = cat_Cuatrimestres;
                ViewBag.Quincenas = archivoQuincenas;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult IMSS_Archivo_Agregar(List<Models.ArchivoQuincena> archivoQuincenas, Application.Cat_Quincena APcat_Quincena, Application.ArchivoQuincena AParchivoQuincena)
        {
            List<Models.ArchivoQuincena> LstArchivoQuincena = new List<Models.ArchivoQuincena>();

            if (Session["LstArchivosIMSS"] != null)
            {
                LstArchivoQuincena = (List<Models.ArchivoQuincena>)Session["LstArchivosIMSS"];
            }

            char delimitador = ' ';
            foreach (var Quincena in archivoQuincenas)
            {
                Models.ArchivoQuincena archivoQuincena = new Models.ArchivoQuincena();
                Models.Cat_Quincena cat_Quincena = new Models.Cat_Quincena();

                string _Nombre = Quincena.NmOriginal.Remove((Quincena.NmOriginal.Length-4),4);

                string[] valores = _Nombre.Split(delimitador);

                cat_Quincena.Nombre = valores[3];
                cat_Quincena.Mes = valores[4];

                archivoQuincena.Cat_Quincena = APcat_Quincena.Cat_Quincena_Selecionar_Quincena(cat_Quincena);
                archivoQuincena.Year = Convert.ToInt32(valores[5]);
                archivoQuincena.NmArchivo = Quincena.NmArchivo;
                archivoQuincena.NmOriginal = Quincena.NmOriginal;
                archivoQuincena.Resgistro = AParchivoQuincena.ArchivoQuincena_Consultar(archivoQuincena).Resgistro;


                LstArchivoQuincena.Add(archivoQuincena);
            }

            LstArchivoQuincena.Sort((x, y) => string.Compare(x.NmOriginal, y.NmOriginal));
            Session["LstArchivosIMSS"] = LstArchivoQuincena;
            return Json(LstArchivoQuincena);
        }

        [HttpPost]
        public JsonResult IMSS_Archivo_Eliminar(Models.ArchivoQuincena archivoQuincena)
        {
            List<Models.ArchivoQuincena> LstArchivoQuincena = new List<Models.ArchivoQuincena>();

            if (Session["LstArchivosIMSS"] != null)
            {
                LstArchivoQuincena = (List<Models.ArchivoQuincena>)Session["LstArchivosIMSS"];
            }
            LstArchivoQuincena.Remove(LstArchivoQuincena[archivoQuincena.Id]);

            LstArchivoQuincena.Sort((x, y) => string.Compare(x.NmOriginal, y.NmOriginal));
            Session["LstArchivosIMSS"] = LstArchivoQuincena;
            return Json(LstArchivoQuincena);
        }

        [HttpPost]
        public JsonResult IMSS_Archivo_Registrar(Application.ArchivoQuincena AParchivoQuincena)
        {
            bool rsult = false;
            List<Models.ArchivoQuincena> LstArchivoQuincena = new List<Models.ArchivoQuincena>();
            string DirectorioUsuario = System.Web.HttpContext.Current.Request.Url.Authority  + "\\DocumentosIMSS\\";

            if (Session["LstArchivosIMSS"] != null)
            {
                LstArchivoQuincena = (List<Models.ArchivoQuincena>)Session["LstArchivosIMSS"];
            }

            if(LstArchivoQuincena.Count > 0)
            {
                rsult = true;
                // Lectura e inserccion a base de datos.
                foreach (var Quincena in LstArchivoQuincena)
                {
                    if(!Quincena.Resgistro)
                    {
                        Quincena.Usuarios = Usuario;
                        AParchivoQuincena.ArchivoQuincena_Cargatxt(Quincena);
                    }
                }
            }

            return Json(rsult);
        }

        public ActionResult IMSS_Generar_Reporte(Application.ArchivoQuincena AParchivoQuincena)
        {
            int IdCuatrimestre = 0;
            int Year = 0;
            IdCuatrimestre = Convert.ToInt32(Request.QueryString["IdCuatrimestre"].ToString());
            Year = Convert.ToInt32(Request.QueryString["Year"].ToString());

            Models.ArchivoQuincena archivoQuincena = new Models.ArchivoQuincena();
            archivoQuincena.Year = Year;
            Models.Cat_Cuatrimestre cat_Cuatrimestre = new Models.Cat_Cuatrimestre();
            cat_Cuatrimestre.Id = IdCuatrimestre;
            cat_Cuatrimestre.ArchivoQuincena = archivoQuincena;

            DataTable reporte = AParchivoQuincena.ArchivoQuincena_GeneraReporte(cat_Cuatrimestre);

            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);

            using (XLWorkbook workbook = new XLWorkbook())
            {
                reporte.TableName = "Empleados";/*Giving table name is mandatory and it must be unique between multiple worksheets*/
                workbook.Worksheets.Add(reporte);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Reporte IMSS -" + date + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    workbook.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                }

            }

            Response.Flush();
            Response.End();
            return View();
            
        }


        [HttpPost]
        public JsonResult IMSS_Generar_Archivo(Models.Cat_Cuatrimestre cat_Cuatrimestre, Application.ArchivoQuincena AParchivoQuincena)
        {
            DataTable reporte = AParchivoQuincena.ArchivoQuincena_GeneraReporte(cat_Cuatrimestre);

            string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);

            using (XLWorkbook workbook = new XLWorkbook())
            {
                reporte.TableName = "Empleados";/*Giving table name is mandatory and it must be unique between multiple worksheets*/
                workbook.Worksheets.Add(reporte);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Reporte IMSS -" + date + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    workbook.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                }

            }

            Response.Flush();
            Response.End();


            return Json("");
        }

    }
}
