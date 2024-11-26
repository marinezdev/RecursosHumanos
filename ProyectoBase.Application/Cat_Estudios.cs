using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Estudios
    {
        ProyectoBase.Data.Cat_Estudios _cat_estudios = new Data.Cat_Estudios();
        public List<Models.Cat_Estudios> Cat_Estudios_Selecionar_Listar()
        {
            return _cat_estudios.Cat_Estudios_Selecionar_Listar();
        }
        public Models.Cat_Estudios Cat_Estudios_Selecionar_Id(int Id)
        {
            return _cat_estudios.Cat_Estudios_Selecionar_Id(Id);
        }
    }
}
