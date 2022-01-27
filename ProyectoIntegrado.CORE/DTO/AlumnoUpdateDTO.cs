using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class AlumnoUpdateDTO
    {
       
        public string Email { get; set; }   
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int idCiclo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Localidad { get; set; }
        public int IdProvincia { get; set; }
        public double NotaMedia { get; set; }
    }
}
