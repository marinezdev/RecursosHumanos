using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasPsicometrico
    {
        Data.PersonasPsicometrico _personasPsicometrico = new Data.PersonasPsicometrico();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();

        public Models.PersonasPsicometrico PersonasPsicometrico_Agregar(Models.PersonasPsicometrico personasPsicometrico)
        {
            return _personasPsicometrico.PersonasPsicometrico_Agregar(personasPsicometrico);
        }

        public Models.PersonasPsicometrico PersonasPsicometrico_Editar_IdPersona(Models.Personas personas)
        {
            return _personasPsicometrico.PersonasPsicometrico_Editar_IdPersona(personas);
        }

        public Models.PersonasPsicometrico PersonasPsicometrico_Eliminar(Models.PersonasPsicometrico personasPsicometrico)
        {
            return _personasPsicometrico.PersonasPsicometrico_Eliminar(personasPsicometrico);
        }

        public Models.PersonasPsicometrico PersonasPsicometrico_Actualizar(Models.PersonasPsicometrico personasPsicometrico)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            Models.Personas personas = _personas.Personas_Seleccionar_Id(personasPsicometrico.Personas);


            if (personasPsicometrico.NmArchivo != null)
            {
                // CREAMOS CARPTA CON FOLIO DEL EMPLEADO
                if (!Directory.Exists(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasPsicometrico.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\PRUEBA_PSICOMETRICO", personasPsicometrico.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }
            return _personasPsicometrico.PersonasPsicometrico_Actualizar(personasPsicometrico);
        }

        public Models.PersonasPsicometrico PersonasPsicometrico_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasPsicometrico.PersonasPsicometrico_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasPsicometrico PersonasPsicometrico_Seleccionar_Id(Models.PersonasPsicometrico personasPsicometrico)
        {
            return _personasPsicometrico.PersonasPsicometrico_Seleccionar_Id(personasPsicometrico);
        }
    }
}
