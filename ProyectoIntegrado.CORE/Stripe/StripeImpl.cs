using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProyectoIntegrado.DAL.Entities;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegrado.CORE.Stripe
{
    public class StripeImpl : IStripe
    {
        public IConfiguration configuration { get; set; }
        public IMapper mapper { get; set; }

        public StripeImpl(IConfiguration configuration, IMapper mapper)
        {
            this.mapper = mapper;
            this.configuration = configuration;

            StripeConfiguration.ApiKey = configuration["Pago:Stripe:secretApiKey"];
        }

        public Customer ObtenerStripeIdEmpresa(string empresaStripeId)
        {
            return new CustomerService().Get(empresaStripeId);
        }

        public string ObtenerEmailEmpresaPorStripeId(string empresaStripeId)
        {
            return new CustomerService().Get(empresaStripeId).Email;
        }

        public StripeList<Subscription> ObtenerSuscripciones(string suscripcionId)
        {
            var options = new SubscriptionListOptions
            {
                Price = suscripcionId,
                Status = "active",
                Limit = 100,
            };
            var suscripciones = new SubscriptionService();
            return suscripciones.List(
                options
            );
        }

        public StripeList<Subscription> ObtenerSuscripcionPremium()
        {
           return ObtenerSuscripciones("price_1KUv1RLurAtlZyUsd1ZDVmEt");
        }

        public Customer CrearEmpresEnStripe(Empresa empresa)
        {
            var options = new CustomerCreateOptions
            {
                Email = empresa.Email,
                Name = empresa.Nombre,
                Address = new AddressOptions
                {
                    Country = "es",
                    State = empresa.Provincia.Nombre,
                    Line1 = empresa.Direccion
                },
                Description = "Cliente de Doors n' Corners",
            };

            return new CustomerService().Create(options);
        }

        public bool ComprobarSuscripcionPremium(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Session> ComprarSuscripcionPremium(string stripeEmpresaId)
        {
            return ComprarSuscripcion(stripeEmpresaId, "price_1KUv1RLurAtlZyUsd1ZDVmEt");
        }

        public bool ComprobarSiExisteSuscripcion(string stripeEmpresaId, string suscripcionId)
        {
            SubscriptionListOptions opciones = new SubscriptionListOptions
            {
                Price = suscripcionId,
                Status = "active",
                Limit = 100,
                Customer = stripeEmpresaId
            };
            SubscriptionService servicio = new SubscriptionService();

            return servicio.List(
                opciones
            ).Data.Count > 0;
        }

        public async Task<Session> ComprarSuscripcion(string stripeEmpresaId , string suscripcionId)
        {
            var options = new SessionCreateOptions
            {

                SuccessUrl = "https://example.com/success.html?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://example.com/canceled.html",
                Mode = "subscription",
                Customer = stripeEmpresaId,
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = suscripcionId,
                        Quantity = 1,
                    },
                },
            };

            return await new SessionService().CreateAsync(options);
        }
    }
}
