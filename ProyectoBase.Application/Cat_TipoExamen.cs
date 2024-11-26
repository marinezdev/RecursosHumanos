using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_TipoExamen
    {
        Data.Cat_TipoExamen _tipoExamen = new Data.Cat_TipoExamen();
        public List<Models.Cat_TipoExamen> Cat_TipoExamen_Seleccionar()
        {
            return _tipoExamen.Cat_TipoExamen_Seleccionar();
        }

        public Models.Cat_TipoExamen Cat_TipoExamen_Agregar(Models.Cat_TipoExamen cat_TipoExamen)
        {
            return _tipoExamen.Cat_TipoExamen_Agregar(cat_TipoExamen);
        }
    }
}
