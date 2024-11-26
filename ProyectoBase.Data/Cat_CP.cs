using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_CP
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_CP> Cat_CP_Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_CP_Seleccionar");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            List<Models.Cat_CP> resultado = new List<Models.Cat_CP>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_CP item = new Models.Cat_CP()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    CP = reader["CP"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Direcciones> Cat_CP_Busqueda(string CP)
        {
            b.ExecuteCommandSP("Cat_CP_Busqueda");
            b.AddParameter("@CP", CP, SqlDbType.NVarChar);
            List<Models.Direcciones> resultado = new List<Models.Direcciones>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Direcciones item = new Models.Direcciones()
                {
                    IdEstado = int.Parse(reader["IdEstado"].ToString()),
                    Estado = reader["Estado"].ToString(),
                    IdPoblacion = int.Parse(reader["IdPoblacion"].ToString()),
                    Poblacion = reader["Poblacion"].ToString(),
                    IdColonia = int.Parse(reader["IdColonia"].ToString()),
                    Colonia = reader["Colonia"].ToString(),
                    IdCP = int.Parse(reader["IdCP"].ToString()),
                    CP = reader["CP"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
