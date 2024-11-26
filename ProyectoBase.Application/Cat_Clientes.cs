using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Clientes
    {
        Data.Cat_Clientes _cat_Clientes = new Data.Cat_Clientes();
        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            return _cat_Clientes.Cat_Clientes_Seleccionar_IdEmpresa(empresas);
        }
        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar()
        {
            return _cat_Clientes.Cat_Clientes_Seleccionar();
        }

        public Models.Cat_Clientes Cat_Clientes_Agregar(Models.Cat_Clientes cat_Clientes)
        {
            return _cat_Clientes.Cat_Clientes_Agregar(cat_Clientes);
        }
    }
}
