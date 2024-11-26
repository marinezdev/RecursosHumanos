using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_TipoPrueba
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_TipoPrueba> Cat_TipoPrueba_Seleccionar()
        {
            const string consulta = "Vacantes.Cat_TipoPrueba_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_TipoPrueba> resultado = new List<Models.Cat_TipoPrueba>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_TipoPrueba>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
