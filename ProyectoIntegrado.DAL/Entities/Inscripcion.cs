using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    class Inscripcion
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        [ForeignKey("AlumnoId")]
        public Alumno Alumno { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get; set; }
        public int PosicionId { get; set; }
        [ForeignKey("PosicionId")]
        public PosicionDeTrabajoDTO Posicion { get; set; }
        public string EstadoInscripcion { get; set; }

        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "(a:yyyy-MM-dd)")]
        public DateTime FechaInscripcion { get; set; }

    }
}
