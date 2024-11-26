using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Clientes
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            b.ExecuteCommandSP("Cat_Clientes_Seleccionar_IdEmpresa");
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.VarChar);
            List<Models.Cat_Clientes> resultado = new List<Models.Cat_Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Clientes item = new Models.Cat_Clientes()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Clientes_Seleccionar");
            List<Models.Cat_Clientes> resultado = new List<Models.Cat_Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Clientes item = new Models.Cat_Clientes()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_Clientes Cat_Clientes_Agregar(Models.Cat_Clientes cat_Clientes)
        {
            b.ExecuteCommandSP("Cat_Clientes_Agregar");
            b.AddParameter("@Nombre", cat_Clientes.Nombre, SqlDbType.VarChar);

            Models.Cat_Clientes resultado = new Models.Cat_Clientes();
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
