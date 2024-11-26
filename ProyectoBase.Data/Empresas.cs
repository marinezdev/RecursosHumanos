using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Empresas
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Empresas> Empresas_Seleccionar()
        {
            b.ExecuteCommandSP("Empresas_Seleccionar");
            List<Models.Empresas> resultado = new List<Models.Empresas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Empresas item = new Models.Empresas()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    RazonSocial = reader["RazonSocial"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Empresas Empresas_Agregar(Models.Empresas empresas)
        {
            b.ExecuteCommandSP("Empresas_Agregar");
            b.AddParameter("@RazonSocial", empresas.RazonSocial, SqlDbType.VarChar);
            b.AddParameter("@NombreComercial", empresas.NombreComercial, SqlDbType.VarChar);
            b.AddParameter("@Alias", empresas.Alias, SqlDbType.VarChar);
            b.AddParameter("@RFC", empresas.RFC, SqlDbType.VarChar);

            Models.Empresas resultado = new Models.Empresas();
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
