using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasEntrevistas
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasEntrevistas PersonasEntrevistas_Agregar(Models.PersonasEntrevistas personasEntrevistas)
        {
            const string consulta = "PersonasEntrevistas_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasEntrevistas.Personas.Id, SqlDbType.Int);
            b.AddParameter("@Entrevisto", personasEntrevistas.Entrevisto, SqlDbType.NVarChar);
            b.AddParameter("@FechaEntrevista", personasEntrevistas.FechaEntrevista, SqlDbType.Date);
            b.AddParameter("@Observaciones", personasEntrevistas.Observaciones, SqlDbType.VarChar);

            Models.PersonasEntrevistas resultado = new Models.PersonasEntrevistas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasEntrevistas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.PersonasEntrevistas> PersonasEntrevistas_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasEntrevistas_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasEntrevistas> resultado = new List<Models.PersonasEntrevistas>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasEntrevistas>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasEntrevistas PersonasEntrevistas_Eliminar(Models.PersonasEntrevistas personasEntrevistas)
        {
            const string consulta = "PersonasEntrevistas_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasEntrevistas.Id, SqlDbType.Int);

            Models.PersonasEntrevistas resultado = new Models.PersonasEntrevistas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasEntrevistas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


    }
}
