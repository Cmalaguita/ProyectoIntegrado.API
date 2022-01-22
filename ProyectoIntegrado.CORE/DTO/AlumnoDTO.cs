using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class AlumnoDTO
    {
       
        public int Id { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int idCiclo { get; set; }
        public Ciclo ciclo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Localidad { get; set; }
        public int IdProvincia { get; set; }
        public Provincia provincia { get; set; }
        public double NotaMedia { get; set; }
      
    }
}
