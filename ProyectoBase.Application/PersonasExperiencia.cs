using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PersonasExperiencia
    {
        Data.PersonasExperiencia _personasExperiencia = new Data.PersonasExperiencia();
        public List<Models.PersonasExperiencia> PersonasExperiencia_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasExperiencia.PersonasExperiencia_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasExperiencia PersonasExperiencia_Editar_IdPersona(Models.Personas personas)
        {
            return _personasExperiencia.PersonasExperiencia_Editar_IdPersona(personas);
        }
    }
}
