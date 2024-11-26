using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasCursos
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public Cat_Cursos Cat_Cursos { get; set; }
        public DateTime FechaTermino { get; set; }
        public int Acreditado { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }
    }
}
