using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IAlumnoBL
    {
        public int Login(AlumnoLoginDTO alumnoDTO);
        public bool CreateAlumno(AlumnoSignUpDTO alumnoDTO);
        public bool Exists(AlumnoDTO alumnoDTO);
        List<AlumnoDTO> ObtenerAlumnos();
        bool BorrarAlumno(AlumnoDTO alumnoDTO);
        AlumnoDTO BuscarAlumno(int id);
        AlumnoDTO ActualizarAlumno(AlumnoDTO alumnoDTO);
    }
}
