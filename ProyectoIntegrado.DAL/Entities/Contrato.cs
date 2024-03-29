﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoIntegrado.DAL.Entities
{
    public class Contrato
    {
        public int id { get; set; }
        public string empresaStripeId { get; set; }
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Empresa empresa { get; set; }
        public string suscripcionId { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime fechaAltaSuscripcion { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime? fechaCancelacion { get; set; }
    }
}
