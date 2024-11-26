using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBase.Controllers
{
    public class PDFController : Controller
    {
        // GET: PDF
        public ActionResult Index(Application.PersonasDocumentos APpersonasDocumentos, Application.Personas ApPersonas, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.Personas Persona = new Models.Personas();

            int IdPersona = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["num"]))
            {
                IdPersona = Convert.ToInt32(Request.QueryString["num"].ToString());
                Persona.Id = IdPersona;
                Models.Personas personas = ApPersonas.Personas_Seleccionar_Id(Persona);
                List<Models.PersonasDocumentos> documentos = APpersonasDocumentos.PersonasDocumento_Documento_Seleccionar_IdPersona(Persona);
                //List<Models.Documento> documentosPDF = documento.PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(Persona);
                string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;


                string Imagen3 = "";
                Imagen3 = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\FOTOS" + @"\" + personas.PersonasDetalle.NmArchivo;

                if (!System.IO.File.Exists(Imagen3))
                {
                    Imagen3 = HttpContext.Server.MapPath("~") + @"\" + "Images\\Headers\\user4.png";
                }

                string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";
                PdfReader reader = new PdfReader(Portada);


                MemoryStream ms = new MemoryStream();
                //Document document = new Document();
                //PdfCopy pdfCopy = new PdfCopy(document, ms);


                //rutas de nuestros pdf
                string pathPDF = Portada;
                //string pathPDF2 = @"C:\con_texto.pdf";

                //Objeto para leer el pdf original
                PdfReader oReader = new PdfReader(pathPDF);
                //Objeto que tiene el tamaño de nuestro documento
                Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                Document oDocument = new Document(oSize);

                // Creamos el objeto en el cual haremos la inserción
                //FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                PdfWriter oWriter = PdfWriter.GetInstance(oDocument, ms);

                oDocument.Open();

                PdfPCell cell = null;
                PdfPTable table = new PdfPTable(10);
                iTextSharp.text.Font fNegroBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fNegro = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                string Imagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\AsaeLogo_Colores.png";
                var logo = iTextSharp.text.Image.GetInstance(Imagen);
                logo.SetAbsolutePosition(40, 700);
                logo.ScaleAbsoluteHeight(65);
                logo.ScaleAbsoluteWidth(65);
                oDocument.Add(logo);

                string Imagen2 = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\FOOTER.png";
                var logo2 = iTextSharp.text.Image.GetInstance(Imagen2);
                logo2.SetAbsolutePosition(80, 30);
                logo2.ScaleAbsoluteHeight(270);
                logo2.ScaleAbsoluteWidth(500);
                oDocument.Add(logo2);

                //string Imagen3 = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\FOOTER.png";
                var logo3 = iTextSharp.text.Image.GetInstance(Imagen3);
                logo3.SetAbsolutePosition(60, 520);
                logo3.ScaleAbsoluteHeight(80);
                logo3.ScaleAbsoluteWidth(80);
                oDocument.Add(logo3);


                table.WidthPercentage = 100;
                table.SpacingBefore = 100F;

                cell = new PdfPCell(new Phrase("\n", fNegroBold));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("\n FOLIO: " + personas.PersonasFolio.FolioCompuesto, fNegroBold));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;


                if( personas.ApMaterno == null)
                {
                    personas.ApMaterno = "";
                }

                cell = new PdfPCell(new Phrase("\n\n\n\nNOMBRE: " + personas.Nombre.ToUpper() + " " + personas.ApPaterno.ToUpper() + " " + personas.ApMaterno.ToUpper() + "", fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 46f;
                cell.MinimumHeight = 46f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("PUESTO: " + personas.Empleados.EmpresaPuestos.Nombre.ToUpper(), fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("CLIENTE: " + personas.PersonasDetalle.Cat_Clientes.Nombre.ToUpper(), fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("PROYECTO: " + personas.PersonasDetalle.Cat_ProyectoServicios.Nombre.ToUpper(), fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("\nIMAGEN FOTO GRAFICA:", fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("\n\n\n\n\n\n\n\n\n\n\n CHECKLIST DE DOCUMENTOS ENTREGADOS \n\n\n", fNegroBold));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                foreach (Models.PersonasDocumentos oDocumento in documentos)
                {

                    cell = new PdfPCell(new Phrase(oDocumento.Cat_TipoDocumento.Nombre, fNegroBold));
                    cell.Colspan = 8;
                    cell.FixedHeight = 15f;
                    cell.MinimumHeight = 15f;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = null;

                    if (oDocumento.Cat_EstatusDocumento.Nombre == "Entregado")
                    {
                        string directorioImagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\3917090.png";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(directorioImagen);
                        jpg.ScaleAbsoluteHeight(11);
                        jpg.ScaleAbsoluteWidth(11);
                        PdfPCell imageCell = new PdfPCell(jpg);
                        imageCell.Colspan = 2; // either 1 if you need to insert one cell
                        imageCell.Border = 0;
                        imageCell.MinimumHeight = 15f;
                        imageCell.FixedHeight = 15f;
                        imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(imageCell);
                        imageCell = null;
                    }
                    else if (oDocumento.Cat_EstatusDocumento.Nombre == "No Aplica")
                    {
                        string directorioImagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\NOAPLICA.png";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(directorioImagen);
                        jpg.ScaleAbsoluteHeight(11);
                        jpg.ScaleAbsoluteWidth(11);
                        PdfPCell imageCell = new PdfPCell(jpg);
                        imageCell.Colspan = 2; // either 1 if you need to insert one cell
                        imageCell.Border = 0;
                        imageCell.MinimumHeight = 15f;
                        imageCell.FixedHeight = 15f;
                        imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(imageCell);
                        imageCell = null;
                    }
                    else
                    {
                        string directorioImagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\152596.png";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(directorioImagen);
                        jpg.ScaleAbsoluteHeight(11);
                        jpg.ScaleAbsoluteWidth(11);
                        PdfPCell imageCell = new PdfPCell(jpg);
                        imageCell.Colspan = 2; // either 1 if you need to insert one cell
                        imageCell.Border = 0;
                        imageCell.MinimumHeight = 15f;
                        imageCell.FixedHeight = 15f;
                        imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(imageCell);
                        imageCell = null;
                    }
                }


                oDocument.Add(table);

                //foreach (Models.Documento oDocumento in documentosPDF)
                //{
                //    string ruta = folderPath + @"\" + personas.Folio + @"\DOCUMENTOS" + @"\" + oDocumento.NmArchivo;
                //    PdfContentByte cb = oWriter.DirectContent;
                //    var pdfReader2 = new PdfReader(ruta);
                //    var n = pdfReader2.NumberOfPages;
                //    for (var page = 0; page < n;)
                //    {
                //        oDocument.NewPage();
                //        PdfImportedPage pagina = oWriter.GetImportedPage(pdfReader2, ++page);
                //        cb.AddTemplate(pagina, 0, 0);
                //    }
                //}


                oDocument.Close();

                Byte[] FileBuffer = ms.ToArray();

                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }



            return View();
        }


        public ActionResult PDF(Application.PersonasDocumentos APpersonasDocumentos, Application.Personas ApPersonas, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.Personas Persona = new Models.Personas();
            Models.PersonasDocumentos documento = new Models.PersonasDocumentos();
            int IdDocumento = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["num"]))
            {
                IdDocumento = Convert.ToInt32(Request.QueryString["num"].ToString());
                documento.Id = IdDocumento;
                Models.PersonasDocumentos dtDocumento = APpersonasDocumentos.PersonasDocumento_Seleccionar_Id(documento);

                Persona.Id = dtDocumento.Personas.Id;
                Models.Personas personas = ApPersonas.Personas_Seleccionar_Id(Persona);
                string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

                //string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";
                string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";

                PdfReader reader = new PdfReader(Portada);

                MemoryStream ms = new MemoryStream();
                //Document document = new Document();
                //PdfCopy pdfCopy = new PdfCopy(document, ms);


                //rutas de nuestros pdf
                string pathPDF = Portada;
                //string pathPDF2 = @"C:\con_texto.pdf";

                //Objeto para leer el pdf original
                PdfReader oReader = new PdfReader(pathPDF);
                //Objeto que tiene el tamaño de nuestro documento
                Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                Document oDocument = new Document(oSize);

                // Creamos el objeto en el cual haremos la inserción
                //FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                PdfWriter oWriter = PdfWriter.GetInstance(oDocument, ms);

                oDocument.Open();


                string ruta = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS" + @"\" + dtDocumento.DocumentoVersiones.NmArchivo;
                PdfContentByte cb = oWriter.DirectContent;
                var pdfReader2 = new PdfReader(ruta);
                var n = pdfReader2.NumberOfPages;
                for (var page = 0; page < n;)
                {
                    oDocument.NewPage();
                    PdfImportedPage pagina = oWriter.GetImportedPage(pdfReader2, ++page);
                    cb.AddTemplate(pagina, 0, 0);
                }

                oDocument.Close();

                Byte[] FileBuffer = ms.ToArray();

                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }

            return View();
        }


        // GET: PDF
        public ActionResult Expediente(Application.PersonasDocumentos  APpersonasDocumentos, Application.Personas ApPersonas, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.Personas Persona = new Models.Personas();

            int IdPersona = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["num"]))
            {
                IdPersona = Convert.ToInt32(Request.QueryString["num"].ToString());
                Persona.Id = IdPersona;
                Models.Personas personas = ApPersonas.Personas_Seleccionar_Id(Persona);
                List<Models.PersonasDocumentos> documentos = APpersonasDocumentos.PersonasDocumento_Documento_Seleccionar_IdPersona(Persona);
                List<Models.PersonasDocumentos> documentosPDF = APpersonasDocumentos.PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(Persona);
                string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;


                string Imagen3 = "";
                Imagen3 = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\FOTOS" + @"\" + personas.PersonasDetalle.NmArchivo;

                if (!System.IO.File.Exists(Imagen3))
                {
                    Imagen3 = HttpContext.Server.MapPath("~") + @"\" + "Images\\Headers\\user4.png";
                }

                string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";
                PdfReader reader = new PdfReader(Portada);


                MemoryStream ms = new MemoryStream();
                //Document document = new Document();
                //PdfCopy pdfCopy = new PdfCopy(document, ms);


                //rutas de nuestros pdf
                string pathPDF = Portada;
                //string pathPDF2 = @"C:\con_texto.pdf";

                //Objeto para leer el pdf original
                PdfReader oReader = new PdfReader(pathPDF);
                //Objeto que tiene el tamaño de nuestro documento
                Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                Document oDocument = new Document(oSize);

                // Creamos el objeto en el cual haremos la inserción
                //FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                PdfWriter oWriter = PdfWriter.GetInstance(oDocument, ms);

                oDocument.Open();

                PdfPCell cell = null;
                PdfPTable table = new PdfPTable(10);
                iTextSharp.text.Font fNegroBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fNegro = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                string Imagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\AsaeLogo_Colores.png";
                var logo = iTextSharp.text.Image.GetInstance(Imagen);
                logo.SetAbsolutePosition(40, 700);
                logo.ScaleAbsoluteHeight(65);
                logo.ScaleAbsoluteWidth(65);
                oDocument.Add(logo);

                string Imagen2 = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\FOOTER.png";
                var logo2 = iTextSharp.text.Image.GetInstance(Imagen2);
                logo2.SetAbsolutePosition(80, 30);
                logo2.ScaleAbsoluteHeight(270);
                logo2.ScaleAbsoluteWidth(500);
                oDocument.Add(logo2);

                //string Imagen3 = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\FOOTER.png";
                var logo3 = iTextSharp.text.Image.GetInstance(Imagen3);
                logo3.SetAbsolutePosition(60, 520);
                logo3.ScaleAbsoluteHeight(80);
                logo3.ScaleAbsoluteWidth(80);
                oDocument.Add(logo3);


                table.WidthPercentage = 100;
                table.SpacingBefore = 100F;

                cell = new PdfPCell(new Phrase("\n", fNegroBold));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("\n FOLIO: " + personas.PersonasFolio.FolioCompuesto, fNegroBold));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                if (personas.ApMaterno == null)
                {
                    personas.ApMaterno = "";
                }

                cell = new PdfPCell(new Phrase("\n\n\n\nNOMBRE: " + personas.Nombre.ToUpper() + " " + personas.ApPaterno.ToUpper() + " " + personas.ApMaterno.ToUpper() + "", fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 46f;
                cell.MinimumHeight = 46f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("PUESTO: " + personas.Empleados.EmpresaPuestos.Nombre.ToUpper(), fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("CLIENTE: " + personas.PersonasDetalle.Cat_Clientes.Nombre.ToUpper(), fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("PROYECTO: " + personas.PersonasDetalle.Cat_ProyectoServicios.Nombre.ToUpper(), fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("\nIMAGEN FOTO GRAFICA:", fNegro));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                cell = new PdfPCell(new Phrase("\n\n\n\n\n\n\n\n\n\n\n CHECKLIST DE DOCUMENTOS ENTREGADOS \n\n\n", fNegroBold));
                cell.Colspan = 10;
                cell.FixedHeight = 15f;
                cell.MinimumHeight = 15f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                table.AddCell(cell);
                cell = null;

                foreach (Models.PersonasDocumentos oDocumento in documentos)
                {

                    cell = new PdfPCell(new Phrase(oDocumento.Cat_TipoDocumento.Nombre, fNegroBold));
                    cell.Colspan = 8;
                    cell.FixedHeight = 15f;
                    cell.MinimumHeight = 15f;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = 0;
                    table.AddCell(cell);
                    cell = null;

                    if (oDocumento.Cat_EstatusDocumento.Nombre == "Entregado")
                    {
                        string directorioImagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\3917090.png";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(directorioImagen);
                        jpg.ScaleAbsoluteHeight(11);
                        jpg.ScaleAbsoluteWidth(11);
                        PdfPCell imageCell = new PdfPCell(jpg);
                        imageCell.Colspan = 2; // either 1 if you need to insert one cell
                        imageCell.Border = 0;
                        imageCell.MinimumHeight = 15f;
                        imageCell.FixedHeight = 15f;
                        imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(imageCell);
                        imageCell = null;
                    }
                    else if (oDocumento.Cat_EstatusDocumento.Nombre == "No Aplica")
                    {
                        string directorioImagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\NOAPLICA.png";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(directorioImagen);
                        jpg.ScaleAbsoluteHeight(11);
                        jpg.ScaleAbsoluteWidth(11);
                        PdfPCell imageCell = new PdfPCell(jpg);
                        imageCell.Colspan = 2; // either 1 if you need to insert one cell
                        imageCell.Border = 0;
                        imageCell.MinimumHeight = 15f;
                        imageCell.FixedHeight = 15f;
                        imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(imageCell);
                        imageCell = null;
                    }
                    else
                    {
                        string directorioImagen = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\152596.png";
                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(directorioImagen);
                        jpg.ScaleAbsoluteHeight(11);
                        jpg.ScaleAbsoluteWidth(11);
                        PdfPCell imageCell = new PdfPCell(jpg);
                        imageCell.Colspan = 2; // either 1 if you need to insert one cell
                        imageCell.Border = 0;
                        imageCell.MinimumHeight = 15f;
                        imageCell.FixedHeight = 15f;
                        imageCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(imageCell);
                        imageCell = null;
                    }
                }


                oDocument.Add(table);

                foreach (Models.PersonasDocumentos oDocumento in documentosPDF)
                {
                    string ruta1 = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS" + @"\" + oDocumento.DocumentoVersiones.NmArchivo;
                    if (System.IO.File.Exists(ruta1))
                    {
                        string ruta = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS" + @"\" + oDocumento.DocumentoVersiones.NmArchivo;
                        PdfContentByte cb = oWriter.DirectContent;

                        var pdfReader2 = new PdfReader(ruta);
                        var n = pdfReader2.NumberOfPages;
                        for (var page = 0; page < n;)
                        {
                            oDocument.NewPage();
                            PdfImportedPage pagina = oWriter.GetImportedPage(pdfReader2, ++page);
                            cb.AddTemplate(pagina, 0, 0);
                        }
                    }
                }


                oDocument.Close();

                Byte[] FileBuffer = ms.ToArray();

                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }



            return View();
        }



        public ActionResult Examen(Application.PersonasExamen APpersonasExamen, Application.Personas ApPersonas, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.Personas Persona = new Models.Personas();
            Models.PersonasExamen _personasExamen = new Models.PersonasExamen();
            int IdExamen = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["num"]))
            {
                IdExamen = Convert.ToInt32(Request.QueryString["num"].ToString());
                _personasExamen.Id = IdExamen;
                Models.PersonasExamen dtDocumento = APpersonasExamen.PersonasExamen_Seleccionar_Id(_personasExamen);

                Persona.Id = dtDocumento.Personas.Id;
                Models.Personas personas = ApPersonas.Personas_Seleccionar_Id(Persona);
                string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

                //string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";
                string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";

                PdfReader reader = new PdfReader(Portada);

                MemoryStream ms = new MemoryStream();
                //Document document = new Document();
                //PdfCopy pdfCopy = new PdfCopy(document, ms);


                //rutas de nuestros pdf
                string pathPDF = Portada;
                //string pathPDF2 = @"C:\con_texto.pdf";

                //Objeto para leer el pdf original
                PdfReader oReader = new PdfReader(pathPDF);
                //Objeto que tiene el tamaño de nuestro documento
                Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                Document oDocument = new Document(oSize);

                // Creamos el objeto en el cual haremos la inserción
                //FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                PdfWriter oWriter = PdfWriter.GetInstance(oDocument, ms);

                oDocument.Open();


                string ruta = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\EXAMEN" + @"\" + dtDocumento.NmArchivo;
                PdfContentByte cb = oWriter.DirectContent;
                var pdfReader2 = new PdfReader(ruta);
                var n = pdfReader2.NumberOfPages;
                for (var page = 0; page < n;)
                {
                    oDocument.NewPage();
                    PdfImportedPage pagina = oWriter.GetImportedPage(pdfReader2, ++page);
                    cb.AddTemplate(pagina, 0, 0);
                }

                oDocument.Close();

                Byte[] FileBuffer = ms.ToArray();

                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }

            return View();
        }


        public ActionResult Prueba(Application.PersonasPsicometrico APpersonasPsicometrico, Application.Personas ApPersonas, Application.Cat_Almacenamiento APcat_Almacenamiento)
        {
            Models.Personas Persona = new Models.Personas();
            Models.PersonasPsicometrico prueba = new Models.PersonasPsicometrico();
            int IdPrueba = 0;

            if (!String.IsNullOrEmpty(Request.QueryString["num"]))
            {
                IdPrueba = Convert.ToInt32(Request.QueryString["num"].ToString());
                prueba.Id = IdPrueba;
                Models.PersonasPsicometrico dtDocumento = APpersonasPsicometrico.PersonasPsicometrico_Seleccionar_Id(prueba);

                Persona.Id = dtDocumento.Personas.Id;
                Models.Personas personas = ApPersonas.Personas_Seleccionar_Id(Persona);
                string folderPath = APcat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

                //string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";
                string Portada = HttpContext.Server.MapPath("~") + "\\Images\\PDF\\Portada3.pdf";

                PdfReader reader = new PdfReader(Portada);

                MemoryStream ms = new MemoryStream();
                //Document document = new Document();
                //PdfCopy pdfCopy = new PdfCopy(document, ms);


                //rutas de nuestros pdf
                string pathPDF = Portada;
                //string pathPDF2 = @"C:\con_texto.pdf";

                //Objeto para leer el pdf original
                PdfReader oReader = new PdfReader(pathPDF);
                //Objeto que tiene el tamaño de nuestro documento
                Rectangle oSize = oReader.GetPageSizeWithRotation(1);
                //documento de itextsharp para realizar el trabajo asignandole el tamaño del original
                Document oDocument = new Document(oSize);

                // Creamos el objeto en el cual haremos la inserción
                //FileStream oFS = new FileStream(pathPDF2, FileMode.Create, FileAccess.Write);
                PdfWriter oWriter = PdfWriter.GetInstance(oDocument, ms);

                oDocument.Open();


                string ruta = folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO" + @"\" + dtDocumento.NmArchivo;
                PdfContentByte cb = oWriter.DirectContent;
                var pdfReader2 = new PdfReader(ruta);
                var n = pdfReader2.NumberOfPages;
                for (var page = 0; page < n;)
                {
                    oDocument.NewPage();
                    PdfImportedPage pagina = oWriter.GetImportedPage(pdfReader2, ++page);
                    cb.AddTemplate(pagina, 0, 0);
                }

                oDocument.Close();

                Byte[] FileBuffer = ms.ToArray();

                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }

            return View();
        }
    }
}
