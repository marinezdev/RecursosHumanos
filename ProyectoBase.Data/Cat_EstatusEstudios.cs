using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstatusEstudios
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EstatusEstudios> Cat_EstatusEstudios_Selecionar_Listar()
        {
            b.ExecuteCommandSP("Cat_EstatusEstudios_Selecionar_Listar");
            List<Models.Cat_EstatusEstudios> resultado = new List<Models.Cat_EstatusEstudios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_EstatusEstudios item = new Models.Cat_EstatusEstudios()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_EstatusEstudios Cat_EstatusEstudios_Selecionar_Id(int Id)
        {
            const string consulta = "Cat_EstatusEstudios_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", Id, SqlDbType.Int);

            Models.Cat_EstatusEstudios resultado = new Models.Cat_EstatusEstudios();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_EstatusEstudios>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
