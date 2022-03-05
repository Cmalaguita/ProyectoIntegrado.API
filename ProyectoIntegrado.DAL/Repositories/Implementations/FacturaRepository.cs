using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class FacturaRepository : IFacturaRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public FacturaRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public bool BorrarFactura(int idFactura)
        {
            var f = ExistFactura(idFactura);
            if (f!=null)
            {
                _context.Facturas.Remove(f);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ComprobarFacturaPagada(int idFactura)
        {
            var f = ExistFactura(idFactura);
            if (f.fechaPago!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Factura ExistFactura(int idFactura)
        {
            return _context.Facturas.Where(f => f.id==idFactura).Include(f => f.contrato).ThenInclude(c => c.empresa).FirstOrDefault();
        }

        public Factura InsertarFactura(Factura factura)
        {
            if (factura!=null)
            {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
            return _context.Facturas.Where(f=>f==factura).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public List<Factura> ObtenerFacturasPorContratoId(int contratoId)
        {
           return _context.Facturas.Where(f => f.idContrato == contratoId).Include(f => f.contrato).ThenInclude(c => c.empresa).ToList();
        }

        public List<Factura> ObtenerFacturasPorEmpresaId(int empresaId)
        {
            return _context.Facturas.Where(f => f.idEmpresa == empresaId).Include(f => f.contrato).ThenInclude(c => c.empresa).ToList();
        }

        public List<Factura> ObtenerFacturasPorEmpresaYContratoId(int empresaId, int contratoId)
        {
            return _context.Facturas.Where(f => f.idEmpresa == empresaId && f.idContrato==contratoId).Include(f => f.contrato).ThenInclude(c => c.empresa).ToList();
        }

        public List<Factura> ObtenerFacturasPorSuscripcionId(string suscripcionId)
        {
            return _context.Facturas.Where(f => f.suscripcionId ==suscripcionId).Include(f => f.contrato).ThenInclude(c => c.empresa).ToList();
        }

        public List<Factura> ObtenerFacturasPorSuscripcionYContratoId(string suscripcionId, int contratoId)
        {
            return _context.Facturas.Where(f => f.suscripcionId == suscripcionId && f.idContrato==contratoId).Include(f=>f.contrato).ThenInclude(c=>c.empresa).ToList();
        }

        public Factura ActualizarFactura(Factura factura)
        {
            var f = ExistFactura(factura.id);
            if (f!=null)
            {
                _context.Facturas.Update(factura);
                _context.SaveChanges();
                f = ExistFactura(factura.id);
                return f;
            }
            return null;
        }

        public Factura ObtenerFacturaPagadaMasReciente(int empresaId)
        {
            return _context.Facturas.Where(f => f.idEmpresa==empresaId && f.fechaCreacion < DateTime.Now && f.fechaFin > DateTime.Now && f.fechaPago != null).Include(f=>f.empresa).Include(f=>f.contrato).FirstOrDefault();
        }
    }
}
