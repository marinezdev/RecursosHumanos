using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PersonasEMails
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.PersonasEMails> PersonasEMails_Seleccionar_IdPersona(Models.Personas personas)
        {
            b.ExecuteCommandSP("PersonasEMails_Seleccionar_IdPersona");
            b.AddParameter("@IdPersona", personas.Id, SqlDbType.Int);
            List<Models.PersonasEMails> resultado = new List<Models.PersonasEMails>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.PersonasEMails item = new Models.PersonasEMails()
                {
                    EMail = reader["EMail"].ToString(),
                    Tipo = reader["Tipo"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
