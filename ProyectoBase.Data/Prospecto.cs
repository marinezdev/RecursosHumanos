using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Prospecto
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Prospecto Prospecto_Agregar(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.Prospecto_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", prospecto.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospecto.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", prospecto.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", prospecto.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", prospecto.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoCelular", prospecto.TelefonoCelular, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoFijo", prospecto.TelefonoFijo, SqlDbType.NVarChar);
            b.AddParameter("@CorreElectronico", prospecto.CorreElectronico, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", prospecto.Observaciones, SqlDbType.NVarChar);
            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.Prospecto> Prospecto_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.Prospecto_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);
            List<Models.Prospecto> resultado = new List<Models.Prospecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Prospecto>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.Prospecto Prospecto_Seleccionar_Id(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.Prospecto_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospecto.Id, SqlDbType.Int);
            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.Prospecto Prospecto_Actualizar_IdEstatus(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.Prospecto_Actualizar_IdEstatus";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospecto.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", prospecto.Cat_EstatusProspecto.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospecto.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Clave", prospecto.Clave, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", prospecto.Descripcion, SqlDbType.NVarChar);

            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.Prospectos> Prospecto_Seleccionar()
        {
            const string consulta = "Vacantes.Prospecto_Seleccionar";
            b.ExecuteCommandSP(consulta);
            List<Models.Consultas.Prospectos> resultado = new List<Models.Consultas.Prospectos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.Prospectos>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.Prospecto Prospecto_Eliminar_Id(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.Prospecto_Eliminar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospecto.Id, SqlDbType.Int);

            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.VacanteUsuario Prospecto_Seleccionar_Usuario_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.Prospecto_Seleccionar_Usuario_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            Models.Consultas.VacanteUsuario resultado = new Models.Consultas.VacanteUsuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.VacanteUsuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.VacanteResponsables Prospecto_Seleccionar_Responsable_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.Prospecto_Seleccionar_Responsable_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            Models.Consultas.VacanteResponsables resultado = new Models.Consultas.VacanteResponsables();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.VacanteResponsables>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Prospecto Prospecto_Actualizar(Models.Prospecto prospecto)
        {
            const string consulta = "Prospecto_Actualizar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", prospecto.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", prospecto.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", prospecto.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoCelular", prospecto.TelefonoCelular, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoFijo", prospecto.TelefonoFijo, SqlDbType.NVarChar);
            b.AddParameter("@CorreElectronico", prospecto.CorreElectronico, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", prospecto.Observaciones, SqlDbType.NVarChar);
            b.AddParameter("@IdUsuario", prospecto.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", prospecto.Vacante.Id, SqlDbType.Int);


            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.Prospecto ProspectoExperiencia_Eliminar(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.ProspectoExperiencia_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospecto.Id, SqlDbType.Int);

            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }


}
