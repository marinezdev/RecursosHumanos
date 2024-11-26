using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasDiplomados
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public Cat_Diplomados Cat_Diplomados { get; set; }
        public DateTime FechaTermino { get; set; }
        public int Aprobado { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }
    }
}
