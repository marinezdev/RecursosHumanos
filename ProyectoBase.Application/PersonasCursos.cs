using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasCursos
    {
        Data.PersonasCursos _personasCursos = new Data.PersonasCursos();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();
        public Models.PersonasCursos PersonasCursos_Agregar(Models.PersonasCursos personasCursos)
        {
            return _personasCursos.PersonasCursos_Agregar(personasCursos);
        }
        public Models.PersonasCursos PersonasCursos_Eliminar(Models.PersonasCursos personasCursos)
        {
            return _personasCursos.PersonasCursos_Eliminar(personasCursos);
        }
        public List<Models.PersonasCursos> PersonasCursos_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasCursos.PersonasCursos_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasCursos PersonasCursos_Editar_ActualizarArchivo(Models.PersonasCursos personasCursos)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            Models.Personas persona = _personas.Personas_Seleccionar_Id(personasCursos.Personas);

            if (personasCursos.NmArchivo != null)
            {
                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CURSOS"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CURSOS");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasCursos.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CURSOS", personasCursos.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }
            return _personasCursos.PersonasCursos_Editar_ActualizarArchivo(personasCursos);
        }
        public Models.PersonasCursos PersonasCursos_Editar_EliminarArchivo(Models.PersonasCursos personasCursos)
        {
            return _personasCursos.PersonasCursos_Editar_EliminarArchivo(personasCursos);
        }
        public Models.PersonasCursos PersonasCursos_Editar_Selecionar_Id(Models.PersonasCursos personasCursos)
        {
            return _personasCursos.PersonasCursos_Editar_Selecionar_Id(personasCursos);
        }
    }
}
