using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ProspectoBitacora
    {
        Data.ProspectoBitacora _ProspectoBitacora = new Data.ProspectoBitacora();
        public List<Models.ProspectoBitacora> ProspectoBitacora_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoBitacora.ProspectoBitacora_Seleccionar_IdProspecto(prospecto);
        }
        public List<Models.Consultas.Actividad> ProspectoBitacora_Actividad_Mes(Models.Prospecto prospecto)
        {
            return _ProspectoBitacora.ProspectoBitacora_Actividad_Mes(prospecto);
        }
    }
}
