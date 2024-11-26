using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasExperiencia
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.PersonasExperiencia> PersonasExperiencia_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasExperiencia_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasExperiencia> resultado = new List<Models.PersonasExperiencia>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.PersonasExperiencia item = new Models.PersonasExperiencia()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Empresa = reader["Empresa"].ToString(),
                    Puesto = reader["Puesto"].ToString(),
                    MotivoSalida = reader["MotivoSalida"].ToString(),
                    Actividades = reader["Actividades"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.PersonasExperiencia PersonasExperiencia_Editar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasExperiencia_Editar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.PersonasExperiencia resultado = new Models.PersonasExperiencia();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Empresa = reader["Empresa"].ToString();
                resultado.Puesto = reader["Puesto"].ToString();
                resultado.MotivoSalida = reader["MotivoSalida"].ToString();
                resultado.Actividades = reader["Actividades"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
