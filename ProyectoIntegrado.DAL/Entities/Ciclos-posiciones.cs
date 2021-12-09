using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
   public class Ciclos_posiciones
    {
        public int idCiclo { get; set; }
        [ForeignKey("idCiclo")]
        public Ciclo ciclo { get; set; }
        public int idPosicion { get; set; }
        [ForeignKey("idPosicion")]
        public PosicionDeTrabajoDTO posicion { get; set; }
    }
}
