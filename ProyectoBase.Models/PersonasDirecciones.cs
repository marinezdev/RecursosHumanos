using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasDirecciones
    {
        public int Id { get; set; }
        public int IdColonia { get; set; }
        public string Estado { get; set; }
        public string Poblacion { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Calle { get; set; }
        public string NumExterior { get; set; }
        public string NumInteriror { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }
    }
}
