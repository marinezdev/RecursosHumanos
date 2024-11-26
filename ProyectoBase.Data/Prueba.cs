using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Prueba
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Prueba PersonasPsicometrico_Agregar(Models.Prueba examen)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Agregar");
            b.AddParameter("@IdPersona", examen.IdPersona, SqlDbType.Int);
            b.AddParameter("@Califico", examen.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", examen.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@NmArchivo", examen.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", examen.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", examen.Observaciones, SqlDbType.NVarChar);

            Models.Prueba resultado = new Models.Prueba();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Prueba> PersonasPsicometrico_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Prueba> resultado = new List<Models.Prueba>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Prueba item = new Models.Prueba()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
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
        public Models.Prueba PersonasPsicometrico_Seleccionar_Id(Models.Prueba prueba)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Seleccionar_Id");
            b.AddParameter("@Id", prueba.Id, SqlDbType.Int);

            Models.Prueba resultado = new Models.Prueba();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdPersona = Convert.ToInt32(reader["IdPersona"].ToString());
                resultado.NmArchivo = reader["NmArchivo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Prueba PersonasPsicometrico_Editar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Editar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.Prueba resultado = new Models.Prueba();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
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

        public Models.Prueba PersonasPsicometrico_Eliminar(Models.Prueba prueba)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Eliminar");
            b.AddParameter("@Id", prueba.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", prueba.IdPersona, SqlDbType.Int);

            Models.Prueba resultado = new Models.Prueba();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Prueba PersonasPsicometrico_Actualizar(Models.Prueba prueba)
        {
            b.ExecuteCommandSP("PersonasPsicometrico_Actualizar");
            b.AddParameter("@Id", prueba.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", prueba.IdPersona, SqlDbType.Int);
            b.AddParameter("@Califico", prueba.Califico, SqlDbType.NVarChar);
            b.AddParameter("@FechaAplicacion", prueba.FechaAplicacion, SqlDbType.Date);
            b.AddParameter("@Observaciones", prueba.Observaciones, SqlDbType.NVarChar);

            b.AddParameter("@NmArchivo", prueba.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", prueba.NmOriginal, SqlDbType.NVarChar);

            Models.Prueba resultado = new Models.Prueba();
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
