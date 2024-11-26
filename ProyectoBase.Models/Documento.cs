using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public int IdEstatusDocumento { get; set; }
        public string EstatusDocumento { get; set; }
        public int Total { get; set; }
        public int Porcentaje { get; set; }
        public string Nombre { get; set; }
        public string FechaRegstro { get; set; }
        public string FechaEntrega { get; set; }
        public string FechaVigencia { get; set; }

        public List<Models.Cat_EstatusDocumento> CatEstatusDocumento { get; set; }

        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        public string Version { get; set; }
        public string Descripcion { get; set; }

        public int IdArchivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string DocumentoURL { get; set; }
    }
}
