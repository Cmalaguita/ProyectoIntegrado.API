﻿using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class EmpresaCompletaDTO
    {
     
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }

    }
}
