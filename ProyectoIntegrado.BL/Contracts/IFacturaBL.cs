using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
    public interface IFacturaBL
    {
        List<FacturaDTO> ObtenerFacturasPorEmpresaId(int empresaId);
        List<FacturaDTO> ObtenerFacturasPorContratoId(int contratoId);
        List<FacturaDTO> ObtenerFacturasPorSuscripcionId(string suscripcionId);
        List<FacturaDTO> ObtenerFacturasPorEmpresaYContratoId(int empresaId, int contratoId);
        List<FacturaDTO> ObtenerFacturasPorSuscripcionYContratoId(string suscripcionId, int contratoId);
        FacturaDTO InsertarFactura(CrearFacturaDTO factura);
        bool BorrarFactura(int idFactura);
        bool ComprobarFacturaPagada(int idFactura);
        FacturaDTO ExistFactura(int idFactura);
        FacturaDTO ActualizarFactura(FacturaDTO factura);
    }
}
