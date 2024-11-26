using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstatusVacante
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_EstatusVacante> Cat_EstatusVacante_Seleccionar()
        {
            const string consulta = "Vacantes.Cat_EstatusVacante_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_EstatusVacante> resultado = new List<Models.Cat_EstatusVacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusVacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
