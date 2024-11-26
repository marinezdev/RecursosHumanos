using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set; }
        public int systemStatus { get; set; }
    }
}
