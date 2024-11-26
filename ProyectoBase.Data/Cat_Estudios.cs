using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Estudios
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Estudios> Cat_Estudios_Selecionar_Listar()
        {
            b.ExecuteCommandSP("Cat_Estudios_Selecionar_Listar");
            List<Models.Cat_Estudios> resultado = new List<Models.Cat_Estudios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Estudios item = new Models.Cat_Estudios()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_Estudios Cat_Estudios_Selecionar_Id(int Id)
        {
            const string consulta = "Cat_Estudios_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", Id, SqlDbType.Int);

            Models.Cat_Estudios resultado = new Models.Cat_Estudios();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_Estudios>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
