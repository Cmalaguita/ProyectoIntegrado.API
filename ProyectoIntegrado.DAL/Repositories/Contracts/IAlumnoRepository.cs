using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IAlumnoRepository
    {
        bool Login(Alumno a);
        Alumno CreateAlumno(Alumno alumno);
        bool Exists(Alumno usuario);
    }
}
