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
    public class Vacante
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Vacante> Vacante_Seleccionar()
        {
            const string consulta = "Vacantes.Vacante_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Vacante Vacante_Seleccionar_Id(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Vacante Vacante_Actualizar_IdEstatus(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.Vacante_Actualizar_IdEstatus";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", vacante.Cat_EstatusVacante.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", vacante.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Clave", vacante.Clave, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", vacante.Descripcion, SqlDbType.NVarChar);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.VacanteUsuario Vacante_Seleccionar_Usuario_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_Usuario_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

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
        public Models.Vacante Prospecto_Eliminar_Id(Models.Vacante vacante)
        {
            const string consulta = "Vacantes.Vacante_Eliminar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);
           

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// //  CONSULTA REPORTE GENERAL 
        /// </summary>
        /// <returns></returns>

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_Seleccionar()
        {
            const string consulta = "Vacantes.Vacante_Estatus_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_EstatusVacante> resultado = new List<Models.Cat_EstatusVacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusVacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_Clientes> Vacante_Clientes_Seleccionar()
        {
            const string consulta = "Vacantes.Vacante_Clientes_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_Clientes> resultado = new List<Models.Cat_Clientes>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Clientes>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos()
        {
            const string consulta = "Vacantes.Vacante_Estatus_Prospectos";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_EstatusProspecto> resultado = new List<Models.Cat_EstatusProspecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusProspecto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Vacante> Vacante_Seleccionar_Top3()
        {
            const string consulta = "WebAsae.RH.Vacante_Seleccionar_Top3";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        /// <summary>
        /// //  CONSULTAS DE REPORTES 
        /// </summary>
        /// <returns></returns>

        public List<Models.Vacante> Vacante_Seleccionar_Usuarios()
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_Usuarios";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Vacante> Vacante_Seleccionar_IdUsuario(Models.Usuarios usuarios)
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_IdUsuario";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuarios.Id, SqlDbType.Int);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_IdUsuario(Models.Usuarios usuarios)
        {
            const string consulta = "Vacantes.Vacante_Estatus_IdUsuario";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuarios.Id, SqlDbType.Int);

            List<Models.Cat_EstatusVacante> resultado = new List<Models.Cat_EstatusVacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusVacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos_IdUsuario(Models.Usuarios usuarios)
        {
            const string consulta = "Vacantes.Vacante_Estatus_Prospectos_IdUsuario";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuarios.Id, SqlDbType.Int);

            List<Models.Cat_EstatusProspecto> resultado = new List<Models.Cat_EstatusProspecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusProspecto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.Vacante> Vacante_Seleccionar_Reporte()
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_Reporte";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// ///////////////////////
        /// 

        public List<Models.Vacante> Vacante_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "Vacantes.Vacante_Estatus_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.Cat_EstatusVacante> resultado = new List<Models.Cat_EstatusVacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusVacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "Vacantes.Vacante_Estatus_Prospectos_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.Cat_EstatusProspecto> resultado = new List<Models.Cat_EstatusProspecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusProspecto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// ///////////////////////
        /// 

        public List<Models.Vacante> Vacante_Seleccionar_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            const string consulta = "Vacantes.Vacante_Seleccionar_IdProyecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProyecto", cat_ProyectoServicios.Id, SqlDbType.Int);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusVacante> Vacante_Estatus_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            const string consulta = "Vacantes.Vacante_Estatus_IdProyecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProyecto", cat_ProyectoServicios.Id, SqlDbType.Int);

            List<Models.Cat_EstatusVacante> resultado = new List<Models.Cat_EstatusVacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusVacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_EstatusProspecto> Vacante_Estatus_Prospectos_IdProyecto(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            const string consulta = "Vacantes.Vacante_Estatus_Prospectos_IdProyecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProyecto", cat_ProyectoServicios.Id, SqlDbType.Int);

            List<Models.Cat_EstatusProspecto> resultado = new List<Models.Cat_EstatusProspecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EstatusProspecto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Vacante Vacante_Agregar(Models.Vacante vacante)
        {
            const string consulta = "WebAsae.RH.Vacante_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPuesto", vacante.EmpresaPuestos.Id, SqlDbType.Int);
            b.AddParameter("@IdProyecto", vacante.Cat_ProyectoServicios.Id, SqlDbType.Int);
            b.AddParameter("@IdClienteDireccion", vacante.ClienteDirecciones.Id, SqlDbType.Int);
            b.AddParameter("@IdEsquemaContratacion", vacante.Cat_EsquemaContratacion.Id, SqlDbType.Int);
            b.AddParameter("@IdModalidad", vacante.Cat_Modalidad.Id, SqlDbType.Int);
            b.AddParameter("@IdJornada", vacante.Cat_JornadaTrabajo.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", vacante.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Titulo", vacante.Titulo, SqlDbType.NVarChar);
            b.AddParameter("@Salario", vacante.Salario, SqlDbType.Int);
            b.AddParameter("@SalarioInicial", vacante.SalarioInicial, SqlDbType.Float);
            b.AddParameter("@SalarioFinal", vacante.SalarioFinal, SqlDbType.Float);
            b.AddParameter("@FechaCierre", vacante.FechaCierre, SqlDbType.Date);

            b.AddParameter("@IdEmpleadoBaja", vacante.IdEmpleadoBaja, SqlDbType.Int);
            b.AddParameter("@IdMotivosBaja", vacante.Cat_MotivosBajaEmpleado.Id, SqlDbType.Int);
            b.AddParameter("@FechaBaja", vacante.FechaBaja, SqlDbType.Date);

            b.AddParameter("@Contenido", vacante.Contenido, SqlDbType.NVarChar);
            b.AddParameter("@Notificacion", vacante.Notificacion, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
