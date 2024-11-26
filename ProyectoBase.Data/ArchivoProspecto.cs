using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ArchivoProspecto
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ArchivoProspecto ArchivoProspecto_Agregar(Models.ArchivoProspecto archivoProspecto)
        {
            const string consulta = "Vacantes.ArchivoProspecto_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", archivoProspecto.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", archivoProspecto.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", archivoProspecto.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivo", archivoProspecto.NmArchivo, SqlDbType.NVarChar);

            Models.ArchivoProspecto resultado = new Models.ArchivoProspecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArchivoProspecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
