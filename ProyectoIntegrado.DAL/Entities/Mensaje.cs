using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
   public class Mensaje
    {
        [Key]
        public int id { get; set; }
        public int alumnoId { get; set; }
        [ForeignKey("alumnoId")]
        public Alumno alumno { get; set; }
        public int empresaId { get; set; }
        [ForeignKey("empresaId")]
        public Empresa empresa { get; set; }
        public string contenido { get; set; }
        public bool leido { get; set; }
    }
}
