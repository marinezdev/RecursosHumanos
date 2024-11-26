using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasEntrevistas
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public string Entrevisto { get; set; }
        public DateTime FechaEntrevista { get; set; }
        public string Observaciones { get; set; }
        public int EntrevistaAceptada { get; set; }
    }
}
