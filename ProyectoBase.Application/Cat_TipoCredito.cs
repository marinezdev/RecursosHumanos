using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_TipoCredito
    {
        ProyectoBase.Data.Cat_TipoCredito _cat_banco = new Data.Cat_TipoCredito();
        public List<Models.Cat_TipoCredito> Cat_TipoCredito_Selecionar_Listar()
        {
            return _cat_banco.Cat_TipoCredito_Selecionar_Listar();
        }
    }
}
