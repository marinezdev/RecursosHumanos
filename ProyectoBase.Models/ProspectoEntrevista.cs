using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ProspectoEntrevista
    {
        public int Id { get; set; }
        public Prospecto Prospecto { get; set; }
        public Usuarios Usuarios { get; set; }  
        public Cat_EstatusEntrevistas Cat_EstatusEntrevistas { get; set; }
        //public string Entrevisto { get; set; }
        public DateTime FechaEntrevista { get; set; }   
        public string Observaciones { get; set; }
        public int Responsable { get; set; }
        public int IdResponsble { get; set; }
        public VacanteResponsable VacanteResponsable { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EntrevistaAceptada { get; set; }
        public int Notificar { get; set; }

        public string Clave { get; set; }
        public  Vacante Vacante { get; set; }
    }
}
