using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_FuenteReclutamiento
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_FuenteReclutamiento> Cat_FuenteReclutamiento_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_FuenteReclutamiento_Seleccionar");
            List<Models.Cat_FuenteReclutamiento> resultado = new List<Models.Cat_FuenteReclutamiento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_FuenteReclutamiento item = new Models.Cat_FuenteReclutamiento()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
