using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasPsicometrico
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public string Califico { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string Observaciones { get; set; }
    }
}
