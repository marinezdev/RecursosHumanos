using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EstatusProspecto
    {
        Data.Cat_EstatusProspecto _Cat_EstatusProspecto = new Data.Cat_EstatusProspecto();
        public List<Models.Cat_EstatusProspecto> Cat_EstatusProspecto_Seleccionar()
        {
            return _Cat_EstatusProspecto.Cat_EstatusProspecto_Seleccionar();
        }
    }
}
