using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
   public class PosicionDeTrabajo
    {

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        public string Descripcion { get; set; }
        public string Horario { get; set; }
        public double Remuneracion { get; set; }
        public ICollection<Ciclo> Ciclos { get; set; }
    }
}
