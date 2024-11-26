using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ClienteDireciones
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ClienteDireciones ClienteDirecciones_Agregar(Models.ClienteDireciones clienteDireciones)
        {
            const string consulta = "ClienteDirecciones_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", clienteDireciones.Cat_Clientes.Id, SqlDbType.Int);
            b.AddParameter("@IdColonia", clienteDireciones.Cat_Colonias.Id, SqlDbType.Int);
            b.AddParameter("@Calle", clienteDireciones.Calle, SqlDbType.VarChar);
            b.AddParameter("@NumExterior", clienteDireciones.NumExterior, SqlDbType.VarChar);
            b.AddParameter("@NumInteriror", clienteDireciones.NumInteriror, SqlDbType.VarChar);
            b.AddParameter("@EntreCalles", clienteDireciones.EntreCalles, SqlDbType.VarChar);
            b.AddParameter("@Referencias", clienteDireciones.Referencias, SqlDbType.VarChar);

            Models.ClienteDireciones resultado = new Models.ClienteDireciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ClienteDireciones>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ClienteDireciones> ClienteDirecciones_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "ClienteDirecciones_Seleccionar_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.ClienteDireciones> resultado = new List<Models.ClienteDireciones>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ClienteDireciones>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
