using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Empresas
    {
        Data.Empresas _empresas = new Data.Empresas();
        public List<Models.Empresas> Empresas_Seleccionar()
        {
            return _empresas.Empresas_Seleccionar();
        }

        public Models.Empresas Empresas_Agregar(Models.Empresas empresas)
        {
            return _empresas.Empresas_Agregar(empresas);
        }
    }
}
