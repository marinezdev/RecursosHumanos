﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Cat_ProyectoServicios
    {
        public int Id { get; set; }
        public Cat_Clientes Cat_Clientes { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
    }
}
