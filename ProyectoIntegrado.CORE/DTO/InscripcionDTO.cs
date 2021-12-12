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
     
        public Alumno alumno { get; set; }
        public int EmpresaId { get; set; }
      
        public Empresa Empresa { get; set; }
        public int PosicionId { get; set; }
       
        public PosicionDeTrabajo Posicion { get; set; }
        public string EstadoInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }

    }
}
