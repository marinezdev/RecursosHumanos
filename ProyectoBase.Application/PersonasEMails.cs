using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PersonasEMails
    {
        Data.PersonasEMails _personasEMails = new Data.PersonasEMails();
        public List<Models.PersonasEMails> PersonasEMails_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasEMails.PersonasEMails_Seleccionar_IdPersona(personas);
        }
    }
}
