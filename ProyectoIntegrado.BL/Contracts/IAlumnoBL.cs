using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IAlumnoBL
    {
        public bool Login(AlumnoLoginDTO alumnoDTO);
        public bool CreateAlumno(AlumnoDTO alumnoDTO);
        public bool Exists(AlumnoDTO alumno);
        List<AlumnoDTO> ObtenerAlumnos();
        bool BorrarAlumno(AlumnoDTO alumno);
        AlumnoDTO BuscarAlumno(int id);
        AlumnoDTO ActualizarAlumno(AlumnoDTO alumno);
    }
}
