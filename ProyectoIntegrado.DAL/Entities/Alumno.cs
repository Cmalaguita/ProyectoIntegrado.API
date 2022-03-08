using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int idCiclo { get; set; }
        [ForeignKey("idCiclo")]
        public Ciclo ciclo { get; set; }
        [Column(TypeName = "Date"),DisplayFormat(DataFormatString ="(a:yyyy-MM-dd)")]
        public DateTime FechaDeNacimiento { get; set; }
        public string Localidad { get; set; }
        public int IdProvincia { get; set; }
        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; }
        public double NotaMedia { get; set; }
        public string CodigoVerificacion{ get; set; }
        public bool EmailVerificado { get; set; }
        public string imagen { get; set; }
    }
}
