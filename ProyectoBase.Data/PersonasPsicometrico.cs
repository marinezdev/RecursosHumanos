using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasPsicometrico
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasPsicometrico PersonasPsicometrico_Agregar(Models.PersonasPsicometrico personasPsicometrico)
        {
            const string consulta = "PersonasPsicometrico_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasPsicometrico.Personas.Id, SqlDbType.Int);
            b.AddParameter("@Califico", personasPsicometrico.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", personasPsicometrico.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@NmArchivo", personasPsicometrico.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", personasPsicometrico.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", personasPsicometrico.Observaciones, SqlDbType.NVarChar);

            Models.PersonasPsicometrico resultado = new Models.PersonasPsicometrico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasPsicometrico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasPsicometrico PersonasPsicometrico_Editar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasPsicometrico_Editar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.PersonasPsicometrico resultado = new Models.PersonasPsicometrico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasPsicometrico>(reader.GetValue(0).ToString());
            }

            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasPsicometrico PersonasPsicometrico_Eliminar(Models.PersonasPsicometrico personasPsicometrico)
        {
            const string consulta = "PersonasPsicometrico_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasPsicometrico.Personas.Id, SqlDbType.Int);

            Models.PersonasPsicometrico resultado = new Models.PersonasPsicometrico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasPsicometrico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasPsicometrico PersonasPsicometrico_Actualizar(Models.PersonasPsicometrico personasPsicometrico)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Actualizar");
            b.AddParameter("@Id", personasPsicometrico.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", personasPsicometrico.Personas.Id, SqlDbType.Int);
            b.AddParameter("@Califico", personasPsicometrico.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", personasPsicometrico.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@Observaciones", personasPsicometrico.Observaciones, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivo", personasPsicometrico.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", personasPsicometrico.NmOriginal, SqlDbType.NVarChar);

            Models.PersonasPsicometrico resultado = new Models.PersonasPsicometrico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasPsicometrico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.PersonasPsicometrico PersonasPsicometrico_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            Models.PersonasPsicometrico resultado = new Models.PersonasPsicometrico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasPsicometrico>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.PersonasPsicometrico PersonasPsicometrico_Seleccionar_Id(Models.PersonasPsicometrico personasPsicometrico)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Seleccionar_Id");
            b.AddParameter("@Id", personasPsicometrico.Id, SqlDbType.Int);

            Models.PersonasPsicometrico resultado = new Models.PersonasPsicometrico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasPsicometrico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        

    }
}
