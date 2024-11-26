using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_TipoDocumento
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_TipoDocumento> Cat_TipoDocumento_Selecionar_Default()
        {
            const string consulta = "Cat_TipoDocumento_Selecionar_Default";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_TipoDocumento> resultado = new List<Models.Cat_TipoDocumento>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_TipoDocumento>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_TipoDocumento> Cat_TipoDocumento_Selecionar()
        {
            b.ExecuteCommandSP("Cat_TipoDocumento_Selecionar");
            List<Models.Cat_TipoDocumento> resultado = new List<Models.Cat_TipoDocumento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_TipoDocumento item = new Models.Cat_TipoDocumento()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_TipoDocumento Cat_TipoDocumento_Agregar(Models.Cat_TipoDocumento tipoDocumento)
        {
            b.ExecuteCommandSP("Cat_TipoDocumento_Agregar");
            b.AddParameter("@Nombre", tipoDocumento.Nombre, SqlDbType.VarChar);

            Models.Cat_TipoDocumento resultado = new Models.Cat_TipoDocumento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_TipoDocumento Cat_TipoDocumento_Selecionar_Id(Models.Cat_TipoDocumento tipoDocumento)
        {
            b.ExecuteCommandSP("Cat_TipoDocumento_Selecionar_Id");
            b.AddParameter("@Id", tipoDocumento.Id, SqlDbType.VarChar);

            Models.Cat_TipoDocumento resultado = new Models.Cat_TipoDocumento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
