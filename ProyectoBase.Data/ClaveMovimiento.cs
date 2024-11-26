using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ClaveMovimiento
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ClaveMovimiento ClaveMovimiento_Agregar(Models.ClaveMovimiento usuarioClaveMovimiento)
        {
            const string consulta = "ClaveMovimiento_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuarioClaveMovimiento.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Movimiento", usuarioClaveMovimiento.Movimiento, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", usuarioClaveMovimiento.Observaciones, SqlDbType.NVarChar);

            Models.ClaveMovimiento resultado = new Models.ClaveMovimiento();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ClaveMovimiento>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
