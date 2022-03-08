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
                    Console.WriteLine("invoice dentro del evento" + invoice);
                    Console.WriteLine("ID EMPRESA: "+ empresaBL.ExistsUnicamenteEmail(stripe.ObtenerEmailEmpresaPorStripeId(invoice.CustomerId)).Id);
                    Console.WriteLine("SUSCRIPCIONID: " + invoice.SubscriptionId);
                    Console.WriteLine("INICIO DEL PERIODO: " + invoice.PeriodStart);
                    Console.WriteLine("FECHA DE PAGO: " + (DateTime)invoice.StatusTransitions.PaidAt);
                    Console.WriteLine("FECHA DE FIN: " + invoice.Lines.Data[0].Period.End);
                    Console.WriteLine("ID CONTRATO: " + contratoBL.ObtenerContratoPorEmpresaYSuscripcionId(empresaBL.ExistsUnicamenteEmail(stripe.ObtenerEmailEmpresaPorStripeId(invoice.CustomerId)).Id, invoice.SubscriptionId).id);
                    CrearFacturaDTO nf = new CrearFacturaDTO
                    {
                        idEmpresa = empresaBL.ExistsUnicamenteEmail(stripe.ObtenerEmailEmpresaPorStripeId(invoice.CustomerId)).Id,
                        suscripcionId = invoice.SubscriptionId,
                        fechaCreacion = invoice.Created,
                        fechaPago = (DateTime)invoice.StatusTransitions.PaidAt,
                        fechaFin = facturaBL.FromUnixTimestampToDateTime(invoice.Lines.Data[0].Period.End),
                        idContrato = contratoBL.ObtenerContratoPorEmpresaYSuscripcionId(empresaBL.ExistsUnicamenteEmail(stripe.ObtenerEmailEmpresaPorStripeId(invoice.CustomerId)).Id,invoice.SubscriptionId).id
                    };
                    facturaBL.InsertarFactura(nf);
                }
                else if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    Console.WriteLine("Suscripcion dentro del evento"+subscription);
                    Console.WriteLine("CONTRATO EMAIL CLIENTE: " + stripe.ObtenerEmailEmpresaPorStripeId(subscription.CustomerId));
                    Console.WriteLine("CONTRATO SUSCRIPCION ID: "+subscription.Id);
                    Console.WriteLine("CONTRATO EMPRESASTRIPEID: " + subscription.CustomerId);
                    Console.WriteLine("CONTRATO EMPRESAID: " + empresaBL.ExistsUnicamenteEmail(stripe.ObtenerEmailEmpresaPorStripeId(subscription.CustomerId)).Id);
                    Console.WriteLine("CONTRATO FECHAALTASUSCRIPCION: " + subscription.Created);
                    Console.WriteLine("CONTRATO FECHAEXPIRASUSCRIPCION: " + subscription.CurrentPeriodEnd);
                    CrearContratoDTO nc = new CrearContratoDTO
                    {
                        suscripcionId = subscription.Id,
                        empresaStripeId = subscription.CustomerId,
                        idEmpresa = empresaBL.ExistsUnicamenteEmail(stripe.ObtenerEmailEmpresaPorStripeId(subscription.CustomerId)).Id,
                        fechaAltaSuscripcion = subscription.Created,
                        fechaExpiraSuscripcion = subscription.CurrentPeriodEnd
                    };
                    contratoBL.InsertarContrato(nc);
                }
                else if (stripeEvent.Type == Events.CustomerCreated)
                {
                    var customer = stripeEvent.Data.Object as Customer;

                }
                else if (stripeEvent.Type == Events.PaymentIntentCanceled)
                {
                    var customer = stripeEvent.Data.Object as PaymentIntent;

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
              string s =contratoBL.CrearSuscripcionPremium(empresaDTO);
            if (s!=null)
            {
                return s;
            }
            else
            {
                return null;
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Comprobar_Sus_Premium")]
        public ActionResult<FacturaDTO> ComprobarSuscripcionPremium(int empresaId)
        {
              var f= facturaBL.ObtenerFacturaPagadaMasReciente(empresaId);
            if (f!=null)
            {
                return Ok(f);

            }
            else
            {
                return NotFound();
            }
        }
    }
}
