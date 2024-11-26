using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Reportes
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Reporte_Empleados_Documentos()
        {
            string consulta = "";
            consulta = "EXECUTE Reporte_Empleados_Documentos";

            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public DataTable Reporte_Empleados_Documentos_Procentaje()
        {
            string consulta = "";
            consulta = "EXECUTE Reporte_Empleados_Documentos_Procentaje";

            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public DataTable Reporte_Empleados_Documentos_Procentaje_Cliente(Models.Cat_Clientes cat_Clientes)
        {
            string consulta = "";
            consulta = "EXECUTE Reporte_Empleados_Documentos_Procentaje_Cliente " + " " + cat_Clientes.Id;

            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public DataTable Reporte_Empleados_Documentos_Procentaje_Cliente_ProyectoServicio(Models.Cat_ProyectoServicios cat_ProyectoServicios)
        {
            string consulta = "";
            consulta = "EXECUTE Reporte_Empleados_Documentos_Procentaje_Cliente_ProyectoServicio " + " " + cat_ProyectoServicios.Id;

            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

    }
}
