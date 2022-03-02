using ProyectoIntegrado.CORE.DTO;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IContratoBL
    {
        public string CrearSuscripcionPremium(EmpresaDTO empresa);
        public DateTime FromUnixTimestampToDateTime(long unixTimeStamp);
        public List<ContratoDTO> ObtenerContratosPorEmpresaStripeId(string empresaStripeId);
        public List<ContratoDTO> ObtenerContratosPorSuscripcionId(string suscripcionId);
        public List<ContratoDTO> ObtenerContratosPorEmpresaId(int empresaId);
        public ContratoDTO ObtenerContratoPorEmpresaYSuscripcionId(int empresaId, string suscripcionId);
        public ContratoDTO InsertarContrato(CrearContratoDTO contrato);
        public bool BorrarContrato(int idContrato);
        public ContratoDTO ExistContrato(int idContrato);
    }
}
