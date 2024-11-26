using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Cursos
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Cursos> Cat_Cursos_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Cursos_Seleccionar");
            List<Models.Cat_Cursos> resultado = new List<Models.Cat_Cursos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Cursos item = new Models.Cat_Cursos()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_Cursos Cat_Cursos_Agregar(Models.Cat_Cursos cat_Cursos)
        {
            b.ExecuteCommandSP("Cat_Cursos_Agregar");
            b.AddParameter("@Nombre", cat_Cursos.Nombre, SqlDbType.VarChar);

            Models.Cat_Cursos resultado = new Models.Cat_Cursos();
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
