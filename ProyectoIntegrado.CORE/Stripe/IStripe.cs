using ProyectoIntegrado.DAL.Entities;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrado.CORE.Stripe
{
    public interface IStripe
    {
        public Customer ObtenerStripeIdEmpresa(string empresaStripeId);
       
        public string ObtenerEmailEmpresaPorStripeId(string empresaStripeId);
        public StripeList<Subscription> ObtenerSuscripciones(string suscripcionId);
        public StripeList<Subscription> ObtenerSuscripcionPremium();
        public Customer CrearEmpresEnStripe(Empresa empresa);
        public bool ComprobarSuscripcionPremium(string email);     
        public Task<Session> ComprarSuscripcionPremium(string stripeEmpresaId);
        public bool ComprobarSiExisteSuscripcion(string empresaStripeId, string suscripcionId);
        public Task<Session> ComprarSuscripcion(string empresaStripeId, string suscripcionId);
    }
}
