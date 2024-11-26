using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ProspectoEntrevista
    {
        ManejoDatos b = new ManejoDatos();

        public Models.ProspectoEntrevista ProspectoEntrevista_Agregar(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "Vacantes.ProspectoEntrevista_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@FechaEntrevista", prospectoEntrevista.FechaEntrevista, SqlDbType.DateTime);
            b.AddParameter("@Observaciones", prospectoEntrevista.Observaciones, SqlDbType.VarChar);
            b.AddParameter("@Responsable", prospectoEntrevista.Responsable, SqlDbType.Int);
            b.AddParameter("@IdResponsble", prospectoEntrevista.IdResponsble, SqlDbType.Int);
            b.AddParameter("@EntrevistaAceptada", prospectoEntrevista.EntrevistaAceptada, SqlDbType.Int);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoEntrevista ProspectoEntrevista_Seleccionar_Id(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "Vacantes.ProspectoEntrevista_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoEntrevista> ProspectoEntrevista_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.ProspectoEntrevista_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.ProspectoEntrevista> resultado = new List<Models.ProspectoEntrevista>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoEntrevista>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoEntrevista> ProspectoEntrevista_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.ProspectoEntrevista_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoEntrevista> resultado = new List<Models.ProspectoEntrevista>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoEntrevista>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoEntrevista ProspectoEntrevista_Actualizar_IdEstatus(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "Vacantes.ProspectoEntrevista_Actualizar_IdEstatus";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", prospectoEntrevista.Cat_EstatusEntrevistas.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", prospectoEntrevista.Observaciones, SqlDbType.NVarChar);
            b.AddParameter("@Clave", prospectoEntrevista.Clave, SqlDbType.NVarChar);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoEntrevista Vacante_Actualizar_entrevista(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "Vacantes.ProspectoEntrevista_Actualizar ";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", prospectoEntrevista.Observaciones, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospectoEntrevista.Vacante.Id, SqlDbType.Int);

            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.ProspectoEntrevista Prospecto_EliminarEntrevista(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "Vacantes.Prospecto_EliminarEntrevista";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoEntrevista.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospectoEntrevista.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
