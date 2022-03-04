using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
   public interface IFacturaRepository
    {
        List<Factura> ObtenerFacturasPorEmpresaId(int empresaId);
        bool ObtenerFacturaPagadaMasReciente(int empresaId);
        List<Factura> ObtenerFacturasPorContratoId(int contratoId);
        List<Factura> ObtenerFacturasPorSuscripcionId(string suscripcionId);
        List<Factura> ObtenerFacturasPorEmpresaYContratoId(int empresaId,int contratoId);
        List<Factura> ObtenerFacturasPorSuscripcionYContratoId(string suscripcionId, int contratoId);
        Factura InsertarFactura(Factura factura);
        bool BorrarFactura(int idFactura);
        bool ComprobarFacturaPagada(int idFactura);
        Factura ExistFactura(int idFactura);
        Factura ActualizarFactura(Factura factura);
    }
}
