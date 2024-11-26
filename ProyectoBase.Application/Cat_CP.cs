using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_CP
    {
        Data.Cat_CP _cat_CP = new Data.Cat_CP();
        public List<Models.Cat_CP> Cat_CP_Seleccionar(int Id)
        {
            return _cat_CP.Cat_CP_Seleccionar(Id);
        }
        public List<Models.Direcciones> Cat_CP_Busqueda(string CP)
        {
            List<Models.Direcciones> direcciones = _cat_CP.Cat_CP_Busqueda(CP);
            return direcciones;
        }
    }
}
