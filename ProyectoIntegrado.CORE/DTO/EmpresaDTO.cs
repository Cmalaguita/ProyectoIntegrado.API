﻿using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia provincia { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        public bool EmailVerificado { get; set; }
        public string empresaStripeID { get; set; }
    }
}
