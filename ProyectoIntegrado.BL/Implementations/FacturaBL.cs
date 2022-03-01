using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
  public  class FacturaBL:IFacturaBL
    {
        public IFacturaRepository facturaRepository { get; set; }
        public FacturaBL(IFacturaRepository facturaRepository)
        {
            this.facturaRepository = facturaRepository;
        }

        public List<FacturaDTO> ObtenerFacturasPorEmpresaId(int empresaId)
        {
            throw new NotImplementedException();
        }

        public List<FacturaDTO> ObtenerFacturasPorContratoId(int contratoId)
        {
            throw new NotImplementedException();
        }

        public List<FacturaDTO> ObtenerFacturasPorSuscripcionId(string suscripcionId)
        {
            throw new NotImplementedException();
        }

        public List<FacturaDTO> ObtenerFacturasPorEmpresaYContratoId(int empresaId, int contratoId)
        {
            throw new NotImplementedException();
        }

        public List<FacturaDTO> ObtenerFacturasPorSuscripcionYContratoId(string suscripcionId, int contratoId)
        {
            throw new NotImplementedException();
        }

        public FacturaDTO InsertarFactura(CrearFacturaDTO factura)
        {
            throw new NotImplementedException();
        }

        public bool BorrarFactura(int idFactura)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarFacturaPagada(int idFactura)
        {
            throw new NotImplementedException();
        }

        public FacturaDTO ExistFactura(int idFactura)
        {
            throw new NotImplementedException();
        }

        public FacturaDTO ActualizarFactura(FacturaDTO factura)
        {
            throw new NotImplementedException();
        }
    }
}
