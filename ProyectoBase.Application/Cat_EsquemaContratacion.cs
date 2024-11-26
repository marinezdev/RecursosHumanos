using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EsquemaContratacion
    {
        Data.Cat_EsquemaContratacion _esquemaContratacion = new Data.Cat_EsquemaContratacion();
        public List<Models.Cat_EsquemaContratacion> Cat_EsquemaContratacion_Seleccionar()
        {
            return _esquemaContratacion.Cat_EsquemaContratacion_Seleccionar();
        }
    }
}
