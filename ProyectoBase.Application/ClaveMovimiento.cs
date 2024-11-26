using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ClaveMovimiento
    {
        Data.ClaveMovimiento _UsuarioClaveMovimiento = new Data.ClaveMovimiento();

        public Models.ClaveMovimiento ClaveMovimiento_Agregar(Models.ClaveMovimiento usuarioClaveMovimiento)
        {
            return _UsuarioClaveMovimiento.ClaveMovimiento_Agregar(usuarioClaveMovimiento);
        }
    }
}
