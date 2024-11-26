using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Vacante
    {
        public int Id { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set; }
        public Cat_ProyectoServicios Cat_ProyectoServicios { get; set; }
        public Cat_EsquemaContratacion Cat_EsquemaContratacion { get; set; }
        public ClienteDirecciones ClienteDirecciones { get; set; }
        public Cat_Modalidad Cat_Modalidad { get; set; }
        public Cat_JornadaTrabajo Cat_JornadaTrabajo { get; set; }
        public Cat_MotivosBajaEmpleado Cat_MotivosBajaEmpleado { get; set; }
        public Cat_EstatusVacante Cat_EstatusVacante { get; set; }
        public Usuarios Usuarios { get; set; }
        public Empleados Empleados { get; set; }
        public string Titulo { get; set; }
        public int Salario { get; set; }
        public float SalarioInicial { get; set; }
        public float SalarioFinal { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdEmpleadoBaja { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Contenido { get; set; }
        public int Notificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Prospecto { get; set; }
        public int Tiempo { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set;}
    }
}
