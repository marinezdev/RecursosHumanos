using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Prueba
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Califico { get; set; }
        public string FechaAplicacion { get; set; }
        public string Observaciones { get; set; }
        public int IdArchivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string DocumentoURL { get; set; }
    }
}
