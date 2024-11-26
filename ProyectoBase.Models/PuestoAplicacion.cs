using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PuestoAplicacion
    {
        public int Id { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set; }
        public Cat_Aplicaciones Cat_Aplicaciones { get; set; }
    }
}
