using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Cuatrimestre
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Cuatrimestre> Cat_Cuatrimestre_Seleccionar()
        {
            const string consulta = "Cat_Cuatrimestre_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_Cuatrimestre> resultado = new List<Models.Cat_Cuatrimestre>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Cuatrimestre>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
