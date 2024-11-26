using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasEstudios
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Consultas.PersonaEstudio PersonasEstudios_Agregar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            const string consulta = "PersonasEstudios_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personaEstudio.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdEstudios", personaEstudio.Cat_Estudios.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", personaEstudio.Cat_EstatusEstudios.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personaEstudio.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personaEstudio.NmArchivo, SqlDbType.VarChar);
            b.AddParameter("@FechaTermino", personaEstudio.FechaTermino, SqlDbType.Date);

            Models.Consultas.PersonaEstudio resultado = new Models.Consultas.PersonaEstudio();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonaEstudio>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Consultas.PersonaEstudio> PersonasEstudios_Seleccionar_Editar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasEstudios_Editar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Consultas.PersonaEstudio> resultado = new List<Models.Consultas.PersonaEstudio>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonaEstudio>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_Eliminar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            const string consulta = "PersonasEstudios_Editar_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersonaEstudio", personaEstudio.Id, SqlDbType.Int);

            Models.Consultas.PersonaEstudio resultado = new Models.Consultas.PersonaEstudio();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonaEstudio>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_ActualizarArchivo(Models.Consultas.PersonaEstudio personaEstudio)
        {
            const string consulta = "PersonasEstudios_Editar_ActualizarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personaEstudio.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personaEstudio.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personaEstudio.NmArchivo, SqlDbType.VarChar);

            Models.Consultas.PersonaEstudio resultado = new Models.Consultas.PersonaEstudio();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonaEstudio>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_EliminarArchivo(Models.Consultas.PersonaEstudio personaEstudio)
        {
            const string consulta = "PersonasEstudios_Editar_EliminarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personaEstudio.Id, SqlDbType.Int);

            Models.Consultas.PersonaEstudio resultado = new Models.Consultas.PersonaEstudio();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonaEstudio>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_Selecionar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            const string consulta = "PersonasEstudios_Editar_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personaEstudio.Id, SqlDbType.Int);

            Models.Consultas.PersonaEstudio resultado = new Models.Consultas.PersonaEstudio();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonaEstudio>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
