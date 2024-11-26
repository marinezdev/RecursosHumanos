using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Documento
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Documento PersonasDocumento_Agregar(Models.Documento documento)
        {
            b.ExecuteCommandSP("PersonasDocumento_Agregar");
            b.AddParameter("@IdPersona", documento.IdPersona, SqlDbType.Int);
            b.AddParameter("@IdTipoDocumento", documento.IdTipoDocumento, SqlDbType.Int);
            b.AddParameter("@IdEstatusDocumento", documento.IdEstatusDocumento, SqlDbType.Int);
            b.AddParameter("@FechaEntrega", documento.FechaEntrega, SqlDbType.Date);
            b.AddParameter("@FechaVigencia", documento.FechaVigencia, SqlDbType.Date);
            b.AddParameter("@IdUsuario", documento.IdUsuario, SqlDbType.Int);
            b.AddParameter("@Version", documento.Version, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", documento.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivo", documento.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", documento.NmOriginal, SqlDbType.NVarChar);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Documento> PersonasDocumento_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    NmArchivo = reader["NmArchivo"].ToString(),
                    TipoDocumento = reader["TipoDocumento"].ToString(),
                    EstatusDocumento = reader["EstatusDocumento"].ToString(),
                    FechaEntrega = reader["FechaEntrega"].ToString(),
                    FechaRegstro = reader["FechaRegstro"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Documento> PersonasDocumento_Estatus_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Estatus_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    EstatusDocumento = reader["EstatusDocumento"].ToString(),
                    Total = Convert.ToInt32(reader["Total"].ToString()),
                    Porcentaje = Convert.ToInt32(reader["Porcentaje"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Documento> PersonasDocumento_Documento_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    TipoDocumento = reader["TipoDocumento"].ToString(),
                    EstatusDocumento = reader["EstatusDocumento"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Documento> PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Documento_Seleccionar_IdPersonaPDF");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    NmArchivo = reader["NmArchivo"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Documento PersonasDocumento_Seleccionar_Id(Models.Documento documento)
        {
            b.ExecuteCommandSP("PersonasDocumento_Seleccionar_Id");
            b.AddParameter("@Id", documento.Id, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdPersona = Convert.ToInt32(reader["IdPersona"].ToString());
                resultado.NmArchivo = reader["NmArchivo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Documento> PersonasDocumento_Seleccionar_Editar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Seleccionar_Editar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    IdPersona = Convert.ToInt32(reader["IdPersona"].ToString()),
                    IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"].ToString()),
                    IdArchivo = Convert.ToInt32(reader["IdArchivo"].ToString()),
                    NmArchivo = reader["NmArchivo"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"].ToString()).ToString("yyyy-MM-dd"),
                    FechaVigencia = Convert.ToDateTime(reader["FechaVigencia"].ToString()).ToString("yyyy-MM-dd"),
                    IdEstatusDocumento = Convert.ToInt32(reader["IdEstatusDocumento"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Documento PersonasDocumento_Eliminar(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasDocumento_Eliminar");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
