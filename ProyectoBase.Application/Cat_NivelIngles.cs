using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_NivelIngles
    {
        ProyectoBase.Data.Cat_NivelIngles _cat_nivelingles = new Data.Cat_NivelIngles();
        public List<Models.Cat_NivelIngles> Cat_NivelIngles_Selecionar_Listar()
        {
            return _cat_nivelingles.Cat_NivelIngles_Selecionar_Listar();
        }
    }
}
