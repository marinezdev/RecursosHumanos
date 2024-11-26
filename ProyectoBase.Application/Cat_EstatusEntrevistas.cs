using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EstatusEntrevistas
    {
        Data.Cat_EstatusEntrevistas _Cat_EstatusEntrevistas = new Data.Cat_EstatusEntrevistas();
        public List<Models.Cat_EstatusEntrevistas> Cat_EstatusEntrevistas_Seleccionar()
        {
            return _Cat_EstatusEntrevistas.Cat_EstatusEntrevistas_Seleccionar();
        }
    }
}
