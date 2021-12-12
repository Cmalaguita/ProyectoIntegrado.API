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
        public PosicionDeTrabajoRepository(proyectointegradodbContext context)
        {
            this._context = context;
        }
        public PosicionDeTrabajo ActualizarPosicionDeTrabajo(PosicionDeTrabajo posicionDeTrabajo)
        {
            if (Exists(posicionDeTrabajo))
            {
                    var p=_context.Posiciones.Update(posicionDeTrabajo).Entity;
                _context.SaveChanges();

                return p;
               
            }
            return null;
        }

        public bool BorrarPosicion(PosicionDeTrabajo posicionDeTrabajo)
        {
            if (Exists(posicionDeTrabajo))
            {
                _context.Posiciones.Remove(posicionDeTrabajo);
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
            return _context.Posiciones.Any(p=> p.EmpresaId == posicionDeTrabajo.EmpresaId && p.Nombre == posicionDeTrabajo.Nombre);
        }

        public List<PosicionDeTrabajo> ObtenerPosicionesDeTrabajo()
        {
            return _context.Posiciones.ToList();
        }

        public List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoActivasHoy()
        {
            return _context.Posiciones.Where(p => p.FechaFin > DateTime.Now && p.FechaInicio <= DateTime.Now).ToList();
        }

        public List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoPorNombre(string nombre)
        {
            return _context.Posiciones.Where(p => p.Nombre.Equals(nombre)).ToList();
        }

        public PosicionDeTrabajo BuscarPosicionDeTrabajoId(int id)
        {
            return _context.Posiciones.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
