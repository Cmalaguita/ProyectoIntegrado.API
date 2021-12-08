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

        public Alumno CreateAlumno(Alumno alumno)
        {
           var a=_context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return a.Entity;
        }

        public bool Exists(Alumno alumno)
        {
            return _context.Alumnos.Any(a => a.Email == alumno.Email);
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return _context.Alumnos.ToList();
        }

        public bool BorrarAlumno(Alumno alumno)
        {
            if (Exists(alumno))
            {
            _context.Alumnos.Remove(alumno);
                return true;
            }
            return false;
        }

        public Alumno BuscarAlumno(string email)
        {
            return _context.Alumnos.Where(a => a.Email == email).FirstOrDefault();
        }

        public bool ActualizarAlumno(Alumno alumno)
        {
            if (Exists(alumno))
            {
            _context.Alumnos.Update(alumno);
                return true;
            }
            return false;
        }
    }
}
