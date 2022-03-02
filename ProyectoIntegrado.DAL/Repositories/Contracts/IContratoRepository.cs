using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
   public interface IContratoRepository
    {
        List<Contrato> ObtenerContratosPorEmpresaStripeId(string empresaStripeId);
        List<Contrato> ObtenerContratosPorSuscripcionId(string suscripcionId);
        List<Contrato> ObtenerContratosPorEmpresaId(int empresaId);
        Contrato ObtenerContratoPorEmpresaYSuscripcionId(int empresaId,string suscripcionId);
        Contrato InsertarContrato(Contrato contrato);
        bool BorrarContrato(int idContrato);
        Contrato ExistContrato(int idContrato);
    }
}
