using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_TipoPrueba
    {
        Data.Cat_TipoPrueba _Cat_TipoPrueba = new Data.Cat_TipoPrueba();
        public List<Models.Cat_TipoPrueba> Cat_TipoPrueba_Seleccionar()
        {
            return _Cat_TipoPrueba.Cat_TipoPrueba_Seleccionar();
        }
    }
}
