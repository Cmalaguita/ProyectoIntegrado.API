using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class CrearFacturaDTO
    {
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaPago { get; set; }
        public int idEmpresa { get; set; }
        public string suscripcionId { get; set; }
        public int idContrato { get; set; }
    }
}
