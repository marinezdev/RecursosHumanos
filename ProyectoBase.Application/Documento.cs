using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Documento
    {
        Data.Documento _documentos = new Data.Documento();
        public Models.Documento PersonasDocumento_Agregar(Models.Documento  documento)
        {
            return _documentos.PersonasDocumento_Agregar(documento);
        }
        public List<Models.Documento> PersonasDocumento_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _documentos.PersonasDocumento_Seleccionar_IdPersona(personas);
        }
        public List<Models.Documento> PersonasDocumento_Estatus_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _documentos.PersonasDocumento_Estatus_Seleccionar_IdPersona(personas);
        }
        public List<Models.Documento> PersonasDocumento_Documento_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _documentos.PersonasDocumento_Documento_Seleccionar_IdPersona(personas);
        }
        public List<Models.Documento> PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(Models.Personas personas)
        {
            return _documentos.PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(personas);
        }
        public Models.Documento PersonasDocumento_Seleccionar_Id(Models.Documento documento)
        {
            return _documentos.PersonasDocumento_Seleccionar_Id(documento);
        }
        public List<Models.Documento> PersonasDocumento_Seleccionar_Editar_IdPersona(Models.Personas personas)
        {
            return _documentos.PersonasDocumento_Seleccionar_Editar_IdPersona(personas);
        }
        public Models.Documento PersonasDocumento_Eliminar(Models.Personas personas)
        {
            return _documentos.PersonasDocumento_Eliminar(personas);
        }
    }
}
