using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasDocumentos
    {
        ManejoDatos b = new ManejoDatos();
        public Models.PersonasDocumentos PersonasDocumento_Agregar(Models.PersonasDocumentos personasDocumentos)
        {
            const string consulta = "PersonasDocumento_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personasDocumentos.Personas.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoDocumento", personasDocumentos.Cat_TipoDocumento.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatusDocumento", personasDocumentos.Cat_EstatusDocumento.Id, SqlDbType.Int);
            b.AddParameter("@FechaEntrega", personasDocumentos.FechaEntrega, SqlDbType.Date);
            b.AddParameter("@FechaVigencia", personasDocumentos.FechaVigencia, SqlDbType.Date);
            b.AddParameter("@IdUsuario", personasDocumentos.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Version", personasDocumentos.DocumentoVersiones.Version, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", personasDocumentos.DocumentoVersiones.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivo", personasDocumentos.DocumentoVersiones.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", personasDocumentos.DocumentoVersiones.NmOriginal, SqlDbType.NVarChar);

            Models.PersonasDocumentos resultado = new Models.PersonasDocumentos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDocumentos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.PersonasDocumentos> PersonasDocumento_Seleccionar_Editar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasDocumento_Seleccionar_Editar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasDocumentos> resultado = new List<Models.PersonasDocumentos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasDocumentos>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_Eliminar(Models.PersonasDocumentos personasDocumentos)
        {
            const string consulta = "PersonasDocumentos_Editar_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDocumentos.Id, SqlDbType.Int);

            Models.PersonasDocumentos resultado = new Models.PersonasDocumentos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDocumentos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_ActualizarArchivo(Models.PersonasDocumentos personasDocumentos)
        {
            const string consulta = "PersonasDocumentos_Editar_ActualizarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDocumentos.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", personasDocumentos.Cat_EstatusDocumento.Id, SqlDbType.Int);
            b.AddParameter("@NmOriginal", personasDocumentos.DocumentoVersiones.NmOriginal, SqlDbType.VarChar);
            b.AddParameter("@NmArchivo", personasDocumentos.DocumentoVersiones.NmArchivo, SqlDbType.VarChar);

            Models.PersonasDocumentos resultado = new Models.PersonasDocumentos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDocumentos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_EliminarArchivo(Models.PersonasDocumentos personasDocumentos)
        {
            const string consulta = "PersonasDocumentos_Editar_EliminarArchivo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDocumentos.Id, SqlDbType.Int);
            b.AddParameter("@IdEstatus", personasDocumentos.Cat_EstatusDocumento.Id, SqlDbType.Int);

            Models.PersonasDocumentos resultado = new Models.PersonasDocumentos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDocumentos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_Selecionar(Models.PersonasDocumentos personasDocumentos)
        {
            const string consulta = "PersonasDocumentos_Editar_Selecionar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personasDocumentos.Id, SqlDbType.Int);

            Models.PersonasDocumentos resultado = new Models.PersonasDocumentos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDocumentos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.PersonasDocumento_PorcentajeEstatus> PersonasDocumento_Estatus_Seleccionar_IdPersona(Models.Personas personas)
        {
            const string consulta = "PersonasDocumento_Estatus_Seleccionar_IdPersona";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Consultas.PersonasDocumento_PorcentajeEstatus> resultado = new List<Models.Consultas.PersonasDocumento_PorcentajeEstatus>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonasDocumento_PorcentajeEstatus>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.PersonasDocumentos> PersonasDocumento_Documento_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasDocumentos> resultado = new List<Models.PersonasDocumentos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasDocumentos>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.PersonasDocumentos> PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Seleccionar_IdPersonaPDF");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasDocumentos> resultado = new List<Models.PersonasDocumentos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonasDocumentos>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.PersonasDocumentos PersonasDocumento_Seleccionar_Id(Models.PersonasDocumentos personasDocumentos)
        {
            b.ExecuteCommandSP("PersonasDocumento_Seleccionar_Id");
            b.AddParameter("@Id", personasDocumentos.Id, SqlDbType.Int);

            Models.PersonasDocumentos resultado = new Models.PersonasDocumentos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonasDocumentos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje()
        {
            b.ExecuteCommandSP("PersonasDocumento_Procentaje");
            Models.Consultas.PersonasDocumento_Procentaje resultado = new Models.Consultas.PersonasDocumento_Procentaje ();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonasDocumento_Procentaje>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje_IdEmpresa(Models.Empresas empresas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Procentaje_IdEmpresa");
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);
            Models.Consultas.PersonasDocumento_Procentaje resultado = new Models.Consultas.PersonasDocumento_Procentaje();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonasDocumento_Procentaje>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje()
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Procentaje");
            List<Models.Consultas.PersonasDocumento_Procentaje> resultado = new List<Models.Consultas.PersonasDocumento_Procentaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonasDocumento_Procentaje>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje_IdEmpresa(Models.Empresas empresas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Procentaje_IdEmpresa");
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);
            List<Models.Consultas.PersonasDocumento_Procentaje> resultado = new List<Models.Consultas.PersonasDocumento_Procentaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonasDocumento_Procentaje>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes)
        {
            b.ExecuteCommandSP("PersonasDocumento_Procentaje_Cliente");
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);
            Models.Consultas.PersonasDocumento_Procentaje resultado = new Models.Consultas.PersonasDocumento_Procentaje();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonasDocumento_Procentaje>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            b.ExecuteCommandSP("PersonasDocumento_Procentaje_Cliente_ProyectoServicio");
            b.AddParameter("@Id", cat_ProyectoServicios.Id, SqlDbType.Int);
            Models.Consultas.PersonasDocumento_Procentaje resultado = new Models.Consultas.PersonasDocumento_Procentaje();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.PersonasDocumento_Procentaje>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.Consultas.PersonasDocumento_Clientes> PersonasDocumento_Clientes_IdEmpresa(Models.Empresas empresas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Clientes_IdEmpresa");
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);
            List<Models.Consultas.PersonasDocumento_Clientes> resultado = new List<Models.Consultas.PersonasDocumento_Clientes>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonasDocumento_Clientes>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Procentaje_Cliente");
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);
            List<Models.Consultas.PersonasDocumento_Procentaje> resultado = new List<Models.Consultas.PersonasDocumento_Procentaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonasDocumento_Procentaje>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Procentaje_Cliente_ProyectoServicio");
            b.AddParameter("@Id", cat_ProyectoServicios.Id, SqlDbType.Int);
            List<Models.Consultas.PersonasDocumento_Procentaje> resultado = new List<Models.Consultas.PersonasDocumento_Procentaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.PersonasDocumento_Procentaje>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
