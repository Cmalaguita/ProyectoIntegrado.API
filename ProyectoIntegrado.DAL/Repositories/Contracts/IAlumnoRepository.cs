
using ProyectoIntegrado.DAL.Entities;
using System.Collections.Generic;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IAlumnoRepository
    {
        Alumno Login(Alumno a);
        bool CreateAlumno(Alumno alumno);
        bool Exists(Alumno usuario);
        List<Alumno> ObtenerAlumnos();
        bool BorrarAlumno(Alumno alumno);
        Alumno BuscarAlumno(int id);
        Alumno ExistsUnicamenteEmail(string email);
        Alumno ActualizarAlumno(Alumno alumno);
        bool CompararCodigo(string email,string codigo);
        bool CompararCodigoParaEmail(string codigo,string email);
        bool CambiarPassAlumno(string pass, string email);
        Alumno CambiarImagenAlumno(Alumno alumno);
    }
}
