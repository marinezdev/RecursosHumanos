using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasDetalle
    {
        public Cat_EstadoCivil Cat_EstadoCivil { get; set; }
        public Cat_TipoCredito Cat_TipoCredito { get; set; }
        public Cat_Banco Cat_Banco { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set; }
        public Cat_Clientes Cat_Clientes { get; set; }
        public Cat_ProyectoServicios Cat_ProyectoServicios { get; set; }
        public Cat_EsquemaContratacion Cat_EsquemaContratacion { get; set; }
        public Cat_FuenteReclutamiento Cat_FuenteReclutamiento { get; set; }
        public ClienteDireciones clienteDireciones { get; set; }
        public Usuarios Usuarios { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string NSS { get; set; }
        public string ClaveInterbancaria { get; set; }
        public string NoNomina { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoFijo { get; set; }
        public string CorreoPersonal { get; set; }
        public string CorreoCorporativo { get; set; }
        public string Sueldo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public int Vencimiento { get; set; }
        public string NmOriginal { get; set; }
        public string NmArchivo { get; set; }
        public int CDC { get; set; }
        public int Estudios { get; set; }
    }
}
