using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ArchivoQuincena
    {
        public int Id { get; set; }
        public Cat_Quincena Cat_Quincena { get; set; }
        public Usuarios Usuarios { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }
        public int Year { get; set; }
        public bool Resgistro { get; set; } 
        
    }
}
