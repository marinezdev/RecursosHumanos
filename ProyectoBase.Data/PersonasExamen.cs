using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasExamen
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasExamen PersonasExamen_Agregar(Models.PersonasExamen personasExamen)
        {
            const string consulta = "PersonasExamen_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasExamen.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoExamen", personasExamen.Cat_TipoExamen.Id, SqlDbType.Int);
            b.AddParameter("@Calificacion", personasExamen.Calificacion, SqlDbType.NVarChar);
            b.AddParameter("@Califico", personasExamen.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", personasExamen.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@NmArchivo", personasExamen.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", personasExamen.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", personasExamen.Observaciones, SqlDbType.NVarChar);

            Models.PersonasExamen resultado = new Models.PersonasExamen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasExamen>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasExamen PersonasExamen_Editar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasExamen_Editar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.PersonasExamen resultado = new Models.PersonasExamen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasExamen>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasExamen PersonasExamen_Eliminar(Models.PersonasExamen personasExamen)
        {
            const string consulta = "PersonasExamen_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasExamen.Personas.Id, SqlDbType.Int);

            Models.PersonasExamen resultado = new Models.PersonasExamen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasExamen>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasExamen PersonasExamen_Actualizar(Models.PersonasExamen personasExamen)
        {
            b.ExecuteCommandSP("PersonasExamen_Actualizar");
            b.AddParameter("@Id", personasExamen.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", personasExamen.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoExamen", personasExamen.Cat_TipoExamen.Id, SqlDbType.Int);
            b.AddParameter("@Calificacion", personasExamen.Calificacion, SqlDbType.NVarChar);
            b.AddParameter("@Califico", personasExamen.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", personasExamen.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@Observaciones", personasExamen.Observaciones, SqlDbType.NVarChar);

            b.AddParameter("@NmArchivo", personasExamen.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", personasExamen.NmOriginal, SqlDbType.NVarChar);

            Models.PersonasExamen resultado = new Models.PersonasExamen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasExamen>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasExamen PersonasExamen_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasExamen_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            Models.PersonasExamen resultado = new Models.PersonasExamen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasExamen>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasExamen PersonasExamen_Seleccionar_Id(Models.PersonasExamen personasExamen)
        {
            b.ExecuteCommandSP("PersonasExamen_Seleccionar_Id");
            b.AddParameter("@Id", personasExamen.Id, SqlDbType.Int);
            Models.PersonasExamen resultado = new Models.PersonasExamen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasExamen>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        
    }
}
