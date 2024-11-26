using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PersonasDirecciones
    {
        Data.PersonasDirecciones _personasDirecciones = new Data.PersonasDirecciones();

        public List<Models.PersonasDirecciones> PersonasDirecciones_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasDirecciones.PersonasDirecciones_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasDirecciones PersonasDirecciones_Editar_IdPersona(Models.Personas personas)
        {
            return _personasDirecciones.PersonasDirecciones_Editar_IdPersona(personas);
        }
        public Models.PersonasDirecciones PersonasDirecciones_Actualizar_Direccion(Models.Personas personas)
        {
            return _personasDirecciones.PersonasDirecciones_Actualizar_Direccion(personas);
        }
        
    }
}
