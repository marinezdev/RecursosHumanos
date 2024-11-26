using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Examen
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Examen PersonasExamen_Agregar(Models.Examen examen)
        {
            b.ExecuteCommandSP("PersonasExamen_Agregar");
            b.AddParameter("@IdPersona", examen.IdPersona, SqlDbType.Int);
            b.AddParameter("@IdTipoExamen", examen.IdTipoExamen, SqlDbType.Int);
            b.AddParameter("@Calificacion", examen.Calificacion, SqlDbType.NVarChar);
            b.AddParameter("@Califico", examen.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", examen.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@NmArchivo", examen.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", examen.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", examen.Observaciones, SqlDbType.NVarChar);

            Models.Examen resultado = new Models.Examen();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Examen> PersonasExamen_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasExamen_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Examen> resultado = new List<Models.Examen>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Examen item = new Models.Examen()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    TipoExamen = reader["TipoExamen"].ToString(),
                    Calificacion = reader["Calificacion"].ToString(),
                    Califico = reader["Califico"].ToString(),
                    FechaAplicacion = reader["FechaAplicacion"].ToString(),
                    NmArchivo = reader["NmArchivo"].ToString(),
                    NmOriginal = reader["NmOriginal"].ToString(),
                    Observaciones = reader["Observaciones"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Examen PersonasExamen_Seleccionar_Id(Models.Examen examen)
        {
            b.ExecuteCommandSP("PersonasExamen_Seleccionar_Id");
            b.AddParameter("@Id", examen.Id, SqlDbType.Int);

            Models.Examen resultado = new Models.Examen();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.NmArchivo = reader["NmArchivo"].ToString();
                resultado.IdPersona = Convert.ToInt32(reader["IdPersona"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Examen PersonasExamen_Editar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasExamen_Editar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.Examen resultado = new Models.Examen();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.IdTipoExamen = Convert.ToInt32(reader["IdTipoExamen"].ToString());
                resultado.Calificacion = reader["Calificacion"].ToString();
                resultado.Califico = reader["Califico"].ToString();
                resultado.FechaAplicacion = Convert.ToDateTime(reader["FechaAplicacion"].ToString()).ToString("yyyy-MM-dd");
                resultado.Observaciones = reader["Observaciones"].ToString();
                resultado.NmOriginal = reader["NmOriginal"].ToString();
                resultado.NmArchivo = reader["NmArchivo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Examen PersonasExamen_Eliminar(Models.Examen examen)
        {
            b.ExecuteCommandSP("PersonasExamen_Eliminar");
            b.AddParameter("@Id", examen.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", examen.IdPersona, SqlDbType.Int);

            Models.Examen resultado = new Models.Examen();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Examen PersonasExamen_Actualizar(Models.Examen examen)
        {
            b.ExecuteCommandSP("PersonasExamen_Actualizar");
            b.AddParameter("@Id", examen.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", examen.IdPersona, SqlDbType.Int);
            b.AddParameter("@IdTipoExamen", examen.IdTipoExamen, SqlDbType.Int);
            b.AddParameter("@Calificacion", examen.Calificacion, SqlDbType.NVarChar);
            b.AddParameter("@Califico", examen.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", examen.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@Observaciones", examen.Observaciones, SqlDbType.NVarChar);

            b.AddParameter("@NmArchivo", examen.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", examen.NmOriginal, SqlDbType.NVarChar);

            Models.Examen resultado = new Models.Examen();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
