using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Entrevistas
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Entrevisto { get; set; }
        public string FechaEntrevista { get; set; }
        public string Observaciones { get; set; }
    }
}
