using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class ContratoRepository : IContratoRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public ContratoRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public bool BorrarContrato(int idContrato)
        {
            var c = ExistContrato(idContrato);
            if (c != null)
            {
                _context.Contratos.Remove(c);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Contrato InsertarContrato(Contrato contrato)
        {
            if (contrato != null)
            {
                _context.Contratos.Add(contrato);
                _context.SaveChanges();
                return _context.Contratos.Where(f => f == contrato).Include(c=>c.empresa).ThenInclude(e=>e.Provincia).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public List<Contrato> ObtenerContratosPorEmpresaId(int empresaId)
        {
            return _context.Contratos.Where(c => c.idEmpresa == empresaId).Include(c => c.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public List<Contrato> ObtenerContratosPorEmpresaStripeId(string empresaStripeId)
        {
            return _context.Contratos.Where(c => c.empresaStripeId == empresaStripeId).Include(c => c.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public List<Contrato> ObtenerContratosPorEmpresaYSuscripcionId(int empresaId, string suscripcionId)
        {
            return _context.Contratos.Where(c => c.idEmpresa == empresaId && c.suscripcionId==suscripcionId).Include(c => c.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public List<Contrato> ObtenerContratosPorSuscripcionId(string suscripcionId)
        {
            return _context.Contratos.Where(c => c.suscripcionId == suscripcionId).Include(c => c.empresa).ThenInclude(e => e.Provincia).ToList();
        }

        public Contrato ExistContrato(int idContrato)
        {
            return _context.Contratos.Where(c => c.id == idContrato).Include(e => e.empresa).ThenInclude(c => c.Provincia).FirstOrDefault();

        }
    }
}
