using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class EmpleadosMotivosBaja
    {
        Data.EmpleadosMotivosBaja _EmpleadosMotivosBaja = new Data.EmpleadosMotivosBaja();
        public Models.EmpleadosMotivosBaja EmpleadosMotivosBaja_Agregar(Models.Personas personas, Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado)
        {
            return _EmpleadosMotivosBaja.EmpleadosMotivosBaja_Agregar(personas, cat_MotivosBajaEmpleado);
        }
    }
}
