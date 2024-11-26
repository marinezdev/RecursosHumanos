using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstatusEntrevistas
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EstatusEntrevistas> Cat_EstatusEntrevistas_Seleccionar()
        {
            const string consulta = "Vacantes.Cat_EstatusEntrevistas_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_EstatusEntrevistas> resultado = new List<Models.Cat_EstatusEntrevistas>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusEntrevistas>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
