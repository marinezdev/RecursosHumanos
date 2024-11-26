using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Entrevistas
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Entrevistas PersonasEntrevistas_Agregar(Models.Entrevistas entrevistas)
        {
            b.ExecuteCommandSP("PersonasEntrevistas_Agregar");
            b.AddParameter("@IdPersona", entrevistas.IdPersona, SqlDbType.Int);
            b.AddParameter("@Entrevisto", entrevistas.Entrevisto, SqlDbType.NVarChar);
            b.AddParameter("@FechaEntrevista", entrevistas.FechaEntrevista, SqlDbType.Date);
            b.AddParameter("@Observaciones", entrevistas.Observaciones, SqlDbType.VarChar);

            Models.Entrevistas resultado = new Models.Entrevistas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Entrevistas PersonasEntrevistas_Eliminar(Models.Entrevistas entrevistas)
        {
            b.ExecuteCommandSP("PersonasEntrevistas_Eliminar");
            b.AddParameter("@Id", entrevistas.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", entrevistas.IdPersona, SqlDbType.Int);

            Models.Entrevistas resultado = new Models.Entrevistas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.Entrevistas> PersonasEntrevistas_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasEntrevistas_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Entrevistas> resultado = new List<Models.Entrevistas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Entrevistas item = new Models.Entrevistas()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Entrevisto = reader["Entrevisto"].ToString(),
                    FechaEntrevista = reader["FechaEntrevista"].ToString(),
                    Observaciones = reader["Observaciones"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

    }
}
