using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PuestoAplicacion
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.PuestoAplicacion> PuestoAplicacion_Seleccionar_IdPuesto(Models.EmpresaPuestos empresaPuestos)
        {
            const string consulta = "PuestoAplicacion_Seleccionar_IdPuesto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPuesto", empresaPuestos.Id, SqlDbType.Int);

            List<Models.PuestoAplicacion> resultado = new List<Models.PuestoAplicacion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PuestoAplicacion>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.PuestoAplicacion PuestoAplicacion_Agregar(Models.PuestoAplicacion puestoAplicacion)
        {
            const string consulta = "PuestoAplicacion_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPuesto", puestoAplicacion.EmpresaPuestos.Id, SqlDbType.Int);
            b.AddParameter("@IdAplicacion", puestoAplicacion.Cat_Aplicaciones.Id, SqlDbType.Int);

            Models.PuestoAplicacion resultado = new Models.PuestoAplicacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PuestoAplicacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.PuestoAplicacion PuestoAplicacion_Elimnar(Models.PuestoAplicacion puestoAplicacion)
        {
            const string consulta = "PuestoAplicacion_Elimnar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", puestoAplicacion.Id, SqlDbType.Int);

            Models.PuestoAplicacion resultado = new Models.PuestoAplicacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PuestoAplicacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        
    }
}
