using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EstatusEstudios
    {
        ProyectoBase.Data.Cat_EstatusEstudios _cat_estatusestudios= new Data.Cat_EstatusEstudios();
        public List<Models.Cat_EstatusEstudios> Cat_EstatusEstudios_Selecionar_Listar()
        {
            return _cat_estatusestudios.Cat_EstatusEstudios_Selecionar_Listar();
        }

        public Models.Cat_EstatusEstudios Cat_EstatusEstudios_Selecionar_Id(int Id)
        {
            return _cat_estatusestudios.Cat_EstatusEstudios_Selecionar_Id(Id);
        }
    }
}
