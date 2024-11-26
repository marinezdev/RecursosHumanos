using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class Prospectos
    {
        public Empresas Empresas { get; set; }  
        public EmpresasDepartamento EmpresasDepartamento { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set;}
        public Cat_Clientes Cat_Clientes { get; set;}
        public Vacante Vacante { get; set; }    
        public Prospecto Prospecto { get; set; }    
        public Cat_EstatusProspecto Cat_EstatusProspecto { get; set; }
    }
}
