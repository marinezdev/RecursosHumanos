using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Reportes
    {
        Data.Reportes _reportes = new Data.Reportes();
        public DataTable Reporte_Empleados_Documentos()
        {
            return _reportes.Reporte_Empleados_Documentos();
        }
        public DataTable Reporte_Empleados_Documentos_Procentaje()
        {
            return _reportes.Reporte_Empleados_Documentos_Procentaje();
        }

        public DataTable Reporte_Empleados_Documentos_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes)
        {
            return _reportes.Reporte_Empleados_Documentos_Procentaje_Cliente(cat_Clientes);
        }

        public DataTable Reporte_Empleados_Documentos_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            return _reportes.Reporte_Empleados_Documentos_Procentaje_Cliente_ProyectoServicio(cat_ProyectoServicios);
        }
    }
}
