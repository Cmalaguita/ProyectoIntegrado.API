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
        public int  Login(Alumno alumno)
        {
            if (ExistsEmail(alumno))
            {
                int id = _context.Alumnos.Where(a => a.Email == alumno.Email && a.Password== alumno.Password).FirstOrDefault().Id;
                return id;
            }
            else
            {

                return -1;
            }
        }

        public bool CreateAlumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return true;
        }
        public bool ExistsEmail(Alumno alumno)
        {
            return _context.Alumnos.Any(u => u.Email == alumno.Email);
        }
        public bool Exists(Alumno alumno)
        {
            return _context.Alumnos.Any(a => a.Id == alumno.Id);
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return _context.Alumnos.Include(a=> a.Provincia).Include(a => a.ciclo).ThenInclude(a=>a.Tipociclo).Include(a => a.ciclo).ThenInclude(a=>a.familia).ToList();
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
            var a= _context.Alumnos.Where(a => a.Id == id).Include(a=>a.Provincia).Include(a => a.ciclo).ThenInclude(a => a.Tipociclo).Include(a => a.ciclo).ThenInclude(a => a.familia).FirstOrDefault();
            a.Password = null;
            return a;
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
