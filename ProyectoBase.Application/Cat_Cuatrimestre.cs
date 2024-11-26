using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Cuatrimestre
    {
        Data.Cat_Cuatrimestre _cat_Cuatrimestre = new Data.Cat_Cuatrimestre();
        public List<Models.Cat_Cuatrimestre> Cat_Cuatrimestre_Seleccionar()
        {
            return _cat_Cuatrimestre.Cat_Cuatrimestre_Seleccionar();
        }
    }
}
