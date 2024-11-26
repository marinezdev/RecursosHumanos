using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class PersonaEstudio
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public Cat_Estudios Cat_Estudios { get; set; }
        public Cat_EstatusEstudios Cat_EstatusEstudios { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}
