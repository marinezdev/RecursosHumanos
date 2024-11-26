using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class DocumentoVersiones
    {
        //public int IdArchivo { get; set; }
        public int IdUsuario { get; set; }
        public string Version { get; set; }
        public string Descripcion { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
    }
}
