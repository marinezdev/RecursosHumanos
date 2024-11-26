using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Almacenamiento
    {
        Data.Cat_Almacenamiento _cat_Almacenamiento = new Data.Cat_Almacenamiento();
        public Models.Cat_Almacenamiento Cat_Almacenamiento_Seleccionar()
        {
            return _cat_Almacenamiento.Cat_Almacenamiento_Seleccionar();
        }
    }
}
