using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasAplicaciones
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Personas Personas { get; set; }
        public Cat_Aplicaciones Cat_Aplicaciones { get; set; }
    }
}
