using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasCertificaciones
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasCertificacion PersonasCertificacion_Agregar(Models.PersonasCertificacion personasCertificaciones)
        {
            const string consulta = "PersonasCertificacion_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasCertificaciones.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdCertificacion", personasCertificaciones.Cat_Certificaciones.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasCertificaciones.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasCertificaciones.NmArchivo, SqlDbType.VarChar);
            b.AddParameter("@FechaTermino", personasCertificaciones.FechaTermino, SqlDbType.Date);
            b.AddParameter("@Aprobado", personasCertificaciones.Aprobado, SqlDbType.VarChar);

            Models.PersonasCertificacion resultado = new Models.PersonasCertificacion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCertificacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasCertificacion PersonasCertificacion_Eliminar(Models.PersonasCertificacion personasCertificaciones)
        {
            b.ExecuteCommandSP("PersonasCertificacion_Editar_Eliminar");
            b.AddParameter("@Id", personasCertificaciones.Id, SqlDbType.Int);

            Models.PersonasCertificacion resultado = new Models.PersonasCertificacion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCertificacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.PersonasCertificacion> PersonasCertificacion_Seleccionar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasCertificacion_Seleccionar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasCertificacion> resultado = new List<Models.PersonasCertificacion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasCertificacion>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasCertificacion PersonasCertificacion_Editar_ActualizarArchivo(Models.PersonasCertificacion personasCertificaciones)
        {
            const string consulta = "PersonasCertificacion_Editar_ActualizarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasCertificaciones.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasCertificaciones.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasCertificaciones.NmArchivo, SqlDbType.VarChar);

            Models.PersonasCertificacion resultado = new Models.PersonasCertificacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCertificacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasCertificacion PersonasCertificacion_Editar_EliminarArchivo(Models.PersonasCertificacion personasCertificaciones)
        {
            const string consulta = "PersonasCertificacion_Editar_EliminarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasCertificaciones.Id, SqlDbType.Int);

            Models.PersonasCertificacion resultado = new Models.PersonasCertificacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCertificacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasCertificacion PersonasCertificacion_Editar_Selecionar_Id(Models.PersonasCertificacion personasCertificaciones)
        {
            const string consulta = "PersonasCertificacion_Editar_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasCertificaciones.Id, SqlDbType.Int);

            Models.PersonasCertificacion resultado = new Models.PersonasCertificacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasCertificacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
