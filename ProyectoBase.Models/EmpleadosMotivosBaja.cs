using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class EmpleadosMotivosBaja
    {
        public int Id { get; set; }
        public Empleados Empleados { get; set; }
        public Cat_MotivosBajaEmpleado Cat_MotivosBajaEmpleado { get; set; }
    }
}
