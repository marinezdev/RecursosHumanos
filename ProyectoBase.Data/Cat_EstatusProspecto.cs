using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstatusProspecto
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EstatusProspecto> Cat_EstatusProspecto_Seleccionar()
        {
            const string consulta = "Vacantes.Cat_EstatusProspecto_Seleccionar";
            b.ExecuteCommandSP(consulta);
            List<Models.Cat_EstatusProspecto> resultado = new List<Models.Cat_EstatusProspecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusProspecto>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
