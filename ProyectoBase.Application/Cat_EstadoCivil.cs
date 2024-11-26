using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EstadoCivil
    {
        ProyectoBase.Data.Cat_EstadoCivil _cat_banco = new Data.Cat_EstadoCivil();
        public List<Models.Cat_EstadoCivil> Cat_EstadoCivil_Selecionar_Listar()
        {
            return _cat_banco.Cat_EstadoCivil_Selecionar_Listar();
        }
    }
}
