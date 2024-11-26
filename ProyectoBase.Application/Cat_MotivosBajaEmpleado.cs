using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_MotivosBajaEmpleado
    {
        Data.Cat_MotivosBajaEmpleado _Cat_MotivosBajaEmpleado = new Data.Cat_MotivosBajaEmpleado();
        public List<Models.Cat_MotivosBajaEmpleado> Cat_MotivosBajaEmpleado_Seleccionar()
        {
            return _Cat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();
        }

        public Models.Cat_MotivosBajaEmpleado Cat_MotivosBajaEmpleado_Elimnar(Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado)
        {
            return _Cat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Elimnar(cat_MotivosBajaEmpleado);
        }
        public Models.Cat_MotivosBajaEmpleado MotivosBajaEmpleado_Agregar(Models.Cat_MotivosBajaEmpleado cat_MotivosBajaEmpleado)
        {
            return _Cat_MotivosBajaEmpleado.MotivosBajaEmpleado_Agregar(cat_MotivosBajaEmpleado);
        }
    }
}
