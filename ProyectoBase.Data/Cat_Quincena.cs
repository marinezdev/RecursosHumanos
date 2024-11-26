using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Quincena
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Cat_Quincena Cat_Quincena_Selecionar_Quincena(Models.Cat_Quincena cat_Quincena)
        {
            const string consulta = "Cat_Quincena_Selecionar_Quincena";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", cat_Quincena.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Mes", cat_Quincena.Mes, SqlDbType.VarChar);

            Models.Cat_Quincena resultado = new Models.Cat_Quincena();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_Quincena>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
