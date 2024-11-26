using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ArchivoProspecto
    {
        public int Id { get; set; }
        public Vacante Vacante { get; set; }
        public Usuarios Usuarios { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }


        public int Registrados { get; set; }
        public int Noregistrados { get; set; }
    }
}
