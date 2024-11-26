﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class EmpresaPuestos
    {
        public int Id
        {
            get; set;
        }

        public int IdDepartamento { get; set; }
        public string Nombre
        {
            get; set;
        }
        public EmpresasDepartamento EmpresasDepartamento { get; set; }
     }
}
