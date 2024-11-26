using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_TipoDocumento
    {
        Data.Cat_TipoDocumento _tipoDocumento = new Data.Cat_TipoDocumento();
        public List<Models.Cat_TipoDocumento> Cat_TipoDocumento_Selecionar_Default()
        {
            return _tipoDocumento.Cat_TipoDocumento_Selecionar_Default();
        }
        public List<Models.Cat_TipoDocumento> Cat_TipoDocumento_Selecionar()
        {
           return _tipoDocumento.Cat_TipoDocumento_Selecionar();
        }

        public Models.Cat_TipoDocumento Cat_TipoDocumento_Agregar(Models.Cat_TipoDocumento tipoDocumento)
        {
            return _tipoDocumento.Cat_TipoDocumento_Agregar(tipoDocumento);
        }

        public Models.Cat_TipoDocumento Cat_TipoDocumento_Selecionar_Id(Models.Cat_TipoDocumento tipoDocumento)
        {
            return _tipoDocumento.Cat_TipoDocumento_Selecionar_Id(tipoDocumento);
        }
    }
}
