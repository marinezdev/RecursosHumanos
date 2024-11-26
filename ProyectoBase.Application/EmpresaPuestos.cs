using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class EmpresaPuestos
    {
        Data.EmpresaPuestos _empresaPuestos = new Data.EmpresaPuestos();

        public List<Models.EmpresaPuestos> EmpresaPuestos_Seleccionar(Models.EmpresasDepartamento empresasDepartamento)
        {
            return _empresaPuestos.EmpresaPuestos_Seleccionar(empresasDepartamento);
        }

        public Models.EmpresaPuestos EmpresaPuestos_Agregar(Models.EmpresaPuestos empresaPuestos)
        {
            return _empresaPuestos.EmpresaPuestos_Agregar(empresaPuestos);
        }

        public List<Models.EmpresaPuestos> EmpresaPuestos_Seleccionar_IdDepartamento(Models.EmpresasDepartamento empresasDepartamento)
        {
            return _empresaPuestos.EmpresaPuestos_Seleccionar_IdDepartamento(empresasDepartamento);
        }
    }
}
