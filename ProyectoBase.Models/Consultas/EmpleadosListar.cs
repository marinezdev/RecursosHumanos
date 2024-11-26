using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class EmpleadosListar
    {
        public Personas Personas { get; set; }
        public PersonasDetalle PersonasDetalle { get; set; }
        public PersonasFolio PersonasFolio { get; set; }
    }
}
