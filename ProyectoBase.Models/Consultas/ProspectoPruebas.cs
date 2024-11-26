using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Consultas
{
    public class ProspectoPruebas
    {
        public Vacante Vacante { get; set; }
        public Prospecto Prospecto { get; set; }
        public Cat_TipoPrueba cat_TipoPrueba { get; set; }
        public Cat_EstatusPrueba cat_EstatusPrueba { get; set; }
        public ProspectoPrueba ProspectoPrueba { get; set; }
    }
}
