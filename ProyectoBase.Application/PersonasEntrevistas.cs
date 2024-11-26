using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PersonasEntrevistas
    {
        Data.PersonasEntrevistas _personasEntrevistas = new Data.PersonasEntrevistas();
        public Models.PersonasEntrevistas PersonasEntrevistas_Agregar(Models.PersonasEntrevistas personasEntrevistas)
        {
            return _personasEntrevistas.PersonasEntrevistas_Agregar(personasEntrevistas);
        }
        public List<Models.PersonasEntrevistas> PersonasEntrevistas_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasEntrevistas.PersonasEntrevistas_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasEntrevistas PersonasEntrevistas_Eliminar(Models.PersonasEntrevistas personasEntrevistas)
        {
            return _personasEntrevistas.PersonasEntrevistas_Eliminar(personasEntrevistas);
        }
    }
}
