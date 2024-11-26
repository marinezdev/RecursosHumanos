using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class Personas
    {
        Data.Personas _personas = new Data.Personas();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        public Models.Personas Personas_Nuevo_Empleado(Models.Personas personas)
        {
            return _personas.Personas_Nuevo_Empleado(personas);
        }

        public Models.Personas Personas_Seleccionar_Id(Models.Personas personas)
        {
            return _personas.Personas_Seleccionar_Id(personas);
        }

        public Models.Personas Empleados_ConsultaCURP(Models.Personas personas)
        {
            return _personas.Empleados_ConsultaCURP(personas);
        }

        public Models.Personas Personas_Editar_Seleccionar_Id(Models.Personas personas)
        {
            return _personas.Personas_Editar_Seleccionar_Id(personas);
        }
        public Models.Personas Personas_Actualizar_InformacionBasica(Models.Personas personas)
        {
            return _personas.Personas_Actualizar_InformacionBasica(personas);
        }

        public Models.Personas PersonasDetalle_Actualizar_IdPersona(Models.Personas personas)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;
            Models.Personas DTpersonas = _personas.Personas_Seleccionar_Id(personas);

            if (!Directory.Exists(folderPath + @"\" + DTpersonas.PersonasFolio.FolioCompuesto + @"\FOTO"))
            {
                Directory.CreateDirectory(folderPath + @"\" + DTpersonas.PersonasFolio.FolioCompuesto + @"\FOTOS");
            }
            string sourceFile = System.IO.Path.Combine(DirectorioUsuario, personas.PersonasDetalle.NmArchivo);
            string destFile = System.IO.Path.Combine(folderPath + @"\" + DTpersonas.PersonasFolio.FolioCompuesto + @"\FOTOS", personas.PersonasDetalle.NmArchivo);

            System.IO.File.Copy(sourceFile, destFile, true);

            return _personas.PersonasDetalle_Actualizar_IdPersona(personas);
        }
        
        public Models.Personas Empleados_Actualizar_PuestoExperiencia(Models.Personas personas)
        {
            return _personas.Empleados_Actualizar_PuestoExperiencia(personas);
        }

    }
}
