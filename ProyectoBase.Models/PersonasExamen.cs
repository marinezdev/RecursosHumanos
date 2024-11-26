using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasExamen
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public Cat_TipoExamen Cat_TipoExamen { get; set; }
        public string Calificacion { get; set; }
        public string Califico { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string Observaciones { get; set; }
    }
}
