using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_FuenteReclutamiento
    {
        Data.Cat_FuenteReclutamiento _fuenteReclutamiento = new Data.Cat_FuenteReclutamiento();

        public List<Models.Cat_FuenteReclutamiento> Cat_FuenteReclutamiento_Seleccionar()
        {
            return _fuenteReclutamiento.Cat_FuenteReclutamiento_Seleccionar();
        }
    }
}
