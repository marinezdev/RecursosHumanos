using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasDiplomado
    {
        Data.PersonasDiplomado _personasDiplomado = new Data.PersonasDiplomado();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();

        public Models.PersonasDiplomados PersonasDiplomado_Agregar(Models.PersonasDiplomados personasDiplomado)
        {
            return _personasDiplomado.PersonasDiplomado_Agregar(personasDiplomado);
        }
        public Models.PersonasDiplomados PersonasDiplomado_Eliminar(Models.PersonasDiplomados personasDiplomado)
        {
            return _personasDiplomado.PersonasDiplomado_Eliminar(personasDiplomado);
        }
        public List<Models.PersonasDiplomados> PersonasDiplomado_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasDiplomado.PersonasDiplomado_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasDiplomados PersonasDiplomados_Editar_ActualizarArchivo(Models.PersonasDiplomados personasDiplomados)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            Models.Personas persona = _personas.Personas_Seleccionar_Id(personasDiplomados.Personas);

            if (personasDiplomados.NmArchivo != null)
            {
                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DIPLOMADOS"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DIPLOMADOS");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasDiplomados.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\DIPLOMADOS", personasDiplomados.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }
            return _personasDiplomado.PersonasDiplomados_Editar_ActualizarArchivo(personasDiplomados);
        }
        public Models.PersonasDiplomados PersonasDiplomados_Editar_EliminarArchivo(Models.PersonasDiplomados personasDiplomados)
        {
            return _personasDiplomado.PersonasDiplomados_Editar_EliminarArchivo(personasDiplomados);
        }
        public Models.PersonasDiplomados PersonasDiplomados_Editar_Selecionar_Id(Models.PersonasDiplomados personasDiplomados)
        {
            return _personasDiplomado.PersonasDiplomados_Editar_Selecionar_Id(personasDiplomados);
        }
    }
}
