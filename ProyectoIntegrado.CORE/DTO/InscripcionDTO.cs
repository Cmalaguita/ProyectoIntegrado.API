using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
   public class InscripcionDTO
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
     
        public AlumnoDTO alumno { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public int PosicionId { get; set; }
        public PosicionDeTrabajoDTO Posicion { get; set; }
        public string EstadoInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}
