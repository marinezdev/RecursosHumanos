using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasCertificaciones
    {
        Data.PersonasCertificaciones _ersonasCertificaciones = new Data.PersonasCertificaciones();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();

        public Models.PersonasCertificacion PersonasCertificacion_Agregar(Models.PersonasCertificacion personasCertificaciones)
        {
            return _ersonasCertificaciones.PersonasCertificacion_Agregar(personasCertificaciones);
        }
        public Models.PersonasCertificacion PersonasCertificacion_Eliminar(Models.PersonasCertificacion personasCertificaciones)
        {
            return _ersonasCertificaciones.PersonasCertificacion_Eliminar(personasCertificaciones);
        }
        public List<Models.PersonasCertificacion> PersonasCertificacion_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _ersonasCertificaciones.PersonasCertificacion_Seleccionar_IdPersona(personas);
        }
        public Models.PersonasCertificacion PersonasCertificacion_Editar_ActualizarArchivo(Models.PersonasCertificacion personasCertificaciones)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;

            Models.Personas persona = _personas.Personas_Seleccionar_Id(personasCertificaciones.Personas);

            if (personasCertificaciones.NmArchivo != null)
            {
                if (!Directory.Exists(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CERTIFICACIONES"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CERTIFICACIONES");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasCertificaciones.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + persona.PersonasFolio.FolioCompuesto + @"\CERTIFICACIONES", personasCertificaciones.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }

            return _ersonasCertificaciones.PersonasCertificacion_Editar_ActualizarArchivo(personasCertificaciones);
        }
        public Models.PersonasCertificacion PersonasCertificacion_Editar_EliminarArchivo(Models.PersonasCertificacion personasCertificaciones)
        {
            return _ersonasCertificaciones.PersonasCertificacion_Editar_EliminarArchivo(personasCertificaciones);
        }
        public Models.PersonasCertificacion PersonasCertificacion_Editar_Selecionar_Id(Models.PersonasCertificacion personasCertificaciones)
        {
            return _ersonasCertificaciones.PersonasCertificacion_Editar_Selecionar_Id(personasCertificaciones);
        }
    }
}
