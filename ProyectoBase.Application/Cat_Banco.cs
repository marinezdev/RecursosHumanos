using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Banco
    {
        ProyectoBase.Data.Cat_Banco _cat_banco = new Data.Cat_Banco();
        public List<Models.Cat_Banco> Cat_Banco_Selecionar_Listar()
        {
            return _cat_banco.Cat_Banco_Selecionar_Listar();
        }

        public Models.Cat_Banco Cat_Banco_Agregar(Models.Cat_Banco cat_Banco)
        {
            return _cat_banco.Cat_Banco_Agregar(cat_Banco);
        }
    }
}