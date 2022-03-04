using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class Factura
    {
        public int id { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime fechaCreacion { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime fechaPago { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime fechaFin { get; set; }
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Empresa empresa { get; set; }
        public string suscripcionId { get; set; }
        public int idContrato { get; set; }
        [ForeignKey("idContrato")]
        public Contrato contrato { get; set; }
        
    }
}
