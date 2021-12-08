using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class Ciclo
    {
        [Key]
        public int Id { get; set; }
        public int IdTipo { get; set; }
        [ForeignKey("IdTipo")]
        public TipoDeCiclo TipoCiclo { get; set; }
        public int MyProperty { get; set; }
        public int IdFamilia { get; set; }
        [ForeignKey("IdFamilia")]
        public FamiliaProfesional familia { get; set; }
        public string Nombre { get; set; }
    }
}
