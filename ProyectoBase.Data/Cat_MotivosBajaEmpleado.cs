using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_MotivosBajaEmpleado
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_MotivosBajaEmpleado> Cat_MotivosBajaEmpleado_Seleccionar()
        {
            const string consulta = "Cat_MotivosBajaEmpleado_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_MotivosBajaEmpleado> resultado = new List<Models.Cat_MotivosBajaEmpleado>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_MotivosBajaEmpleado>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_MotivosBajaEmpleado Cat_MotivosBajaEmpleado_Elimnar(Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado)
        {
            const string consulta = "Cat_MotivosBajaEmpleado_Elimnar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", cat_MotivosBajaEmpleado.Id, SqlDbType.Int);

            Models.Cat_MotivosBajaEmpleado resultado = new Models.Cat_MotivosBajaEmpleado();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_MotivosBajaEmpleado>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_MotivosBajaEmpleado MotivosBajaEmpleado_Agregar(Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado)
        {
            const string consulta = "MotivosBajaEmpleado_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", cat_MotivosBajaEmpleado.Nombre, SqlDbType.VarChar);

            Models.Cat_MotivosBajaEmpleado resultado = new Models.Cat_MotivosBajaEmpleado();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_MotivosBajaEmpleado>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
