using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Aplicaciones
    {
        Data.Cat_Aplicaciones _Cat_Aplicaciones = new Data.Cat_Aplicaciones();

        public List<Models.Cat_Aplicaciones> Cat_Aplicaciones_Seleccionar()
        {
            return _Cat_Aplicaciones.Cat_Aplicaciones_Seleccionar();
        }

        public Models.Cat_Aplicaciones Cat_Aplicaciones_Agregar(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            return _Cat_Aplicaciones.Cat_Aplicaciones_Agregar(cat_Aplicaciones);
        }
        public Models.Cat_Aplicaciones Cat_Aplicaciones_Seleccionar_Id(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            return _Cat_Aplicaciones.Cat_Aplicaciones_Seleccionar_Id(cat_Aplicaciones);
        }
        public Models.Cat_Aplicaciones Cat_Aplicaciones_Elimnar(Models.Cat_Aplicaciones cat_Aplicaciones)
        {
            return _Cat_Aplicaciones.Cat_Aplicaciones_Elimnar(cat_Aplicaciones);
        }
    }
}
