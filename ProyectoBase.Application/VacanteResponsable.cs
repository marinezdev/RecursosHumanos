using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class VacanteResponsable
    {
        Data.VacanteResponsable _VacanteResponsable = new Data.VacanteResponsable();
        public Models.VacanteResponsable VacanteResponsable_Agregar(Models.VacanteResponsable vacanteResponsable)
        {
            return _VacanteResponsable.VacanteResponsable_Agregar(vacanteResponsable);
        }
        public List<Models.VacanteResponsable> VacanteResponsable_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            return _VacanteResponsable.VacanteResponsable_Seleccionar_IdVacante(vacante);
        }

        public Models.VacanteResponsable VacanteResponsable_Eliminar(Models.VacanteResponsable VacanteResponsable)
        {
            return _VacanteResponsable.VacanteResponsable_Eliminar(VacanteResponsable);
        }
    }
}
