using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Personas
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Personas Personas_Nuevo_Empleado(Models.Personas personas)
        {
            const string consulta = "Personas_Nuevo_Empleado";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", personas.Nombre, SqlDbType.VarChar);
            b.AddParameter("@ApPaterno", personas.ApPaterno, SqlDbType.VarChar);
            b.AddParameter("@ApMaterno", personas.ApMaterno, SqlDbType.VarChar);
            b.AddParameter("@FechaNacimiento", personas.PersonasDetalle.FechaNacimiento, SqlDbType.Date);
            b.AddParameter("@Sexo", personas.PersonasDetalle.Sexo, SqlDbType.Int);
            b.AddParameter("@IdEstadoCivil", personas.PersonasDetalle.Cat_EstadoCivil.Id, SqlDbType.Int);
            b.AddParameter("@RFC", personas.PersonasDetalle.RFC, SqlDbType.VarChar);
            b.AddParameter("@CURP", personas.PersonasDetalle.CURP, SqlDbType.VarChar);
            b.AddParameter("@NSS", personas.PersonasDetalle.NSS, SqlDbType.VarChar);
            b.AddParameter("@IdTipoCredito", personas.PersonasDetalle.Cat_TipoCredito.Id, SqlDbType.Int);
            b.AddParameter("@IdBanco", personas.PersonasDetalle.Cat_Banco.Id, SqlDbType.Int);
            b.AddParameter("@ClaveInterbancaria", personas.PersonasDetalle.ClaveInterbancaria, SqlDbType.VarChar);
            b.AddParameter("@NoNomina", personas.PersonasDetalle.NoNomina, SqlDbType.VarChar);
            b.AddParameter("@TelefonoCelular", personas.PersonasDetalle.TelefonoCelular, SqlDbType.VarChar);
            b.AddParameter("@TelefonoFijo", personas.PersonasDetalle.TelefonoFijo, SqlDbType.VarChar);
            b.AddParameter("@CorreoPersonal", personas.PersonasDetalle.CorreoPersonal, SqlDbType.VarChar);
            b.AddParameter("@CorreoCorporativo", personas.PersonasDetalle.CorreoCorporativo, SqlDbType.VarChar);

            b.AddParameter("@IdColonia", personas.PersonasDirecciones.IdColonia, SqlDbType.Int);
            b.AddParameter("@Calle", personas.PersonasDirecciones.Calle, SqlDbType.VarChar);
            b.AddParameter("@NumExterior", personas.PersonasDirecciones.NumExterior, SqlDbType.VarChar);
            b.AddParameter("@NumInteriror", personas.PersonasDirecciones.NumInteriror, SqlDbType.VarChar);
            b.AddParameter("@EntreCalles", personas.PersonasDirecciones.EntreCalles, SqlDbType.VarChar);
            b.AddParameter("@Referencias", personas.PersonasDirecciones.Referencias, SqlDbType.VarChar);
            b.AddParameter("@IdPuesto", personas.PersonasDetalle.EmpresaPuestos.Id, SqlDbType.Int);
            b.AddParameter("@IdProyectoServicios", personas.PersonasDetalle.Cat_ProyectoServicios.Id, SqlDbType.Int);
            b.AddParameter("@IdEsquemaContratacion", personas.PersonasDetalle.Cat_EsquemaContratacion.Id, SqlDbType.Int);
            b.AddParameter("@IdClienteDireccion", personas.PersonasDetalle.clienteDireciones.Id, SqlDbType.Int);
            b.AddParameter("@Sueldo", personas.PersonasDetalle.Sueldo, SqlDbType.VarChar);

            b.AddParameter("@Empresa", personas.PersonasExperiencia.Empresa, SqlDbType.VarChar);
            b.AddParameter("@Puesto", personas.PersonasExperiencia.Puesto, SqlDbType.VarChar);
            b.AddParameter("@MotivoSalida", personas.PersonasExperiencia.MotivoSalida, SqlDbType.VarChar);
            b.AddParameter("@Actividades", personas.PersonasExperiencia.Actividades, SqlDbType.VarChar);

            b.AddParameter("@FechaIngreso", personas.PersonasDetalle.FechaIngreso, SqlDbType.Date);
            b.AddParameter("@IdFuenteReclutamiento", personas.PersonasDetalle.Cat_FuenteReclutamiento.Id, SqlDbType.Int);
            b.AddParameter("@Vencimiento", personas.PersonasDetalle.Vencimiento, SqlDbType.Int);
            b.AddParameter("@Fechavencimiento", personas.PersonasDetalle.Fechavencimiento, SqlDbType.Date);
            b.AddParameter("@IdUsuario", personas.PersonasDetalle.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personas.PersonasDetalle.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivo", personas.PersonasDetalle.NmArchivo, SqlDbType.NVarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Personas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Personas Personas_Seleccionar_Id(Models.Personas personas)
        {
            const string consulta = "Personas_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personas.Id, SqlDbType.VarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Personas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //public Models.Personas Personas_Seleccionar_Id(Models.Personas personas)
        //{
        //    const string consulta = "Personas_Seleccionar_Id";
        //    b.ExecuteCommandSP(consulta);
        //    b.AddParameter("@Id", personas.Id, SqlDbType.VarChar);

        //    Models.Personas resultado = new Models.Personas();
        //    var reader = b.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        //resultado.Id = Convert.ToInt32(reader["Id"].ToString());
        //        //resultado.NmArchivo = reader["NmArchivo"].ToString();
        //        //resultado.Folio = reader["Folio"].ToString();
        //        ///*Información Basica*/
        //        //resultado.Nombre = reader["Nombre"].ToString() + " " + reader["ApPaterno"].ToString() + " " + reader["ApMaterno"].ToString();
        //        //resultado.FechaNacimiento = reader["FechaNacimiento"].ToString();
        //        //resultado.SexoTxt = reader["Sexo"].ToString();
        //        //resultado.EstadoCivil = reader["EstadoCivil"].ToString();
        //        //resultado.RFC = reader["RFC"].ToString();
        //        //resultado.CURP = reader["CURP"].ToString();
        //        //resultado.NSS = reader["NSS"].ToString();
        //        //resultado.TipoCredito = reader["TipoCredito"].ToString();
        //        //resultado.Banco = reader["Banco"].ToString();
        //        //resultado.ClaveInterbancaria = reader["ClaveInterbancaria"].ToString();
        //        //resultado.NoNomina = reader["NoNomina"].ToString();
        //        ////Contacto
        //        //resultado.TelefonoCelular = reader["TelefonoCelular"].ToString();
        //        //resultado.TelefonoFijo = reader["TelefonoFijo"].ToString();
        //        ////Información Académica
        //        //resultado.Estudios = reader["Estudios"].ToString();
        //        //resultado.EstatusEstudios = reader["EstatusEstudios"].ToString();
        //        //resultado.NivelIngles = reader["NivelIngles"].ToString();
        //        ////Información del Puesto
        //        //resultado.Empresa = reader["Empresa"].ToString();
        //        //resultado.Departamento = reader["Departamento"].ToString();
        //        //resultado.Puestos = reader["Puestos"].ToString();
        //        //resultado.Cliente = reader["Cliente"].ToString();
        //        //resultado.ProyectoServicios = reader["ProyectoServicios"].ToString();
        //        //resultado.EsquemaContratacion = reader["EsquemaContratacion"].ToString();
        //        //resultado.Sueldo = reader["Sueldo"].ToString();
        //        ////Registrar
        //        //resultado.FechaIngreso = reader["FechaIngreso"].ToString();
        //        //resultado.Fechavencimiento = reader["Fechavencimiento"].ToString();
        //        //resultado.Vencimiento = Convert.ToInt32(reader["Vencimiento"].ToString());
        //        //resultado.FuenteReclutamiento = reader["FuenteReclutamiento"].ToString();

        //        //resultado.Activo = Convert.ToInt32(reader["Activo"].ToString());
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;
        //}

        public Models.Personas Empleados_ConsultaCURP(Models.Personas personas)
        {
            const string consulta = "Empleados_ConsultaCURP";
            b.ExecuteCommandSP(consulta);
            b.ExecuteCommandSP("Empleados_ConsultaCURP");
            b.AddParameter("@CURP", personas.PersonasDetalle.CURP, SqlDbType.VarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Personas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Personas Personas_Editar_Seleccionar_Id(Models.Personas personas)
        {
            b.ExecuteCommandSP("Personas_Editar_Seleccionar_Id");
            b.AddParameter("@Id", personas.Id, SqlDbType.VarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Personas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Personas Personas_Actualizar_InformacionBasica(Models.Personas personas)
        {
            const string consulta = "Personas_Actualizar_InformacionBasica";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.VarChar);
            b.AddParameter("@Nombre", personas.Nombre, SqlDbType.VarChar);
            b.AddParameter("@ApPaterno", personas.ApPaterno, SqlDbType.VarChar);
            b.AddParameter("@ApMaterno", personas.ApMaterno, SqlDbType.VarChar);
            b.AddParameter("@FechaNacimiento", personas.PersonasDetalle.FechaNacimiento, SqlDbType.Date);
            b.AddParameter("@Sexo", personas.PersonasDetalle.Sexo, SqlDbType.Int);
            b.AddParameter("@IdEstadoCivil", personas.PersonasDetalle.Cat_EstadoCivil.Id, SqlDbType.Int);
            b.AddParameter("@RFC", personas.PersonasDetalle.RFC, SqlDbType.VarChar);
            b.AddParameter("@CURP", personas.PersonasDetalle.CURP, SqlDbType.VarChar);
            b.AddParameter("@NSS", personas.PersonasDetalle.NSS, SqlDbType.VarChar);
            b.AddParameter("@IdTipoCredito", personas.PersonasDetalle.Cat_TipoCredito.Id, SqlDbType.Int);
            b.AddParameter("@IdBanco", personas.PersonasDetalle.Cat_Banco.Id, SqlDbType.Int);
            b.AddParameter("@ClaveInterbancaria", personas.PersonasDetalle.ClaveInterbancaria, SqlDbType.VarChar);
            b.AddParameter("@NoNomina", personas.PersonasDetalle.NoNomina, SqlDbType.VarChar);
            b.AddParameter("@TelefonoCelular", personas.PersonasDetalle.TelefonoCelular, SqlDbType.VarChar);
            b.AddParameter("@TelefonoFijo", personas.PersonasDetalle.TelefonoFijo, SqlDbType.VarChar);
            b.AddParameter("@CorreoPersonal", personas.PersonasDetalle.CorreoPersonal, SqlDbType.VarChar);
            b.AddParameter("@CorreoCorporativo", personas.PersonasDetalle.CorreoCorporativo, SqlDbType.VarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Personas Empleados_Actualizar_PuestoExperiencia(Models.Personas personas)
        {
            b.ExecuteCommandSP("Empleados_Actualizar_PuestoExperiencia");
            b.AddParameter("@Id", personas.Id, SqlDbType.VarChar);
            b.AddParameter("@IdExperiencia", personas.PersonasExperiencia.Id, SqlDbType.VarChar);
            b.AddParameter("@IdPuesto", personas.PersonasDetalle.EmpresaPuestos.Id, SqlDbType.Int);
            b.AddParameter("@IdProyectoServicios", personas.PersonasDetalle.Cat_ProyectoServicios.Id, SqlDbType.Int);
            b.AddParameter("@IdClienteDireccion", personas.PersonasDetalle.clienteDireciones.Id, SqlDbType.Int);
            b.AddParameter("@IdEsquemaContratacion", personas.PersonasDetalle.Cat_EsquemaContratacion.Id, SqlDbType.Int);
            b.AddParameter("@Sueldo", personas.PersonasDetalle.Sueldo, SqlDbType.NVarChar);
            b.AddParameter("@Empresa", personas.PersonasExperiencia.Empresa, SqlDbType.NVarChar);
            b.AddParameter("@Puesto", personas.PersonasExperiencia.Puesto, SqlDbType.NVarChar);
            b.AddParameter("@MotivoSalida", personas.PersonasExperiencia.MotivoSalida, SqlDbType.NVarChar);
            b.AddParameter("@Actividades", personas.PersonasExperiencia.Actividades, SqlDbType.NVarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Personas PersonasDetalle_Actualizar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDetalle_Actualizar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            b.AddParameter("@FechaIngreso", personas.PersonasDetalle.FechaIngreso, SqlDbType.Date);
            b.AddParameter("@Fechavencimiento", personas.PersonasDetalle.Fechavencimiento, SqlDbType.Date);
            b.AddParameter("@IdFuenteReclutamiento", personas.PersonasDetalle.Cat_FuenteReclutamiento.Id, SqlDbType.Int);
            b.AddParameter("@Vencimiento", personas.PersonasDetalle.Vencimiento, SqlDbType.Int);
            b.AddParameter("@NmArchivo", personas.PersonasDetalle.NmArchivo, SqlDbType.VarChar);
            b.AddParameter("@NmOriginal", personas.PersonasDetalle.NmOriginal, SqlDbType.VarChar);

            Models.Personas resultado = new Models.Personas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Personas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
