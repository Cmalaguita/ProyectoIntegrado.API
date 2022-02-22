using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
    public class ContratoDTO
    {
        public int id { get; set; }
        public string empresaStripeId { get; set; }
        public string suscripcionId { get; set; }
        public int idEmpresa { get; set; }
        public Empresa empresa { get; set; }
        public List<Factura> facturas { get; set; }
        public DateTime fechaAltaSuscripcion { get; set; }
        public DateTime fechaExpiraSuscripcion { get; set; }
        public DateTime? fechaCancelacion { get; set; }
    }
}
