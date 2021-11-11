
using ProyectoIntegrado.DAL.Entities;


namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IAlumnoRepository
    {
        bool Login(Alumno a);
        Alumno CreateAlumno(Alumno alumno);
        bool Exists(Alumno usuario);
    }
}
