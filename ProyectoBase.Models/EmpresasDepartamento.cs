﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class EmpresasDepartamento
    {
        public Empresas Empresas { get; set; }
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
    }
}
