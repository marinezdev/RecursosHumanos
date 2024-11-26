using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasCursos
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasCursos PersonasCursos_Agregar(Models.PersonasCursos personasCursos)
        {
            const string consulta = "PersonasCursos_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasCursos.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdCurso", personasCursos.Cat_Cursos.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasCursos.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasCursos.NmArchivo, SqlDbType.VarChar);
            b.AddParameter("@FechaTermino", personasCursos.FechaTermino, SqlDbType.Date);
            b.AddParameter("@Acreditado", personasCursos.Acreditado, SqlDbType.VarChar);

            Models.PersonasCursos resultado = new Models.PersonasCursos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCursos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasCursos PersonasCursos_Eliminar(Models.PersonasCursos personasCursos)
        {
            b.ExecuteCommandSP("PersonasCursos_Editar_Eliminar");
            b.AddParameter("@Id", personasCursos.Id, SqlDbType.Int);

            Models.PersonasCursos resultado = new Models.PersonasCursos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCursos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.PersonasCursos> PersonasCursos_Seleccionar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasCursos_Seleccionar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasCursos> resultado = new List<Models.PersonasCursos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasCursos>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasCursos PersonasCursos_Editar_ActualizarArchivo(Models.PersonasCursos personasCursos)
        {
            const string consulta = "PersonasCursos_Editar_ActualizarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasCursos.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasCursos.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasCursos.NmArchivo, SqlDbType.VarChar);

            Models.PersonasCursos resultado = new Models.PersonasCursos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCursos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasCursos PersonasCursos_Editar_EliminarArchivo(Models.PersonasCursos personasCursos)
        {
            const string consulta = "PersonasCursos_Editar_EliminarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasCursos.Id, SqlDbType.Int);

            Models.PersonasCursos resultado = new Models.PersonasCursos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCursos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasCursos PersonasCursos_Editar_Selecionar_Id(Models.PersonasCursos personasCursos)
        {
            const string consulta = "PersonasCursos_Editar_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasCursos.Id, SqlDbType.Int);

            Models.PersonasCursos resultado = new Models.PersonasCursos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCursos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
