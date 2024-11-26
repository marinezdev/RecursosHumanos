using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class EmpleadoBaja
    {
        public Personas Personas { get; set; }
        public List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleados { get; set; }
    }
}
