using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class CrearMensajeDTO
    {   
        public int alumnoId { get; set; }
        public int empresaId { get; set; }   
        public string contenido { get; set; }
        public bool leido { get; set; }
    }
}
