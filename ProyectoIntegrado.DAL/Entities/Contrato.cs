using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class Contrato
    {
        public int id { get; set; }
        public string empresaStripeId { get; set; }
        public string suscripcionId { get; set; }
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Empresa empresa { get; set; }
        public DateTime fechaAltaSuscripcion { get; set; }
        public DateTime fechaExpiraSuscripcion { get; set; }
        public DateTime? fechaCancelacion { get; set; }
    }
}
