using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ProspectoMensaje
    {
        ManejoDatos b = new ManejoDatos();

        public Models.ProspectoMensaje ProspectoMensaje_Agregar(Models.ProspectoMensaje prospectoCorreo)
        {
            const string consulta = "Vacantes.ProspectoMensaje_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoCorreo.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoCorreo.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Mensaje", prospectoCorreo.Mensaje, SqlDbType.VarChar);

            Models.ProspectoMensaje resultado = new Models.ProspectoMensaje();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoMensaje>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoMensaje> ProspectoMensaje_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.ProspectoMensaje_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.ProspectoMensaje> resultado = new List<Models.ProspectoMensaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoMensaje>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoMensaje> ProspectoMensaje_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.ProspectoMensaje_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoMensaje> resultado = new List<Models.ProspectoMensaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoMensaje>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.ProspectoMensaje ProspectoMensaje_Actualizar(Models.ProspectoMensaje prospectoEntrevista)
        {
            const string consulta = "Vacantes.ProspectoMensaje_Actualizar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@Mensaje", prospectoEntrevista.Mensaje, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospectoEntrevista.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoMensaje resultado = new Models.ProspectoMensaje();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoMensaje>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.ProspectoMensaje Prospecto_EliminarMensaje(Models.ProspectoMensaje prospectoEntrevista)
        {
            const string consulta = "Vacantes.Prospecto_EliminarMensaje";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospectoEntrevista.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoMensaje resultado = new Models.ProspectoMensaje();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoMensaje>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
