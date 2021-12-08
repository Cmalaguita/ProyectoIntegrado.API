using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    class PosicionDeTrabajoRepository : IPosicionDeTrabajoRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public PosicionDeTrabajoRepository(proyectointegradodbContext context)
        {
            this._context = context;
        }
        public bool ActualizarPosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajo)
        {
            if (Exists(posicionDeTrabajo))
            {
                _context.Posiciones.Update(posicionDeTrabajo);
                return true;
            }
            return false;
        }

        public bool BorrarPosicion(PosicionDeTrabajoDTO posicionDeTrabajo)
        {
            if (Exists(posicionDeTrabajo))
            {
                _context.Posiciones.Remove(posicionDeTrabajo);
                return true;
            }
            return false;
        }

        public PosicionDeTrabajoDTO CreatePosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajo)
        {
             var p = _context.Posiciones.Add(posicionDeTrabajo);
            _context.SaveChanges();
            return p.Entity;
        }

        public bool Exists(PosicionDeTrabajoDTO posicionDeTrabajo)
        {
            return _context.Posiciones.Any(p=> p.EmpresaId == posicionDeTrabajo.EmpresaId && p.Nombre == posicionDeTrabajo.Nombre);
        }

        public List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo()
        {
            return _context.Posiciones.ToList();
        }

        public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoActivasHoy()
        {
            return _context.Posiciones.Where(p => p.FechaFin > DateTime.Now && p.FechaInicio <= DateTime.Now).ToList();
        }

        public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorNombre(string nombre)
        {
            return _context.Posiciones.Where(p => p.Nombre.Equals(nombre)).ToList();
        }
    }
}
