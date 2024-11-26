using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Personas
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public PersonasDetalle PersonasDetalle { get; set; }
        public PersonasExperiencia PersonasExperiencia { get; set; }
        public PersonasDirecciones PersonasDirecciones { get; set; }
        public PersonasExamen PersonasExamen { get; set; }
        public PersonasPsicometrico PersonasPsicometrico { get; set; }
        public PersonasFolio PersonasFolio { get; set; }
        public PersonasClienteDirecciones PersonasClienteDirecciones { get; set; }
        public Empleados Empleados { get; set; }
    }
}
