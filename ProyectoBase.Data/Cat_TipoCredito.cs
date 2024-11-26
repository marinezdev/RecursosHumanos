using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_TipoCredito
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_TipoCredito> Cat_TipoCredito_Selecionar_Listar()
        {
            b.ExecuteCommandSP("Cat_TipoCredito_Selecionar_Listar");
            List<Models.Cat_TipoCredito> resultado = new List<Models.Cat_TipoCredito>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_TipoCredito item = new Models.Cat_TipoCredito()
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
