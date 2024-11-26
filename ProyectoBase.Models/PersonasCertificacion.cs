using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasCertificacion
    {
        public int Id { get; set; }

        public Personas Personas { get; set; }
        public Cat_Certificaciones Cat_Certificaciones { get; set; }
        public DateTime FechaTermino { get; set; }
        public int Aprobado { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }

        //public int IdPersona
        //{
        //    get; set;
        //}
        //public int IdCertificacion
        //{
        //    get; set;
        //}
        //public string Certificacion { get; set; }
        //public string Nombre { get; set; }
        //public string FechaTermino
        //{
        //    get; set;
        //}
        //public string Certificado
        //{
        //    get; set;
        //}
    }
}
