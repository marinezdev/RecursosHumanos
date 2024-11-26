using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EstatusVacante
    {
        Data.Cat_EstatusVacante _Cat_EstatusVacante = new Data.Cat_EstatusVacante();
        public List<Models.Cat_EstatusVacante> Cat_EstatusVacante_Seleccionar()
        {
            return _Cat_EstatusVacante.Cat_EstatusVacante_Seleccionar();
        }
    }
}
