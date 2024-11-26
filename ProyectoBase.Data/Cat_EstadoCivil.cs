using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstadoCivil
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EstadoCivil> Cat_EstadoCivil_Selecionar_Listar()
        {
            b.ExecuteCommandSP("Cat_EstadoCivil_Selecionar_Listar");
            List<Models.Cat_EstadoCivil> resultado = new List<Models.Cat_EstadoCivil>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_EstadoCivil item = new Models.Cat_EstadoCivil()
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
