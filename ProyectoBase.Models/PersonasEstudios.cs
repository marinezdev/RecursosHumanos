using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasEstudios
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdEstudios { get; set; }
        public int IdEstatus { get; set; }
        public int IdArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }
        public string DocumentoURL { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}
