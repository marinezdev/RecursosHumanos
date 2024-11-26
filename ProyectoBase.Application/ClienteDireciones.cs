using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ClienteDireciones
    {
        Data.ClienteDireciones _ClienteDireciones = new Data.ClienteDireciones();
        public Models.ClienteDireciones ClienteDirecciones_Agregar(Models.ClienteDireciones clienteDireciones)
        {
            return _ClienteDireciones.ClienteDirecciones_Agregar(clienteDireciones);
        }

        public List<Models.ClienteDireciones> ClienteDirecciones_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _ClienteDireciones.ClienteDirecciones_Seleccionar_IdCliente(cat_Clientes);
        }
    }
}
