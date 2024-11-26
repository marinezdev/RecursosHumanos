using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ProspectoMensaje
    {
        Data.ProspectoMensaje _ProspectoMensaje = new Data.ProspectoMensaje();
        public Models.ProspectoMensaje ProspectoMensaje_Agregar(Models.ProspectoMensaje prospectoMensaje)
        {
            return _ProspectoMensaje.ProspectoMensaje_Agregar(prospectoMensaje);
        }
        public List<Models.ProspectoMensaje> ProspectoMensaje_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            return _ProspectoMensaje.ProspectoMensaje_Seleccionar_IdVacante(vacante);
        }
        public List<Models.ProspectoMensaje> ProspectoMensaje_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoMensaje.ProspectoMensaje_Seleccionar_IdProspecto(prospecto);
        }


        public Models.ProspectoMensaje ProspectoMensaje_Actualizar(Models.ProspectoMensaje ProspectoMensaje)
        {
            return _ProspectoMensaje.ProspectoMensaje_Actualizar(ProspectoMensaje);
        }


        public Models.ProspectoMensaje Prospecto_EliminarMensaje(Models.ProspectoMensaje ProspectoMensaje)
        {
            return _ProspectoMensaje.Prospecto_EliminarMensaje(ProspectoMensaje);
        }
    }
}
