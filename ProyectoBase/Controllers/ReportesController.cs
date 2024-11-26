using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class ReportesController : Controller
    {
        Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: Reportes
        public ActionResult Index(Application.Menu menu, Application.Empleados ApEmpleados, Application.Reportes APReportes)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                DataTable table = APReportes.Reporte_Empleados_Documentos();
                string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    table.TableName = "Empleados";/*Giving table name is mandatory and it must be unique between multiple worksheets*/
                    workbook.Worksheets.Add(table);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Reporte empleados documentos check list -"+ date +".xlsx");
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
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult ReporteProcentaje(Application.Menu menu, Application.Empleados ApEmpleados, Application.Reportes APReportes)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                DataTable table = APReportes.Reporte_Empleados_Documentos_Procentaje();
                string date = DateTime.UtcNow.ToString("dd-MM-yyyy");
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dt);

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    table.TableName = "Empleados";/*Giving table name is mandatory and it must be unique between multiple worksheets*/
                    workbook.Worksheets.Add(table);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Reporte empleados documentos check list porcentajes -" + date + ".xlsx");
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
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        public ActionResult DocumentosCliente(Application.Menu menu, Application.Empresas APempresas)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            if (menu.ValidacionPagina(Usuario, url))
            {
                List<Models.Empresas> Empresas = APempresas.Empresas_Seleccionar();
                ViewBag.Empresas = Empresas;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

    }
}
