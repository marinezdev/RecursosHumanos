using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Diplomados
    {
        ProyectoBase.Data.Cat_Diplomados _cat_Diplomados = new Data.Cat_Diplomados();
        public List<Models.Cat_Diplomados> Cat_Diplomados_Seleccionar()
        {
            return _cat_Diplomados.Cat_Diplomados_Seleccionar();
        }

        public Models.Cat_Diplomados Cat_Diplomados_Agregar(Models.Cat_Diplomados cat_Diplomados)
        {
            return _cat_Diplomados.Cat_Diplomados_Agregar(cat_Diplomados);
        }
    }
}
