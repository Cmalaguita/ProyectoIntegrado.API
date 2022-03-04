using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Stripe;
using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using ProyectoIntegrado.DAL.Repositories.Implementations;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
   public class ContratoBL : IContratoBL
    {
        public IEmpresaRepository empresaRepository { get; set; }
        public IStripe stripe { get; set; }
        public IMapper mapper { get; set; }
        public IContratoRepository contratoRepository { get; set; }
        public ContratoBL(IEmpresaRepository empresaRepository,IStripe stripe, IMapper mapper, IContratoRepository contratoRepository)
        {
            this.contratoRepository = contratoRepository;
            this.stripe = stripe;
            this.empresaRepository = empresaRepository;
            this.mapper = mapper;
            
        }
        public string CrearSuscripcionPremium(EmpresaDTO empresa)
        {          
            var e = empresaRepository.BuscarEmpresa(empresa.Id);
            if (e.empresaStripeID == null)
            {
                var customer = stripe.CrearEmpresEnStripe(e);
                e.empresaStripeID = customer.Id;
                empresaRepository.ActualizarEmpresa(e);
            }
          return  stripe.ComprarSuscripcionPremium(e.empresaStripeID).Result.Url;   
        }
        public DateTime FromUnixTimestampToDateTime(long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public List<ContratoDTO> ObtenerContratosPorEmpresaStripeId(string empresaStripeId)
        {
            List<ContratoDTO> list = mapper.Map<List<Contrato>, List<ContratoDTO>>(contratoRepository.ObtenerContratosPorEmpresaStripeId(empresaStripeId));
            return list;
        }
        public List<ContratoDTO> ObtenerContratosPorSuscripcionId(string suscripcionId)
        {
            List<ContratoDTO> list = mapper.Map<List<Contrato>, List<ContratoDTO>>(contratoRepository.ObtenerContratosPorSuscripcionId(suscripcionId));
            return list;
        }

        public List<ContratoDTO> ObtenerContratosPorEmpresaId(int empresaId)
        {
            List<ContratoDTO> list = mapper.Map<List<Contrato>, List<ContratoDTO>>(contratoRepository.ObtenerContratosPorEmpresaId(empresaId));
            return list;
        }

        public ContratoDTO ObtenerContratoPorEmpresaYSuscripcionId(int empresaId, string suscripcionId)
        {
           ContratoDTO l = mapper.Map<Contrato, ContratoDTO>(contratoRepository.ObtenerContratoPorEmpresaYSuscripcionId(empresaId,suscripcionId));
            return l;
        }

        public ContratoDTO InsertarContrato(CrearContratoDTO contrato)
        {
            var cincoming = mapper.Map<CrearContratoDTO, Contrato>(contrato);
            return mapper.Map<Contrato, ContratoDTO>(contratoRepository.InsertarContrato(cincoming));
        }

        public bool BorrarContrato(int idContrato)
        {
            return contratoRepository.BorrarContrato(idContrato);
        }

        public ContratoDTO ExistContrato(int idContrato)
        {
            return mapper.Map<Contrato, ContratoDTO>(contratoRepository.ExistContrato(idContrato));
        }
    }
}
