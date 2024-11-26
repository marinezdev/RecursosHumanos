using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoBase.Data
{
    public class Cat_ProyectoServicios
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_ProyectoServicios> Cat_ProyectoServicios_Seleccionar(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            b.ExecuteCommandSP("Cat_ProyectoServicios_Seleccionar");
            b.AddParameter("@IdCliente", cat_ProyectoServicios.IdCliente, SqlDbType.VarChar);
            List<Models.Cat_ProyectoServicios> resultado = new List<Models.Cat_ProyectoServicios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ProyectoServicios item = new Models.Cat_ProyectoServicios()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_ProyectoServicios Cat_ProyectoServicios_Agregar(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            b.ExecuteCommandSP("Cat_ProyectoServicios_Agregar");
            b.AddParameter("@IdCliente", cat_ProyectoServicios.IdCliente, SqlDbType.VarChar);
            b.AddParameter("@Nombre", cat_ProyectoServicios.Nombre, SqlDbType.VarChar);
            Models.Cat_ProyectoServicios resultado = new Models.Cat_ProyectoServicios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_ProyectoServicios> Cat_ProyectoServicios_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "WebAsae.RH.Cat_ProyectoServicios_Seleccionar_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.Cat_ProyectoServicios> resultado = new List<Models.Cat_ProyectoServicios>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_ProyectoServicios>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
