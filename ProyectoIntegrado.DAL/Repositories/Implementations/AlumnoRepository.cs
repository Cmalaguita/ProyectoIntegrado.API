using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
   public class AlumnoRepository : IAlumnoRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public AlumnoRepository(proyectointegradodbContext context)
            {
            this._context = context;
            }
        public bool Login(Alumno alumno)
        {
           return _context.Alumnos.Any(u => u.Email == alumno.Email && u.Password ==alumno.Password);
        }

        public bool CreateAlumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(Alumno alumno)
        {
            return _context.Alumnos.Any(a => a.Id == alumno.Id);
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return _context.Alumnos.Include("Provincia").ToList();
        }

        public bool BorrarAlumno(Alumno alumno)
        {
            if (Exists(alumno))
            {
            _context.Alumnos.Remove(alumno);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Alumno BuscarAlumno(int id)
        {
            return _context.Alumnos.Where(a => a.Id == id).Include("Provincia").FirstOrDefault();
        }

        public Alumno ActualizarAlumno(Alumno alumno)
        {
            if (Exists(alumno))
            {
                var a = _context.Alumnos.Update(alumno).Entity;
                _context.SaveChanges();
                return a;          
            }
            return null;
        }
    }
}
