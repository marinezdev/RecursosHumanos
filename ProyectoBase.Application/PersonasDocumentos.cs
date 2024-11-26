using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class PersonasDocumentos
    {
        Data.PersonasDocumentos _personasDocumentos = new Data.PersonasDocumentos();
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        Data.Personas _personas = new Data.Personas();

        public Models.PersonasDocumentos PersonasDocumento_Agregar(Models.PersonasDocumentos personasDocumentos)
        {
            return _personasDocumentos.PersonasDocumento_Agregar(personasDocumentos);
        }
        public List<Models.PersonasDocumentos> PersonasDocumento_Seleccionar_Editar_IdPersona(Models.Personas personas)
        {
            return _personasDocumentos.PersonasDocumento_Seleccionar_Editar_IdPersona(personas);
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_Eliminar(Models.PersonasDocumentos personasDocumentos)
        {
            return _personasDocumentos.PersonasDocumentos_Editar_Eliminar(personasDocumentos);
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_ActualizarArchivo(Models.PersonasDocumentos personasDocumentos)
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\DocumentosTemporales\\";
            string folderPath = _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar().Ruta;
            Models.Cat_EstatusDocumento cat_EstatusDocumento = new Models.Cat_EstatusDocumento();
            Models.Personas personas = _personas.Personas_Seleccionar_Id(personasDocumentos.Personas);

            cat_EstatusDocumento.Id = 3;
            if (personasDocumentos.DocumentoVersiones.NmArchivo != null)
            {
                cat_EstatusDocumento.Id = 1;

                if (!Directory.Exists(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS"))
                {
                    Directory.CreateDirectory(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS");
                }
                string sourceFileExamen = System.IO.Path.Combine(DirectorioUsuario, personasDocumentos.DocumentoVersiones.NmArchivo);
                string destFileExamen = System.IO.Path.Combine(folderPath + @"\" + personas.PersonasFolio.FolioCompuesto + @"\DOCUMENTOS", personasDocumentos.DocumentoVersiones.NmArchivo);
                System.IO.File.Copy(sourceFileExamen, destFileExamen, true);
            }
            personasDocumentos.Cat_EstatusDocumento = cat_EstatusDocumento;
            return _personasDocumentos.PersonasDocumentos_Editar_ActualizarArchivo(personasDocumentos);
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_EliminarArchivo(Models.PersonasDocumentos personasDocumentos)
        {
            return _personasDocumentos.PersonasDocumentos_Editar_EliminarArchivo(personasDocumentos);
        }
        public Models.PersonasDocumentos PersonasDocumentos_Editar_Selecionar(Models.PersonasDocumentos personasDocumentos)
        {
            return _personasDocumentos.PersonasDocumentos_Editar_Selecionar(personasDocumentos);
        }
        public List<Models.Consultas.PersonasDocumento_PorcentajeEstatus> PersonasDocumento_Estatus_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasDocumentos.PersonasDocumento_Estatus_Seleccionar_IdPersona(personas);
        }
        public List<Models.PersonasDocumentos> PersonasDocumento_Documento_Seleccionar_IdPersona(Models.Personas personas)
        {
            return _personasDocumentos.PersonasDocumento_Documento_Seleccionar_IdPersona(personas);
        }
        public List<Models.PersonasDocumentos> PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(Models.Personas personas)
        {
            return _personasDocumentos.PersonasDocumento_Documento_Seleccionar_IdPersonaPDF(personas);
        }
        public Models.PersonasDocumentos PersonasDocumento_Seleccionar_Id(Models.PersonasDocumentos personasDocumentos)
        {
            return _personasDocumentos.PersonasDocumento_Seleccionar_Id(personasDocumentos);
        }
        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje()
        {
            return _personasDocumentos.PersonasDocumento_Procentaje();
        }
        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje_IdEmpresa(Models.Empresas empresas)
        {
            return _personasDocumentos.PersonasDocumento_Procentaje_IdEmpresa(empresas);
        }
        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje()
        {
            return _personasDocumentos.PersonasDocumento_Documento_Procentaje();
        }
        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje_IdEmpresa(Models.Empresas empresas)
        {
            return _personasDocumentos.PersonasDocumento_Documento_Procentaje_IdEmpresa(empresas);
        }
        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes)
        {
            return _personasDocumentos.PersonasDocumento_Procentaje_Cliente(cat_Clientes);
        }
        public Models.Consultas.PersonasDocumento_Procentaje PersonasDocumento_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _personasDocumentos.PersonasDocumento_Procentaje_Cliente_ProyectoServicio(cat_ProyectoServicios);
        }
        public List<Models.Consultas.PersonasDocumento_Clientes> PersonasDocumento_Clientes_IdEmpresa(Models.Empresas empresas)
        {
            return _personasDocumentos.PersonasDocumento_Clientes_IdEmpresa(empresas);
        }
        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes)
        {
            return _personasDocumentos.PersonasDocumento_Documento_Procentaje_Cliente(cat_Clientes);
        }

        public List<Models.Consultas.PersonasDocumento_Procentaje> PersonasDocumento_Documento_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _personasDocumentos.PersonasDocumento_Documento_Procentaje_Cliente_ProyectoServicio(cat_ProyectoServicios);
        }
    }
}

