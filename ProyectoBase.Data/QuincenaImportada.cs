using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class QuincenaImportada
    {
        ManejoDatos b = new ManejoDatos();
        public Models.QuincenaImportada QuincenaImportada_Agregar(Models.QuincenaImportada quincenaImportada)
        {
            char[] _caracteres = { '-', ' ', '-' };
            const string consulta = "QuincenaImportada_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArchivoQuincena", quincenaImportada.ArchivoQuincena.Id, SqlDbType.Int);
            b.AddParameter("@Quincena", quincenaImportada.Quincena, SqlDbType.NVarChar);
            b.AddParameter("@Clave", quincenaImportada.Clave, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", quincenaImportada.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@RFC", quincenaImportada.RFC, SqlDbType.NVarChar);
            b.AddParameter("@NSS", quincenaImportada.NSS, SqlDbType.NVarChar);
            b.AddParameter("@CURP", quincenaImportada.CURP, SqlDbType.NVarChar);
            b.AddParameter("@Pago", quincenaImportada.Pago, SqlDbType.NVarChar);
            b.AddParameter("@FechaIngreso", quincenaImportada.FechaIngreso, SqlDbType.NVarChar);
            b.AddParameter("@DiasPagados", quincenaImportada.DiasPagados, SqlDbType.NVarChar);
            b.AddParameter("@Baja", quincenaImportada.Baja, SqlDbType.NVarChar);
            b.AddParameter("@DiasIncapacidad", quincenaImportada.DiasIncapacidad, SqlDbType.NVarChar);

            Models.QuincenaImportada resultado = new Models.QuincenaImportada();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.QuincenaImportada>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //public List<Models.Consultas.ReporteIMSS> QuincenaExportar_Selecionar_IdCuatrimestre(Models.Cat_Cuatrimestre cat_Cuatrimestre)
        //{
        //    const string consulta = "QuincenaExportar_Selecionar_IdCuatrimestre";
        //    b.ExecuteCommandSP(consulta);
        //    b.AddParameter("@IdCuatrimestre", cat_Cuatrimestre.Id, SqlDbType.Int);

        //    List<Models.Consultas.ReporteIMSS> resultado = new List<Models.Consultas.ReporteIMSS>();
        //    var reader = b.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        resultado = JsonConvert.DeserializeObject<List<Models.Consultas.ReporteIMSS>>(reader.GetValue(0).ToString());
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;
        //}

        public DataTable QuincenaExportar_Selecionar_IdCuatrimestre(Models.Cat_Cuatrimestre cat_Cuatrimestre)
        {
            string consulta = "";
            consulta = "EXECUTE QuincenaExportar_Selecionar_IdCuatrimestre " + cat_Cuatrimestre.Id + ","+ cat_Cuatrimestre.ArchivoQuincena.Year;

            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }


    }
}
