using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Certificaciones
    {
        ProyectoBase.Data.Cat_Certificaciones _cat_Certificaciones = new Data.Cat_Certificaciones();
        public List<Models.Cat_Certificaciones> Cat_Certificaciones_Seleccionar()
        {
            return _cat_Certificaciones.Cat_Certificaciones_Seleccionar();
        }

        public Models.Cat_Certificaciones Cat_Diplomados_Agregar(Models.Cat_Certificaciones cat_Certificaciones)
        {
            return _cat_Certificaciones.Cat_Certificaciones_Agregar(cat_Certificaciones);
        }
    }
}
