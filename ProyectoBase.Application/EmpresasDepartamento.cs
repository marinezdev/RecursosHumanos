using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class EmpresasDepartamento
    {
        Data.EmpresasDepartamento _empresasDepartamento = new Data.EmpresasDepartamento();
        public List<Models.EmpresasDepartamento> EmpresasDepartamento_Seleccionar(Models.Empresas empresas)
        {
            return _empresasDepartamento.EmpresasDepartamento_Seleccionar(empresas);
        }

        public Models.EmpresasDepartamento EmpresasDepartamento_Agregar(Models.EmpresasDepartamento empresasDepartamento)
        {
            return _empresasDepartamento.EmpresasDepartamento_Agregar(empresasDepartamento);
        }

        public List<Models.EmpresasDepartamento> EmpresasDepartamento_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            return _empresasDepartamento.EmpresasDepartamento_Seleccionar_IdEmpresa(empresas);
        }
    }
}
