using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Stripe;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        public IStripe stripe { get; set; }
        public IContratoBL contratoBL { get; set; }
        public IFacturaBL facturaBL { get; set; }
        public IEmpresaBL empresaBL { get; set; }
        public ContratoController(IContratoBL contratoBL, IFacturaBL facturaBL, IStripe stripe, IEmpresaBL empresaBL)
        {
            this.empresaBL = empresaBL;
            this.stripe = stripe;
            this.facturaBL = facturaBL;
            this.contratoBL = contratoBL;
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> CrearPago(ContratoDTO contratoDTO)
        {
            var options = new SessionCreateOptions
            {
                SuccessUrl = "success.html?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "/failure.html",
                PaymentMethodTypes = new List<string>
                  {
                    "card",
                  },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                  {
                    new SessionLineItemOptions
                    {
                      Price = contratoDTO.suscripcionId, //Tu priceID
                      // For metered billing, do not pass quantity
                      Quantity = 1,
                    },
                  },
                Customer = contratoDTO.empresa.empresaStripeID,
               
            };

            var service = new SessionService();
            var session = service.Create(options);
            return Ok(session.Url);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Webhook")]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var endpointSecret = "whsec_cTZF2X4JnfGPAY9qADdNcKwiLxRUNG21";

            try
            {
               
                var stripeEvent = EventUtility.ParseEvent(json);

                stripeEvent = EventUtility.ConstructEvent(json,
    Request.Headers["Stripe-Signature"], endpointSecret);
                Console.WriteLine("EVENTO RECIBIDO " + stripeEvent.Type);
                if (stripeEvent.Type == Events.InvoicePaid)
                {
                    var invoice = stripeEvent.Data.Object as Invoice;
                    CrearFacturaDTO nf = new CrearFacturaDTO
                    {
                        idEmpresa = empresaBL.ExistsUnicamenteEmail(invoice.CustomerEmail).Id,
                        suscripcionId = invoice.SubscriptionId,
                        fechaCreacion = invoice.PeriodStart,
                        fechaPago = invoice.PeriodEnd,
                        idContrato = contratoBL.ObtenerContratoPorEmpresaYSuscripcionId(empresaBL.ExistsUnicamenteEmail(invoice.Customer.Email).Id,invoice.SubscriptionId).id
                    };
                    facturaBL.InsertarFactura(nf);
                }
                else if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    CrearContratoDTO nc = new CrearContratoDTO
                    {
                        suscripcionId = subscription.Id,
                        empresaStripeId = subscription.CustomerId,
                        idEmpresa = empresaBL.ExistsUnicamenteEmail(subscription.Customer.Email).Id,
                        fechaAltaSuscripcion = subscription.Created,
                        fechaExpiraSuscripcion = subscription.CurrentPeriodEnd
                    };
                    contratoBL.InsertarContrato(nc);
                }
                else if (stripeEvent.Type == Events.CustomerCreated)
                {
                    var customer = stripeEvent.Data.Object as Customer;

                }
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Crear_Sus_Premium")]
        public string crearSuscripcionPremium(EmpresaDTO empresaDTO)
        {
            
            return contratoBL.CrearSuscripcionPremium(empresaDTO);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Comprobar_Sus_Premium")]
        public string ComprobarSuscripcionPremium(EmpresaDTO empresaDTO)
        {

            return contratoBL.CrearSuscripcionPremium(empresaDTO);
        }
    }
}
