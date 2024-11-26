using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_EstatusDocumento
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EstatusDocumento> Cat_EstatusDocumento_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_EstatusDocumento_Seleccionar");
            List<Models.Cat_EstatusDocumento> resultado = new List<Models.Cat_EstatusDocumento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_EstatusDocumento item = new Models.Cat_EstatusDocumento()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_EstatusDocumento Cat_EstatusDocumento_Selecionar_Id(int Id)
        {
            const string consulta = "Cat_EstatusDocumento_Selecionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", Id, SqlDbType.Int);

            Models.Cat_EstatusDocumento resultado = new Models.Cat_EstatusDocumento();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_EstatusDocumento>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
