using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasExamen
    {
        Data.PersonasExamen _personasExamen = new Data.PersonasExamen();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();

        public Models.PersonasExamen PersonasExamen_Agregar(Models.PersonasExamen personasExamen)
        {
            return _personasExamen.PersonasExamen_Agregar(personasExamen);
        }
        public Models.PersonasExamen PersonasExamen_Editar_IdPersona(Models.Personas personas)
        {
            return _personasExamen.PersonasExamen_Editar_IdPersona(personas);
        }
        public Models.PersonasExamen PersonasExamen_Eliminar(Models.PersonasExamen personasExamen)
        {
            return _personasExamen.PersonasExamen_Eliminar(personasExamen);
        }
        public Models.PersonasExamen PersonasExamen_Actualizar(Models.PersonasExamen personasExamen)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            Models.Personas personas = _personas.Personas_Seleccionar_Id(personasExamen.Personas);

            if (personasExamen.NmArchivo != null)
            {
                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                if (!Directory.Exists(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\EXAMEN"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\EXAMEN");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasExamen.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\EXAMEN", personasExamen.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }

            return _personasExamen.PersonasExamen_Actualizar(personasExamen);
        }
        public Models.PersonasExamen PersonasExamen_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasExamen.PersonasExamen_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasExamen PersonasExamen_Seleccionar_Id(Models.PersonasExamen personasExamen)
        {
            return _personasExamen.PersonasExamen_Seleccionar_Id(personasExamen);
        }
    }
}
