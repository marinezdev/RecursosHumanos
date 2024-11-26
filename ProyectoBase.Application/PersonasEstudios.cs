using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasEstudios
    {
        Data.PersonasEstudios _personasEstudios = new Data.PersonasEstudios();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();

        public Models.Consultas.PersonaEstudio PersonasEstudios_Agregar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            return _personasEstudios.PersonasEstudios_Agregar(personaEstudio);
        }
        public List<Models.Consultas.PersonaEstudio> PersonasEstudios_Seleccionar_Editar_IdPersona(Models.Personas personas)
        {
            return _personasEstudios.PersonasEstudios_Seleccionar_Editar_IdPersona(personas);
        }
        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_Eliminar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            return _personasEstudios.PersonasEstudios_Editar_Eliminar(personaEstudio);
        }
        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_ActualizarArchivo(Models.Consultas.PersonaEstudio personaEstudio)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            Models.Personas personas = _personas.Personas_Seleccionar_Id(personaEstudio.Personas);

            if (personaEstudio.NmArchivo != null)
            {
                if (!Directory.Exists(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\ESTUDIOS"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\ESTUDIOS");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personaEstudio.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\ESTUDIOS", personaEstudio.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }

            return _personasEstudios.PersonasEstudios_Editar_ActualizarArchivo(personaEstudio);
        }
        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_EliminarArchivo(Models.Consultas.PersonaEstudio personaEstudio)
        {
            return _personasEstudios.PersonasEstudios_Editar_EliminarArchivo(personaEstudio);
        }
        public Models.Consultas.PersonaEstudio PersonasEstudios_Editar_Selecionar(Models.Consultas.PersonaEstudio personaEstudio)
        {
            return _personasEstudios.PersonasEstudios_Editar_Selecionar(personaEstudio);
        }
    }
}
