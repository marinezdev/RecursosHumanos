using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ProspectoPrueba
    {
        public int Id { get; set; }
        public Prospecto Prospecto { get; set; }
        public Cat_TipoPrueba Cat_TipoPrueba { get; set; }
        public Cat_EstatusPrueba Cat_EstatusPrueba { get; set;}
        public Usuarios Usuarios { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Clave { get; set; }

        public Vacante Vacante { get; set; }
    }
}
