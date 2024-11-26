using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EsquemaContratacion
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EsquemaContratacion> Cat_EsquemaContratacion_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_EsquemaContratacion_Seleccionar");
            List<Models.Cat_EsquemaContratacion> resultado = new List<Models.Cat_EsquemaContratacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_EsquemaContratacion item = new Models.Cat_EsquemaContratacion()
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
