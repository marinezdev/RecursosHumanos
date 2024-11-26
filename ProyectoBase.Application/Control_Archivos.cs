using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class Control_Archivos
    {
        Data.Control_Archivos _Archivos = new Data.Control_Archivos();
        public Models.Entrevistas Entrevistas_NuevoId()
        {
            Models.Entrevistas entrevistas = new Models.Entrevistas();
            Models.Control_Archivos archivo = _Archivos.NuevoArchivo();
            entrevistas.Id = archivo.Id;
            return entrevistas;
        }

        public Models.Control_Archivos Control_Archivos_Id()
        {
            Models.Control_Archivos control_Archivos = _Archivos.NuevoArchivo();
            return control_Archivos;
        }

        public Models.PersonasExamen NuevoArchivoExamen(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.PersonasExamen _PersonasExamen = new Models.PersonasExamen();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".pdf".Contains(FileExtension))
            {
                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".pdf");
                _PersonasExamen.NmArchivo = NombreArchivo + ".pdf";
                _PersonasExamen.NmOriginal = Archivo.FileName;
            }
            return _PersonasExamen;
        }

        public Models.PersonasEstudios NuevoArchivoEstudio(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.PersonasEstudios _Estudios = new Models.PersonasEstudios();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".pdf".Contains(FileExtension))
            {
                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".pdf");
                _Estudios.NmArchivo = NombreArchivo + ".pdf";
                _Estudios.NmOriginal = Archivo.FileName;
            }
            return _Estudios;
        }

        public Models.DocumentoVersiones NuevoArchivoDocumento(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.DocumentoVersiones _Documento = new Models.DocumentoVersiones();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".pdf".Contains(FileExtension))
            {
                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".pdf");
                _Documento.NmArchivo = NombreArchivo + ".pdf";
                _Documento.NmOriginal = Archivo.FileName;
            }
            return _Documento;
        }

        public Models.PersonasDetalle NuevaImagen(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.PersonasDetalle _PersonasDetalle = new Models.PersonasDetalle();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".jpg".Contains(FileExtension) ^ ".png".Contains(FileExtension) ^ ".jpeg".Contains(FileExtension))
            {
                Models.Control_Archivos archivo = _Archivos.NuevoArchivo();
                string NombreArchivo = archivo.Clave + archivo.Id.ToString().PadLeft(12, '0');

                Image image = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 900, 600);
                image.Save(DirectorioUsuario + NombreArchivo + ".png");
                _PersonasDetalle.NmArchivo = NombreArchivo + ".png";
                _PersonasDetalle.NmOriginal = Archivo.FileName;
            }

            return _PersonasDetalle;
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.MakeTransparent();
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);

                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.MakeTransparent();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Png);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        public Models.ArchivoQuincena NuevoArchivoIMSS(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.ArchivoQuincena _ArchivoQuincena = new Models.ArchivoQuincena();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".txt".Contains(FileExtension))
            {
                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".txt");
                _ArchivoQuincena.NmArchivo = NombreArchivo + ".txt";
                _ArchivoQuincena.NmOriginal = Archivo.FileName;
            }
            return _ArchivoQuincena;
        }
        public Models.ArchivoProspecto NuevoArchivoProspectos(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.ArchivoProspecto _ArchivoProspecto = new Models.ArchivoProspecto();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".xlsx".Contains(FileExtension))
            {
                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".xlsx");
                _ArchivoProspecto.NmArchivo = NombreArchivo + ".xlsx";
                _ArchivoProspecto.NmOriginal = Archivo.FileName;
            }
            return _ArchivoProspecto;
        }
        public Models.ProspectoArchivo NuevoArchivoCVProspectos(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.ProspectoArchivo _ProspectoArchivo = new Models.ProspectoArchivo();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".docx".Contains(FileExtension) || ".pdf".Contains(FileExtension))
            {
                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + FileExtension);
                _ProspectoArchivo.NmARchivo = NombreArchivo + FileExtension;
                _ProspectoArchivo.NmOriginal = Archivo.FileName;
                _ProspectoArchivo.Extencion = FileExtension;
            }
            return _ProspectoArchivo;
        }
    }
}
