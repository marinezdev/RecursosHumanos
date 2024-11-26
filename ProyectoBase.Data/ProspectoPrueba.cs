using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ProspectoPrueba
    {
        ManejoDatos b = new ManejoDatos();

        public Models.ProspectoPrueba ProspectoPrueba_Agregar(Models.ProspectoPrueba prospectoPrueba)
        {
            const string consulta = "Vacantes.ProspectoPrueba_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", prospectoPrueba.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", prospectoPrueba.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoPrueba", prospectoPrueba.Cat_TipoPrueba.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", prospectoPrueba.Cat_EstatusPrueba.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", prospectoPrueba.Observaciones, SqlDbType.VarChar);

            Models.ProspectoPrueba resultado = new Models.ProspectoPrueba();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoPrueba>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.ProspectoPruebas ProspectoPrueba_Seleccionar_Id(Models.ProspectoPrueba prospectoPrueba)
        {
            const string consulta = "Vacantes.ProspectoPrueba_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoPrueba.Id, SqlDbType.Int);

            Models.Consultas.ProspectoPruebas resultado = new Models.Consultas.ProspectoPruebas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.ProspectoPruebas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoPrueba> ProspectoPrueba_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.ProspectoPrueba_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.ProspectoPrueba> resultado = new List<Models.ProspectoPrueba>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoPrueba>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ProspectoPrueba> ProspectoPrueba_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.ProspectoPrueba_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoPrueba> resultado = new List<Models.ProspectoPrueba>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoPrueba>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.ProspectoPrueba ProspectoPrueba_Actualizar_IdEstatus(Models.ProspectoPrueba prospectoPrueba)
        {
            const string consulta = "Vacantes.ProspectoPrueba_Actualizar_IdEstatus";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoPrueba.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoPrueba.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", prospectoPrueba.Cat_EstatusPrueba.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", prospectoPrueba.Observaciones, SqlDbType.VarChar);
            b.AddParameter("@Clave", prospectoPrueba.Clave, SqlDbType.VarChar);

            Models.ProspectoPrueba resultado = new Models.ProspectoPrueba();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoPrueba>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.ProspectoPrueba ProspectoPrueba_EliminarPrueba(Models.ProspectoPrueba prospectoPrueba)
        {
            const string consulta = "Vacantes.Prospecto_EliminarPruebaPsicometrica";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoPrueba.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoPrueba.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospectoPrueba.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", prospectoPrueba.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoPrueba resultado = new Models.ProspectoPrueba();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoPrueba>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
