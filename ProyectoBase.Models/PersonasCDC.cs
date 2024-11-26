using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasCDC
    {
        public List<Models.PersonasCursos> PersonasCursos { get; set; }
        public List<Models.PersonasDiplomados> PersonasDiplomados { get; set; }
        public List<Models.PersonasCertificacion> PersonasCertificaciones { get; set; }

        //public string Tipo { get; set; }
        //public string Nombre { get; set; }
        //public string FechaTermino { get; set; }
        //public int Acreditado { get; set; }
        //public int Id { get; set; }
        //public int IdTipo { get; set; }
        //public int IdPersona { get; set; }
    }
}
