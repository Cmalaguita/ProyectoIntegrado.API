using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    class CiclosRelacionados
    {
        [Key]
        public int Id { get; set; }
        public int IdCiclo { get; set; }
        [ForeignKey("IdCiclo")]
        public Ciclo Ciclo { get; set; }
        public int IdPosicion { get; set; }
        [ForeignKey("IdPosicion")]
        public PosicionDeTrabajoDTO posicion { get; set; }

    }
}
