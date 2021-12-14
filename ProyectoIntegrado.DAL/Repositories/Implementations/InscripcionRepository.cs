using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    public class InscripcionRepository : IInscripcionRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public InscripcionRepository(proyectointegradodbContext _context)
        {
            this._context = _context;
        }
        public bool BorrarInscripcion(Inscripcion inscripcion)
        {
            if (Exists(inscripcion))
            {
                _context.Inscripciones.Remove(inscripcion);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Inscripcion CreateInscripcion(Inscripcion inscripcion)
        {
            var i=_context.Inscripciones.Add(inscripcion).Entity;
            _context.SaveChanges();
            return i;
        }

        public bool Exists(Inscripcion inscripcion)
        {
           return _context.Inscripciones.Any(i=> i.Id==inscripcion.Id);
        }

        public List<Inscripcion> ObtenerInscripciones()
        {
            return _context.Inscripciones.Include(i=>i.alumno).Include(i=>i.Empresa).Include(i=>i.Posicion).ToList();
        }
    }
}
