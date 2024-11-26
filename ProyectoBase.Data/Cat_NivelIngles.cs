using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_NivelIngles
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_NivelIngles> Cat_NivelIngles_Selecionar_Listar()
        {
            b.ExecuteCommandSP("Cat_NivelIngles_Selecionar_Listar");
            List<Models.Cat_NivelIngles> resultado = new List<Models.Cat_NivelIngles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_NivelIngles item = new Models.Cat_NivelIngles()
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
