using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class ArchivoProspecto
    {
        Data.ArchivoProspecto _archivoProspecto = new Data.ArchivoProspecto();
        Data.Prospecto _Prospecto = new Data.Prospecto();

        public Models.ArchivoProspecto ArchivoProspecto_Agregar(Models.ArchivoProspecto archivoProspecto)
        {
            Models.ArchivoProspecto dbarchivoProspecto1 = _archivoProspecto.ArchivoProspecto_Agregar(archivoProspecto);
            
            System.Data.DataTable datos = null;
            int Registrados = 0;
            int Noregistrados = 0;
            ////////////////////////////////
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosProspectos\\";
            String fileName = DirectorioUsuario + archivoProspecto.NmArchivo;
            FileInfo newFile = new FileInfo(fileName);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pagina = new ExcelPackage(newFile);

            datos = Excel_A_DataTable(pagina);

            foreach (DataRow row in datos.Rows)
            {
                Models.Prospecto prospecto = new Models.Prospecto();
                prospecto.Vacante = archivoProspecto.Vacante;
                prospecto.Usuarios = archivoProspecto.Usuarios;
                prospecto.Nombre = row["Nombre"].ToString();
                prospecto.ApellidoPaterno = row["Apellido paterno "].ToString();
                prospecto.ApellidoMaterno = row["Apellino materno"].ToString();
                prospecto.CorreElectronico = row["Correo electrónico "].ToString();
                prospecto.TelefonoCelular = row["Teléfono celular"].ToString();
                prospecto.TelefonoFijo = row["Teléfono fijo "].ToString();

                Models.Prospecto dbProspecto = _Prospecto.Prospecto_Agregar(prospecto);
                if (dbProspecto.Id > 0)
                {
                    Registrados = Registrados + 1;
                }
                else
                {
                    Noregistrados = Noregistrados + 1;
                }
            }
            dbarchivoProspecto1.Registrados = Registrados;
            dbarchivoProspecto1.Noregistrados = Noregistrados;

            return dbarchivoProspecto1;
        }


        public static DataTable Excel_A_DataTable(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable table = new DataTable();

            //foreach (var firstRowCell in workSheet.Cells[1, 1, 1, 60])
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                //var row = workSheet.Cells[rowNumber, 1, rowNumber, 60];
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                table.Rows.Add(newRow);
            }

            return table;
        }

    }
}
