﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ProspectoExperiencia
    {
        public int Id { get; set; } 
        public string Cargo { get; set; }
        public string NombreEmpresa { get; set; }
        public string Funciones { get; set; }
        public float SueldoInicial { get; set; }
        public float SueldoFinal { get; set; }
        public int TrabajoActivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set;}

        public string SueldoInicialText { get; set; }
        public string SueldoFinalText { get; set; }
    }
}
