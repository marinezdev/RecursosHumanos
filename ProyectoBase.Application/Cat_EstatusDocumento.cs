using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_EstatusDocumento
    {
        Data.Cat_EstatusDocumento _EstatusDocumento = new Data.Cat_EstatusDocumento();

        public List<Models.Cat_EstatusDocumento> Cat_EstatusDocumento_Seleccionar()
        {
            return _EstatusDocumento.Cat_EstatusDocumento_Seleccionar();
        }

        public Models.Cat_EstatusDocumento Cat_EstatusDocumento_Selecionar_Id(int Id)
        {
            return _EstatusDocumento.Cat_EstatusDocumento_Selecionar_Id(Id);
        }
    }
}
