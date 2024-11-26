using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Diplomados
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Diplomados> Cat_Diplomados_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Diplomados_Seleccionar");
            List<Models.Cat_Diplomados> resultado = new List<Models.Cat_Diplomados>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Diplomados item = new Models.Cat_Diplomados()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_Diplomados Cat_Diplomados_Agregar(Models.Cat_Diplomados cat_Diplomados)
        {
            b.ExecuteCommandSP("Cat_Diplomados_Agregar");
            b.AddParameter("@Nombre", cat_Diplomados.Nombre, SqlDbType.VarChar);

            Models.Cat_Diplomados resultado = new Models.Cat_Diplomados();
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
