using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class CicloDTO
    {
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipo { get; set; }
        public TipoDeCiclo tipociclo { get; set; }
        public int IdFamilia { get; set; }
        public FamiliaProfesional familia { get; set; }
      
    }
}
