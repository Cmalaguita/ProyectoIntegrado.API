using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
   public class PosicionDeTrabajoRepository : IPosicionDeTrabajoRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public ICicloRepository cicloRepository { get; set; }
        public PosicionDeTrabajoRepository(proyectointegradodbContext context, ICicloRepository cicloRepository)
        {
            this._context = context;
            this.cicloRepository = cicloRepository;
        }
        public PosicionDeTrabajo ActualizarPosicionDeTrabajo(PosicionDeTrabajo posicionDeTrabajo)
        {
            if (Exists(posicionDeTrabajo))
            {
                BorrarPosicion(posicionDeTrabajo);

                    var p=_context.Posiciones.Add(posicionDeTrabajo);

                _context.SaveChanges();
                

                return p.Entity;
               
            }
            return null;
        }

        public bool BorrarPosicion(PosicionDeTrabajo posicionDeTrabajo)
        {
            if (Exists(posicionDeTrabajo))
            {
                _context.Posiciones.Remove(BuscarPosicionDeTrabajoId(posicionDeTrabajo.Id));
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public PosicionDeTrabajo CreatePosicionDeTrabajo(PosicionDeTrabajo posicionDeTrabajo)
        {
             var p = _context.Posiciones.Add(posicionDeTrabajo);
            _context.SaveChanges();
            return p.Entity;
        }

        public bool Exists(PosicionDeTrabajo posicionDeTrabajo)
        {
            return _context.Posiciones.Any(p=> p.Id==posicionDeTrabajo.Id);
        }

        public List<PosicionDeTrabajo> ObtenerPosicionesDeTrabajo()
        {
           
            
            return _context.Posiciones
                .Include(c => c.Ciclos)
                .ThenInclude(c=>c.TipoCiclo)
                 .Include(c => c.Ciclos)
                .ThenInclude(c => c.familia)
                .Include(c => c.Empresa)
                .ThenInclude(c => c.Provincia)
                .ToList();
        }

        public List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoActivasHoy()
        {
            return _context.Posiciones.Where(p => p.FechaFin > DateTime.Now && p.FechaInicio <= DateTime.Now)
                .Include(c => c.Ciclos)
                .ThenInclude(c => c.TipoCiclo)
                 .Include(c => c.Ciclos)
                .ThenInclude(c => c.familia)
                .Include(c => c.Empresa)
                .ThenInclude(c => c.Provincia)
                .ToList();
            //return _context.Posiciones.Where(p => p.FechaFin > DateTime.Now && p.FechaInicio <= DateTime.Now).Include(c=>c.Ciclos).Include(c => c.Empresa).ToList();
        }

        public List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoPorNombre(string nombre)
        {
            return _context.Posiciones.Where(p => p.Nombre.Equals(nombre))
               .Include(c => c.Ciclos)
               .ThenInclude(c => c.TipoCiclo)
                .Include(c => c.Ciclos)
               .ThenInclude(c => c.familia)
               .Include(c => c.Empresa)
               .ThenInclude(c => c.Provincia)
               .ToList();
            //return _context.Posiciones.Where(p => p.Nombre.Equals(nombre)).Include(c => c.Ciclos).Include(c => c.Empresa).ToList();
        }

        public PosicionDeTrabajo BuscarPosicionDeTrabajoId(int id)
        {
            return _context.Posiciones.Where(p => p.Id == id)
                .Include(c => c.Ciclos)
                .ThenInclude(c => c.TipoCiclo)
                 .Include(c => c.Ciclos)
                .ThenInclude(c => c.familia)
                .Include(c => c.Empresa)
                .ThenInclude(c => c.Provincia)
                .FirstOrDefault();
            //return _context.Posiciones.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
