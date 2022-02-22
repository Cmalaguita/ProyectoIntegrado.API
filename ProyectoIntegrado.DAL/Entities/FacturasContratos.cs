using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
   public class FacturasContratos
    {
        public int id { get; set; }
        public int idFactura { get; set; }
        [ForeignKey("idFactura")]
        public Factura factura { get; set; }
        public int idContrato { get; set; }
        [ForeignKey("idContrato")]
        public Contrato contrato { get; set; }
    }
}
