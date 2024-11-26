using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Almacenamiento
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Cat_Almacenamiento Cat_Almacenamiento_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Almacenamiento_Seleccionar");

            Models.Cat_Almacenamiento resultado = new Models.Cat_Almacenamiento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Ruta = reader["Ruta"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
