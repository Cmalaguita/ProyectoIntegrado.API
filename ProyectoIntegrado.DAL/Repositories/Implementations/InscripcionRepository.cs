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
        public bool BorrarInscripcion(int id)
        {
            if (Exists(id))
            {
                var i = _context.Inscripciones.First(i => i.Id == id);
                _context.Inscripciones.Remove(i);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Inscripcion CreateInscripcion(Inscripcion inscripcion)
        {
            var a = _context.Inscripciones.Add(inscripcion).Entity;
            _context.SaveChanges();

            return _context.Inscripciones.Where(i=>i.Id==a.Id).Include(i=>i.Empresa).ThenInclude(e=>e.Provincia).Include(i=>i.alumno).ThenInclude(a=>a.Provincia).Include(i=>i.alumno).ThenInclude(a=>a.Provincia).Include(i=>i.alumno).ThenInclude(a=>a.ciclo).FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return _context.Inscripciones.Any(i => i.Id == id);
        }

        public bool ExistsPorAlumnoYPosicion(int idP, int idA)
        {
            return _context.Inscripciones.Any(i => i.AlumnoId == idA && i.PosicionId==idP);
        }

        public List<Inscripcion> ObtenerInscripciones()
        {
            return _context.Inscripciones.Include(i => i.alumno).Include(i => i.Empresa).Include(i => i.Posicion).ToList();
        }

        public List<Inscripcion> ObtenerInscripcionesPorFamilia(int id)
        {
            return _context.Inscripciones.Where(i => i.Posicion.Ciclos.Any(c => c.IdFamilia == id)).Include(i => i.Empresa).ThenInclude(e => e.Provincia).Include(i => i.alumno).ThenInclude(a => a.Provincia).Include(i => i.alumno).ThenInclude(a => a.ciclo).ThenInclude(c => c.familia).Include(i => i.alumno).ThenInclude(a => a.ciclo).ThenInclude(c => c.Tipociclo).Include(i => i.Posicion).ToList();
        }

        public List<Inscripcion> ObtenerInscripcionesPorCiclo(int id)
        {
            return _context.Inscripciones.Where(i => i.Posicion.Ciclos.Any(c => c.Id == id)).Include(i => i.Empresa).ThenInclude(e => e.Provincia).Include(i => i.alumno).ThenInclude(a => a.Provincia).Include(i => i.alumno).ThenInclude(a => a.ciclo).ThenInclude(c => c.familia).Include(i => i.alumno).ThenInclude(a => a.ciclo).ThenInclude(c => c.Tipociclo).Include(i => i.Posicion).ToList();

        }

        public List<Inscripcion> ObtenerInscripcionesPorEmpresa(int id)
        {
            var list = _context.Inscripciones.Where(i => i.EmpresaId == id)
                .Include(i => i.Empresa)
                .ThenInclude(e => e.Provincia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.Provincia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.ciclo)
                .ThenInclude(c => c.familia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.ciclo)
                .ThenInclude(c => c.Tipociclo)
                .Include(i => i.Posicion)
                .ToList();
            foreach (var item in list)
            {
                item.Empresa.Password = null;
                item.alumno.Password = null;
            }
            return list; 
        }
        public List<Inscripcion> ObtenerInscripcionesPorAlumno(int id)
        {
            var list = _context.Inscripciones.Where(i => i.AlumnoId == id)
                .Include(i => i.Empresa)
                .ThenInclude(e => e.Provincia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.Provincia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.ciclo)
                .ThenInclude(c => c.familia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.ciclo)
                .ThenInclude(c => c.Tipociclo)
                .Include(i => i.Posicion)
                .ToList();
            foreach (var item in list)
            {
                item.Empresa.Password = null;
                item.alumno.Password = null;
            }
            
            return list;
        }
        public List<Inscripcion> ObtenerInscripcionesPorPosicion(int idPosicion)
        { 
            var list = _context.Inscripciones.Where(i => i.PosicionId == idPosicion)
           .Include(i => i.Empresa)
           .ThenInclude(e => e.Provincia)
           .Include(i => i.alumno)
           .ThenInclude(a => a.Provincia)
           .Include(i => i.alumno)
           .ThenInclude(a => a.ciclo)
           .ThenInclude(c => c.familia)
           .Include(i => i.alumno)
           .ThenInclude(a => a.ciclo)
           .ThenInclude(c => c.Tipociclo)
           .Include(i => i.Posicion)
           .ToList();
            foreach (var item in list)
            {
                item.Empresa.Password = null;
                item.alumno.Password = null;
            }
            return list;
        }
        public List<Alumno> ObtenerAlumnosEnInscripcionPorPosicion(int idPosicion)
        {
          var list=_context.Inscripciones
                .Include(i=>i.alumno)
                .ThenInclude(a => a.ciclo)
                .ThenInclude(c=>c.familia)
                .Include(i => i.alumno)
                .ThenInclude(a => a.ciclo)
                .ThenInclude(c => c.Tipociclo)
                .Include(i => i.alumno)
                .ThenInclude(a => a.Provincia)
                .Where(i => i.PosicionId == idPosicion)
                .Select(i => i.alumno)
                .ToList();
            foreach (var item in list)
            {
                item.Password = null;
            }
            return list;
        }
        public Inscripcion UpdateInscripcion(Inscripcion i)
        {
            Inscripcion ins;
            if (Exists(i.Id))
            {
             ins= _context.Update(i).Entity;
                _context.SaveChanges();
                return ins;
            }
            return null;
        }
    }
}
