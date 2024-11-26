using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstatusPrueba
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EstatusPrueba> Cat_EstatusPrueba_Seleccionar()
        {
            const string consulta = "Vacantes.Cat_EstatusPrueba_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_EstatusPrueba> resultado = new List<Models.Cat_EstatusPrueba>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusPrueba>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
