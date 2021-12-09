
using ProyectoIntegrado.DAL.Entities;
using System.Collections.Generic;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IAlumnoRepository
    {
        bool Login(Alumno a);
        bool CreateAlumno(Alumno alumno);
        bool Exists(Alumno usuario);
        List<Alumno> ObtenerAlumnos();
        bool BorrarAlumno(Alumno alumno);
        Alumno BuscarAlumno(int id);
        Alumno ActualizarAlumno(Alumno alumno);
    }
}
