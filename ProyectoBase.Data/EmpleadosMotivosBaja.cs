using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class EmpleadosMotivosBaja
    {
        ManejoDatos b = new ManejoDatos();
        public Models.EmpleadosMotivosBaja EmpleadosMotivosBaja_Agregar(Models.Personas personas, Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado)
        {
            const string consulta = "EmpleadosMotivosBaja_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            b.AddParameter("@IdMotivo", cat_MotivosBajaEmpleado.Id, SqlDbType.Int);
            Models.EmpleadosMotivosBaja resultado = new Models.EmpleadosMotivosBaja();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.EmpleadosMotivosBaja>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
