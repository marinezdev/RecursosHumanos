using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ArchivoQuincena
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ArchivoQuincena ArchivoQuincena_Agregar(Models.ArchivoQuincena archivoQuincena)
        {
            const string consulta = "ArchivoQuincena_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdQuincena", archivoQuincena.Cat_Quincena.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", archivoQuincena.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", archivoQuincena.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivo", archivoQuincena.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@Year", archivoQuincena.Year, SqlDbType.Int);

            Models.ArchivoQuincena resultado = new Models.ArchivoQuincena();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArchivoQuincena>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.ArchivoQuincena ArchivoQuincena_Consultar(Models.ArchivoQuincena archivoQuincena)
        {
            const string consulta = "ArchivoQuincena_Consultar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdQuincena", archivoQuincena.Cat_Quincena.Id, SqlDbType.Int);
            b.AddParameter("@Year", archivoQuincena.Year, SqlDbType.Int);

            Models.ArchivoQuincena resultado = new Models.ArchivoQuincena();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArchivoQuincena>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.ArchivoQuincena> ArchivoQuincena_Consultar_Years()
        {
            const string consulta = "ArchivoQuincena_Consultar_Years";
            b.ExecuteCommandSP(consulta);

            List<Models.ArchivoQuincena> resultado = new List<Models.ArchivoQuincena>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ArchivoQuincena>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
