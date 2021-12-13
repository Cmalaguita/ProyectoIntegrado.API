using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class AlumnoLoginDTO
    {
        public string Email { get; set; }   
        public string Password { get; set; }
    }
}
