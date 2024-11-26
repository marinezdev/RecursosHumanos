using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ProspectoCorreo
    {
        ManejoDatos b = new ManejoDatos();

        public Models.ProspectoCorreo ProspectoCorreo_Agregar(Models.ProspectoCorreo prospectoCorreo)
        {
            const string consulta = "Vacantes.ProspectoCorreo_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoCorreo.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoCorreo.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Correo", prospectoCorreo.Correo, SqlDbType.VarChar);

            Models.ProspectoCorreo resultado = new Models.ProspectoCorreo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoCorreo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.ProspectoCorreos ProspectoCorreo_Seleccionar_Id(Models.ProspectoCorreo prospectoCorreo)
        {
            const string consulta = "Vacantes.ProspectoCorreo_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoCorreo.Id, SqlDbType.Int);

            Models.Consultas.ProspectoCorreos resultado = new Models.Consultas.ProspectoCorreos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.ProspectoCorreos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoCorreo> ProspectoCorreo_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.ProspectoCorreo_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.ProspectoCorreo> resultado = new List<Models.ProspectoCorreo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoCorreo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoCorreo> ProspectoCorreo_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.ProspectoCorreo_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoCorreo> resultado = new List<Models.ProspectoCorreo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoCorreo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoCorreo ProspectoCorreo_Actualizar(Models.ProspectoCorreo ProspectoCorreo)
        {
            const string consulta = "Vacantes.ProspectoCorreo_Actualizar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", ProspectoCorreo.Id, SqlDbType.Int);
            b.AddParameter("@Correo", ProspectoCorreo.Correo, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", ProspectoCorreo.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", ProspectoCorreo.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", ProspectoCorreo.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoCorreo resultado = new Models.ProspectoCorreo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoCorreo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoCorreo Prospecto_EliminarCorreo(Models.ProspectoCorreo prospectoEntrevista)
        {
            const string consulta = "Vacantes.Prospecto_EliminarCorreo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospectoEntrevista.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoCorreo resultado = new Models.ProspectoCorreo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoCorreo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
