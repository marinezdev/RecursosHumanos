using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ProspectoNota
    {
        ManejoDatos b = new ManejoDatos();

        public Models.ProspectoNota ProspectoNota_Agregar(Models.ProspectoNota prospectoNota)
        {
            const string consulta = "Vacantes.ProspectoNota_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoNota.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", prospectoNota.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Nota", prospectoNota.Nota, SqlDbType.VarChar);

            Models.ProspectoNota resultado = new Models.ProspectoNota();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoNota>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoNota> ProspectoNota_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "Vacantes.ProspectoNota_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoNota> resultado = new List<Models.ProspectoNota>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoNota>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.ProspectoNota Prospecto_EliminarNota(Models.ProspectoNota ProspectoNota)
        {
            const string consulta = "Vacantes.Prospecto_EliminarNota";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", ProspectoNota.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", ProspectoNota.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", ProspectoNota.Prospecto.Id, SqlDbType.Int);


            Models.ProspectoNota resultado = new Models.ProspectoNota();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoNota>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.ProspectoNota Prospecto_Actualizar_nota(Models.ProspectoNota vacanteNota)
        {
            const string consulta = "Vacantes.Prospecto_Actualizar_nota";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacanteNota.Id, SqlDbType.Int);
            b.AddParameter("@Nota", vacanteNota.Nota, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", vacanteNota.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@IdProspecto", vacanteNota.Prospecto.Id, SqlDbType.Int);

            Models.ProspectoNota resultado = new Models.ProspectoNota();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoNota>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
