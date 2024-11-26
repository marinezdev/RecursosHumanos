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
    public class VacanteResponsable
    {
        ManejoDatos b = new ManejoDatos();

        public Models.VacanteResponsable VacanteResponsable_Agregar(Models.VacanteResponsable vacanteResponsable)
        {
            const string consulta = "Vacantes.VacanteResponsable_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", vacanteResponsable.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", vacanteResponsable.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", vacanteResponsable.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Email", vacanteResponsable.Email, SqlDbType.VarChar);
            b.AddParameter("@Telefono", vacanteResponsable.Telefono, SqlDbType.VarChar);
            b.AddParameter("@Observaciones", vacanteResponsable.Observaciones, SqlDbType.VarChar);

            Models.VacanteResponsable resultado = new Models.VacanteResponsable();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteResponsable>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.VacanteResponsable> VacanteResponsable_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.VacanteResponsable_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.VacanteResponsable> resultado = new List<Models.VacanteResponsable>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.VacanteResponsable>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.VacanteResponsable VacanteResponsable_Eliminar(Models.VacanteResponsable VacanteResponsable)
        {
            const string consulta = "Vacantes.VacanteResponsable_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", VacanteResponsable.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", VacanteResponsable.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", VacanteResponsable.Vacante.Id, SqlDbType.Int);


            Models.VacanteResponsable resultado = new Models.VacanteResponsable();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteResponsable>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
