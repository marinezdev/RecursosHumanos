using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Entrevistas
    {
        Data.Entrevistas _entrevistas = new Data.Entrevistas();
        public Models.Entrevistas PersonasEntrevistas_Agregar(Models.Entrevistas entrevistas)
        {
            return _entrevistas.PersonasEntrevistas_Agregar(entrevistas);
        }

        public Models.Entrevistas PersonasEntrevistas_Eliminar(Models.Entrevistas entrevistas)
        {
            return _entrevistas.PersonasEntrevistas_Eliminar(entrevistas);
        }

        public List<Models.Entrevistas> PersonasEntrevistas_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _entrevistas.PersonasEntrevistas_Seleccionar_IdPersona(personas);
        }
    }
}
