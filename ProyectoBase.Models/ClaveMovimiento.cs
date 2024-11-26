using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ClaveMovimiento
    {
        public int Id { get; set; }
        public Usuarios Usuarios { get; set; }
        public string Clave { get; set; }
        public string Movimiento { get; set; }
        public string Observaciones { get; set; }
    }
}
