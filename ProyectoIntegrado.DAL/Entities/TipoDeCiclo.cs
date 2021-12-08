using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class TipoDeCiclo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
