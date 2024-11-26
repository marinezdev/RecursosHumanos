using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class PersonasDocumentos
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public Cat_TipoDocumento Cat_TipoDocumento { get; set; }
        public Cat_EstatusDocumento Cat_EstatusDocumento { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaVigencia { get; set; }
        public DocumentoVersiones DocumentoVersiones { get; set; }
        public List<Models.Cat_EstatusDocumento> CatEstatusDocumento { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
