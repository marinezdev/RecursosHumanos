using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class QuincenaImportada
    {
        public int Id { get; set; }
        public ArchivoQuincena ArchivoQuincena { get; set; }
        public string Quincena { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string NSS { get; set; }
        public string CURP { get; set; }
        public string Pago { get; set; }
        public string FechaIngreso { get; set; }
        public string DiasPagados { get; set; }
        public string Baja { get; set; }
        public string DiasIncapacidad { get; set; }
    }
}
