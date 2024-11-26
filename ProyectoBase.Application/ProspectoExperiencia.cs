using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ProspectoExperiencia
    {
        Data.ProspectoExperiencia _ProspectoExperiencia = new Data.ProspectoExperiencia();
        public List<Models.ProspectoExperiencia> ProspectoExperiencia_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoExperiencia.ProspectoExperiencia_Seleccionar_IdProspecto(prospecto);
        }

        public Models.ProspectoExperiencia ProspectoExperiencia_Agregar(Models.ProspectoExperiencia prospectoExperiencia)
        {
            return _ProspectoExperiencia.ProspectoExperiencia_Agregar(prospectoExperiencia);
        }
    }
}
