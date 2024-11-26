using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasAplicaciones
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasAplicaciones PersonasAplicaciones_Agregar(Models.PersonasAplicaciones personasAplicaciones)
        {
            b.ExecuteCommandSP("PersonasAplicaciones_Agregar");
            b.AddParameter("@IdPersona", personasAplicaciones.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdAplicacion", personasAplicaciones.Cat_Aplicaciones.Id, SqlDbType.Int);
            Models.PersonasAplicaciones resultado = new Models.PersonasAplicaciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasAplicaciones>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.PersonasAplicaciones> PersonasAplicaciones_Seleccionar_IdPersona(Models.Personas Persona)
        {
            b.ExecuteCommandSP("PersonasAplicaciones_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", Persona.Id, SqlDbType.Int);
            List<Models.PersonasAplicaciones> resultado = new List<Models.PersonasAplicaciones>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasAplicaciones>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasAplicaciones PersonasAplicaciones_Eliminar(Models.PersonasAplicaciones personasAplicaciones)
        {
            b.ExecuteCommandSP("PersonasAplicaciones_Eliminar");
            b.AddParameter("@Id", personasAplicaciones.Id, SqlDbType.Int);
            Models.PersonasAplicaciones resultado = new Models.PersonasAplicaciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasAplicaciones>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
