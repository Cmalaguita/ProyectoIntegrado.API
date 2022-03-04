using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.DTO
{
   public class FacturaDTO
    {
        public int id { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaPago { get; set; }
        public DateTime fechaFin { get; set; }
        public int idEmpresa { get; set; }
        public EmpresaDTO empresa { get; set; }
        public string suscripcionId { get; set; }
        public int idContrato { get; set; }
       
        public ContratoDTO contrato { get; set; }
    }
}
