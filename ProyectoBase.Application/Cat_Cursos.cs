using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Cursos
    {
        ProyectoBase.Data.Cat_Cursos _cat_Cursos = new Data.Cat_Cursos();
        public List<Models.Cat_Cursos> Cat_Cursos_Seleccionar()
        {
            return _cat_Cursos.Cat_Cursos_Seleccionar();
        }

        public Models.Cat_Cursos Cat_Cursos_Agregar(Models.Cat_Cursos cat_Cursos)
        {
            return _cat_Cursos.Cat_Cursos_Agregar(cat_Cursos);
        }
    }
}
