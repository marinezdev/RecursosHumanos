using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Prospecto
    {
        Data.Prospecto _Prospecto = new Data.Prospecto();
        public Models.Prospecto Prospecto_Agregar(Models.Prospecto prospecto)
        {
            return _Prospecto.Prospecto_Agregar(prospecto);
        }
        public List<Models.Prospecto> Prospecto_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            return _Prospecto.Prospecto_Seleccionar_IdVacante(vacante);
        }
        public Models.Prospecto Prospecto_Seleccionar_Id(Models.Prospecto prospecto)
        {
            return _Prospecto.Prospecto_Seleccionar_Id(prospecto);
        }
        public Models.Prospecto Prospecto_Actualizar_IdEstatus(Models.Prospecto prospecto)
        {
            return _Prospecto.Prospecto_Actualizar_IdEstatus(prospecto);
        }
        public List<Models.Consultas.Prospectos> Prospecto_Seleccionar()
        {
            return _Prospecto.Prospecto_Seleccionar();
        }
        public Models.Prospecto Prospecto_Eliminar_Id(Models.Prospecto prospecto)
        {
            return _Prospecto.Prospecto_Eliminar_Id(prospecto);
        }
        public Models.Prospecto Prospecto_Actualizar(Models.Prospecto prospecto)
        {
            return _Prospecto.Prospecto_Actualizar(prospecto);
        }



        public Models.Prospecto ProspectoExperiencia_Eliminar(Models.Prospecto prospecto)
        {
            return _Prospecto.ProspectoExperiencia_Eliminar(prospecto);
        }

    }
}
