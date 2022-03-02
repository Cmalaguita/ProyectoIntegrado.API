using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
  public  class FacturaBL:IFacturaBL
    {
        public IMapper mapper { get; set; }
        public IFacturaRepository facturaRepository { get; set; }
        public FacturaBL(IFacturaRepository facturaRepository, IMapper mapper)
        {
            this.facturaRepository = facturaRepository;
            this.mapper = mapper;
        }

        public List<FacturaDTO> ObtenerFacturasPorEmpresaId(int empresaId)
        {
            List<FacturaDTO> list = mapper.Map<List<Factura>, List<FacturaDTO>>(facturaRepository.ObtenerFacturasPorEmpresaId(empresaId));
            return list;
        }

        public List<FacturaDTO> ObtenerFacturasPorContratoId(int contratoId)
        {
            List<FacturaDTO> list = mapper.Map<List<Factura>, List<FacturaDTO>>(facturaRepository.ObtenerFacturasPorContratoId(contratoId));
            return list;
        }

        public List<FacturaDTO> ObtenerFacturasPorSuscripcionId(string suscripcionId)
        {
            List<FacturaDTO> list = mapper.Map<List<Factura>, List<FacturaDTO>>(facturaRepository.ObtenerFacturasPorSuscripcionId(suscripcionId));
            return list;
        }

        public List<FacturaDTO> ObtenerFacturasPorEmpresaYContratoId(int empresaId, int contratoId)
        {
            List<FacturaDTO> list = mapper.Map<List<Factura>, List<FacturaDTO>>(facturaRepository.ObtenerFacturasPorEmpresaYContratoId(empresaId,contratoId));
            return list;
        }

        public List<FacturaDTO> ObtenerFacturasPorSuscripcionYContratoId(string suscripcionId, int contratoId)
        {
            List<FacturaDTO> list = mapper.Map<List<Factura>, List<FacturaDTO>>(facturaRepository.ObtenerFacturasPorSuscripcionYContratoId(suscripcionId,contratoId));
            return list;
        }

        public FacturaDTO InsertarFactura(CrearFacturaDTO factura)
        {
            var fincoming = mapper.Map<CrearFacturaDTO, Factura>(factura);
            FacturaDTO f = mapper.Map<Factura,FacturaDTO>(facturaRepository.InsertarFactura(fincoming));
            return f;
        }

        public bool BorrarFactura(int idFactura)
        {
            return facturaRepository.BorrarFactura(idFactura);
        }

        public bool ComprobarFacturaPagada(int idFactura)
        {
            return facturaRepository.ComprobarFacturaPagada(idFactura);
        }

        public FacturaDTO ExistFactura(int idFactura)
        {
                var f = mapper.Map<Factura,FacturaDTO>(facturaRepository.ExistFactura(idFactura));
            return f;
        }

        public FacturaDTO ActualizarFactura(FacturaDTO factura)
        {
            var fincoming= mapper.Map<FacturaDTO, Factura>(factura);
           return mapper.Map<Factura, FacturaDTO>(facturaRepository.ActualizarFactura(fincoming));
        }
    }
}
