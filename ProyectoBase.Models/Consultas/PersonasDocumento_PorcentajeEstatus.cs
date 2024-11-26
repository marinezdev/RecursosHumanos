using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class PersonasDocumento_PorcentajeEstatus
    {
        public string EstatusDocumento { get; set; }
        public int Total { get; set; }
        public int Porcentaje { get; set; }
    }
}
