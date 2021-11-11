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
    }
}
