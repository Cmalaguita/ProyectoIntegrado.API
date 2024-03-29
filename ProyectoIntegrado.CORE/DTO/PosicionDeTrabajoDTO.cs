﻿using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class PosicionDeTrabajoDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaDTO empresa { get; set; }
        public ICollection<CicloDTO> Ciclos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Horario { get; set; }
        public double Remuneracion { get; set; }
    }
}
