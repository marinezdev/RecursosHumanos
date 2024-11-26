using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Certificaciones
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Certificaciones> Cat_Certificaciones_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Certificaciones_Seleccionar");
            List<Models.Cat_Certificaciones> resultado = new List<Models.Cat_Certificaciones>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Certificaciones item = new Models.Cat_Certificaciones()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_Certificaciones Cat_Certificaciones_Agregar(Models.Cat_Certificaciones cat_Certificaciones)
        {
            b.ExecuteCommandSP("Cat_Certificaciones_Agregar");
            b.AddParameter("@Nombre", cat_Certificaciones.Nombre, SqlDbType.VarChar);

            Models.Cat_Certificaciones resultado = new Models.Cat_Certificaciones();
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
