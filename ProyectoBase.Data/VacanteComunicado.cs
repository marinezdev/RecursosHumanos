using Newtonsoft.Json;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class VacanteComunicado
    {
        ManejoDatos b = new ManejoDatos();
        public Models.VacanteComunicado VacanteComunicado_Agregar(Models.VacanteComunicado vacanteComunicado)
        {
            const string consulta = "Vacantes.VacanteComunicado_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacanteComunicado.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", vacanteComunicado.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Clave", vacanteComunicado.Clave, SqlDbType.NVarChar);
            b.AddParameter("@Titulo", vacanteComunicado.Titulo, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", vacanteComunicado.Observaciones, SqlDbType.NVarChar);

            Models.VacanteComunicado resultado = new Models.VacanteComunicado();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteComunicado>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
