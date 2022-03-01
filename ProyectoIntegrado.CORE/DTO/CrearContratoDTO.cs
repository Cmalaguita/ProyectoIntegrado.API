using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
    public class CrearContratoDTO
    {
        public string empresaStripeId { get; set; }
        public string suscripcionId { get; set; }
        public int idEmpresa { get; set; }
        public DateTime fechaAltaSuscripcion { get; set; }
        public DateTime fechaExpiraSuscripcion { get; set; }
        public DateTime? fechaCancelacion { get; set; }
    }
}
