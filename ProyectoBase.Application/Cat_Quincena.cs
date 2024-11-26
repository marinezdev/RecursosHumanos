using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Quincena
    {
        Data.Cat_Quincena _cat_Quincena = new Data.Cat_Quincena();
        public Models.Cat_Quincena Cat_Quincena_Selecionar_Quincena(Models.Cat_Quincena cat_Quincena)
        {
            return _cat_Quincena.Cat_Quincena_Selecionar_Quincena(cat_Quincena);
        }
    }
}
