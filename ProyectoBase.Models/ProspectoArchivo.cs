using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public  class ProspectoArchivo
    {
        public int Id { get; set; }
        public Usuarios Usuarios { get; set; }
        public Prospecto Prospecto { get; set; }
        public Cat_TipoArchivo Cat_TipoArchivo { get; set; }
        public string NmARchivo { get; set; }
        public string NmOriginal { get; set; }
        public string Extencion { get; set; }
        public int Referencia { get; set; }
    }
}
