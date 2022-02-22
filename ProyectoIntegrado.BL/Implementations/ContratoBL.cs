using Microsoft.Extensions.Configuration;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Stripe;
using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Repositories.Implementations;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
    class ContratoBL : IContratoBL
    {
        public IEmpresaRepository empresaRepository { get; set; }
        public IStripe stripe { get; set; }
        public ContratoBL(IEmpresaRepository empresaRepository,IStripe stripe)
        {
            this.stripe = stripe;
            this.empresaRepository = empresaRepository;
            
        }
        public ContratoDTO Stripe(ContratoDTO contratoDTO)
        {
            #region Crear customer si no existe
            var e = empresaRepository.BuscarEmpresa(contratoDTO.idEmpresa);
            if (e.empresaStripeID == null)
            {
                var customer = stripe.CrearEmpresEnStripe(e);
                e.empresaStripeID = customer.Id;
                empresaRepository.ActualizarEmpresa(e);
            }
            stripe.ComprarSuscripcionPremium(e.empresaStripeID);
            #endregion
            return contratoDTO;
        }
        public DateTime FromUnixTimestampToDateTime(long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

    }
}
