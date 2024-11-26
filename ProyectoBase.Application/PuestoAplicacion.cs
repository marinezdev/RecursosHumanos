using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PuestoAplicacion
    {
        Data.PuestoAplicacion _PuestoAplicacion = new Data.PuestoAplicacion();
        public List<Models.PuestoAplicacion> PuestoAplicacion_Seleccionar_IdPuesto(Models.EmpresaPuestos empresaPuestos)
        {
            return _PuestoAplicacion.PuestoAplicacion_Seleccionar_IdPuesto(empresaPuestos);
        }

        public Models.PuestoAplicacion PuestoAplicacion_Agregar(Models.PuestoAplicacion puestoAplicacion)
        {
            return _PuestoAplicacion.PuestoAplicacion_Agregar(puestoAplicacion);
        }

        public Models.PuestoAplicacion PuestoAplicacion_Elimnar(Models.PuestoAplicacion puestoAplicacion)
        {
            return _PuestoAplicacion.PuestoAplicacion_Elimnar(puestoAplicacion);
        }
    }
}
