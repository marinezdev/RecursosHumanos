using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_ProyectoServicios
    {
        Data.Cat_ProyectoServicios _cat_ProyectoServicios = new Data.Cat_ProyectoServicios();
        public List<Models.Cat_ProyectoServicios> Cat_ProyectoServicios_Seleccionar(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _cat_ProyectoServicios.Cat_ProyectoServicios_Seleccionar(cat_ProyectoServicios);
        }

        public Models.Cat_ProyectoServicios Cat_ProyectoServicios_Agregar(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _cat_ProyectoServicios.Cat_ProyectoServicios_Agregar(cat_ProyectoServicios);
        }

        public List<Models.Cat_ProyectoServicios> Cat_ProyectoServicios_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _cat_ProyectoServicios.Cat_ProyectoServicios_Seleccionar_IdCliente(cat_Clientes);
        }
    }
}
