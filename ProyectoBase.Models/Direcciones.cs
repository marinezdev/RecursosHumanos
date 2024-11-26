using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Direcciones
    {
        public int IdUsuario { get; set; }
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdPoblacion { get; set; }
        public string Poblacion { get; set; }
        public int IdColonia { get; set; }
        public string Colonia { get; set; }
        public int IdCP { get; set; }
        public string CP { get; set; }
    }
}
