using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PersonasAplicaciones
    {
        Data.PersonasAplicaciones _PersonasAplicaciones = new Data.PersonasAplicaciones();
        public Models.PersonasAplicaciones PersonasAplicaciones_Agregar(Models.PersonasAplicaciones personasAplicaciones)
        {
            return _PersonasAplicaciones.PersonasAplicaciones_Agregar(personasAplicaciones);
        }
        public List<Models.PersonasAplicaciones> PersonasAplicaciones_Seleccionar_IdPersona(Models.Personas Persona)
        {
            return _PersonasAplicaciones.PersonasAplicaciones_Seleccionar_IdPersona(Persona);
        }
        public Models.PersonasAplicaciones PersonasAplicaciones_Eliminar(Models.PersonasAplicaciones personasAplicaciones)
        {
            return _PersonasAplicaciones.PersonasAplicaciones_Eliminar(personasAplicaciones);
        }
    }
}
