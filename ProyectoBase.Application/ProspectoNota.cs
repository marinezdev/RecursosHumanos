using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public  class ProspectoNota
    {
        Data.ProspectoNota _ProspectoNota = new Data.ProspectoNota();
        public Models.ProspectoNota ProspectoNota_Agregar(Models.ProspectoNota prospectoNota)
        {
            return _ProspectoNota.ProspectoNota_Agregar(prospectoNota);
        }
        public List<Models.ProspectoNota> ProspectoNota_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoNota.ProspectoNota_Seleccionar_IdProspecto(prospecto);
        }
        public Models.ProspectoNota Prospecto_EliminarNota(Models.ProspectoNota ProspectoNota)
        {
            return _ProspectoNota.Prospecto_EliminarNota(ProspectoNota);
        }

        public Models.ProspectoNota Prospecto_Actualizar_nota(Models.ProspectoNota prospectoNota)
        {
            return _ProspectoNota.Prospecto_Actualizar_nota(prospectoNota);
        }
    }
}
