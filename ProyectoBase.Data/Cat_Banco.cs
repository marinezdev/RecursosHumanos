using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Banco
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Banco> Cat_Banco_Selecionar_Listar()
        {
            b.ExecuteCommandSP("Cat_Banco_Selecionar_Listar");
            List<Models.Cat_Banco> resultado = new List<Models.Cat_Banco>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Banco item = new Models.Cat_Banco()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_Banco Cat_Banco_Agregar(Models.Cat_Banco cat_Banco)
        {
            b.ExecuteCommandSP("Cat_Banco_Agregar");
            b.AddParameter("@NombreBanco", cat_Banco.Nombre, SqlDbType.VarChar);

            Models.Cat_Banco resultado = new Models.Cat_Banco();
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
