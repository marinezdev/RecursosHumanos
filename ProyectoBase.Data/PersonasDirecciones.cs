using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasDirecciones
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.PersonasDirecciones> PersonasDirecciones_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDirecciones_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasDirecciones> resultado = new List<Models.PersonasDirecciones>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.PersonasDirecciones item = new Models.PersonasDirecciones()
                {
                    Estado = reader["Estado"].ToString(),
                    Poblacion = reader["Poblacion"].ToString(),
                    Colonia = reader["Colonia"].ToString(),
                    CP = reader["CP"].ToString(),
                    Calle = reader["Calle"].ToString(),
                    NumExterior = reader["NumExterior"].ToString(),
                    NumInteriror = reader["NumInteriror"].ToString(),
                    EntreCalles = reader["EntreCalles"].ToString(),
                    Referencias = reader["Referencias"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.PersonasDirecciones PersonasDirecciones_Editar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDirecciones_Editar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.PersonasDirecciones resultado = new Models.PersonasDirecciones();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.IdColonia = Convert.ToInt32(reader["IdColonia"].ToString());
                resultado.CP = reader["CP"].ToString();
                resultado.Calle = reader["Calle"].ToString();
                resultado.NumExterior = reader["NumExterior"].ToString();
                resultado.NumInteriror = reader["NumInteriror"].ToString();
                resultado.EntreCalles = reader["EntreCalles"].ToString();
                resultado.Referencias = reader["Referencias"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.PersonasDirecciones PersonasDirecciones_Actualizar_Direccion(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDirecciones_Actualizar_Direccion");
            b.AddParameter("@Id", personas.PersonasDirecciones.Id, SqlDbType.Int);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            b.AddParameter("@IdColonia", personas.PersonasDirecciones.IdColonia, SqlDbType.Int);
            b.AddParameter("@Calle", personas.PersonasDirecciones.Calle, SqlDbType.VarChar);
            b.AddParameter("@NumExterior", personas.PersonasDirecciones.NumExterior, SqlDbType.VarChar);
            b.AddParameter("@NumInteriror", personas.PersonasDirecciones.NumInteriror, SqlDbType.VarChar);
            b.AddParameter("@EntreCalles", personas.PersonasDirecciones.EntreCalles, SqlDbType.VarChar);
            b.AddParameter("@Referencias", personas.PersonasDirecciones.Referencias, SqlDbType.VarChar);

            Models.PersonasDirecciones resultado = new Models.PersonasDirecciones();
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
