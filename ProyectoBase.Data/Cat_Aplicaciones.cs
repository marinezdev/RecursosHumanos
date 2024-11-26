using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Aplicaciones
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Aplicaciones> Cat_Aplicaciones_Seleccionar()
        {
            const string consulta = "Cat_Aplicaciones_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_Aplicaciones> resultado = new List<Models.Cat_Aplicaciones>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Aplicaciones>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Aplicaciones Cat_Aplicaciones_Agregar(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            const string consulta = "Cat_Aplicaciones_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", cat_Aplicaciones.Nombre, SqlDbType.VarChar);

            Models.Cat_Aplicaciones resultado = new Models.Cat_Aplicaciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_Aplicaciones>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Cat_Aplicaciones Cat_Aplicaciones_Seleccionar_Id(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            const string consulta = "Cat_Aplicaciones_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", cat_Aplicaciones.Id, SqlDbType.Int);

            Models.Cat_Aplicaciones resultado = new Models.Cat_Aplicaciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_Aplicaciones>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Aplicaciones Cat_Aplicaciones_Elimnar(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            const string consulta = "Cat_Aplicaciones_Elimnar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", cat_Aplicaciones.Id, SqlDbType.Int);

            Models.Cat_Aplicaciones resultado = new Models.Cat_Aplicaciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cat_Aplicaciones>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
