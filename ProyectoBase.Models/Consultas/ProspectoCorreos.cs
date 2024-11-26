using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class ProspectoCorreos
    {
        public Vacante Vacante { get; set; }    
        public Prospecto Prospecto { get; set; }
        public ProspectoCorreo ProspectoCorreo { get; set; } 
    }
}
