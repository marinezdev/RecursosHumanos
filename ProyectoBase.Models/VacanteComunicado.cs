using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class VacanteComunicado
    {
        public int Id { get; set; }
        public Vacante Vacante { get; set; }
        public Usuarios Usuarios { get; set; }
        public string Titulo { get; set; }
        public string Observaciones { get; set; }


        public string Clave { get; set; }
    }
}
