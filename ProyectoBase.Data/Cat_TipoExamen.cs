using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_TipoExamen
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_TipoExamen> Cat_TipoExamen_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_TipoExamen_Seleccionar");
            List<Models.Cat_TipoExamen> resultado = new List<Models.Cat_TipoExamen>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_TipoExamen item = new Models.Cat_TipoExamen()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_TipoExamen Cat_TipoExamen_Agregar(Models.Cat_TipoExamen cat_TipoExamen)
        {
            b.ExecuteCommandSP("Cat_TipoExamen_Agregar");
            b.AddParameter("@Nombre", cat_TipoExamen.Nombre, SqlDbType.VarChar);

            Models.Cat_TipoExamen resultado = new Models.Cat_TipoExamen();
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
