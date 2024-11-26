using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasDiplomado
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasDiplomados PersonasDiplomado_Agregar(Models.PersonasDiplomados personasDiplomados)
        {
            const string consulta = "PersonasDiplomado_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasDiplomados.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdDiplomado", personasDiplomados.Cat_Diplomados.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasDiplomados.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasDiplomados.NmArchivo, SqlDbType.VarChar);
            b.AddParameter("@FechaTermino", personasDiplomados.FechaTermino, SqlDbType.Date);
            b.AddParameter("@Aprobado", personasDiplomados.Aprobado, SqlDbType.VarChar);

            Models.PersonasDiplomados resultado = new Models.PersonasDiplomados();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDiplomados>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasDiplomados PersonasDiplomado_Eliminar(Models.PersonasDiplomados personasDiplomados)
        {
            b.ExecuteCommandSP("PersonasDiplomado_Editar_Eliminar");
            b.AddParameter("@Id", personasDiplomados.Id, SqlDbType.Int);

            Models.PersonasDiplomados resultado = new Models.PersonasDiplomados();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDiplomados>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.PersonasDiplomados> PersonasDiplomado_Seleccionar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasDiplomado_Seleccionar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasDiplomados> resultado = new List<Models.PersonasDiplomados>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasDiplomados>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasDiplomados PersonasDiplomados_Editar_ActualizarArchivo(Models.PersonasDiplomados personasDiplomados)
        {
            const string consulta = "PersonasDiplomado_Editar_ActualizarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDiplomados.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasDiplomados.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasDiplomados.NmArchivo, SqlDbType.VarChar);

            Models.PersonasDiplomados resultado = new Models.PersonasDiplomados();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDiplomados>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasDiplomados PersonasDiplomados_Editar_EliminarArchivo(Models.PersonasDiplomados personasDiplomados)
        {
            const string consulta = "PersonasDiplomado_Editar_EliminarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDiplomados.Id, SqlDbType.Int);

            Models.PersonasDiplomados resultado = new Models.PersonasDiplomados();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDiplomados>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasDiplomados PersonasDiplomados_Editar_Selecionar_Id(Models.PersonasDiplomados personasDiplomados)
        {
            const string consulta = "PersonasDiplomado_Editar_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDiplomados.Id, SqlDbType.Int);

            Models.PersonasDiplomados resultado = new Models.PersonasDiplomados();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDiplomados>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
