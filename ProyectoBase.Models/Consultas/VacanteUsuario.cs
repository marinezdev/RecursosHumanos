using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class VacanteUsuario
    {
        public Vacante Vacante { get; set; }
        public Personas Personas { get; set; }
        public EMails EMails { get; set; }
    }
}
