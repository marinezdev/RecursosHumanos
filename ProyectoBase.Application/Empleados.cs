using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Empleados
    {
        Data.Empleados _empleados = new Data.Empleados();
        public List<Models.Consultas.Empleados> Empleados_Listar()
        {
            return _empleados.Empleados_Listar();
        }

        public List<Models.Consultas.Empleados> Empleados_Listar_Consulta(int Id)
        {
            return _empleados.Empleados_Listar_Consulta(Id);
        }




        public Models.Consultas.EmpleadosGrafica Empleados_Total_Empleados()
        {
            return _empleados.Empleados_Total_Empleados();
        }

        public Models.Consultas.EmpleadosGrafica Empleados_Total_Activos()
        {
            return _empleados.Empleados_Total_Activos();
        }

        public Models.Consultas.EmpleadosGrafica Empleados_Total_Inactivos()
        {
            return _empleados.Empleados_Total_Inactivos();
        }

        public Models.Consultas.EmpleadosGrafica Empleados_ContratosVencidos()
        {
            return _empleados.Empleados_ContratosVencidos();
        }

        public Models.Consultas.EmpleadosGrafica Empleados_ContratosPorVencer()
        {
            return _empleados.Empleados_ContratosPorVencer();
        }

        public Models.Consultas.EmpleadosGrafica Empleados_DocumentosNoentregados()
        {
            return _empleados.Empleados_DocumentosNoentregados();
        }

        public Models.Consultas.EmpleadosGrafica Empleados_DocumentosPendiente()
        {
            return _empleados.Empleados_DocumentosPendiente();
        }

        public List<Models.Consultas.EmpleadosGrafica> Empleados_Cliente()
        {
            return _empleados.Empleados_Cliente();
        }

        public List<Models.Consultas.EmpleadosGrafica> Empleados_Cliente_IdEmprea(Models.Empresas empresas)
        {
            return _empleados.Empleados_Cliente_IdEmprea(empresas);
        }

        public List<Models.Consultas.EmpleadosGrafica> Empleados_Proyecto()
        {
            return _empleados.Empleados_Proyecto();
        }

        
        

        public Models.Empleados Empleados_DarDeBaja(Models.Personas personas)
        {
            return _empleados.Empleados_DarDeBaja(personas);
        }

        public Models.Empleados Empleados_DarDeAlta(Models.Personas personas)
        {
            return _empleados.Empleados_DarDeAlta(personas);
        }
    }
}
