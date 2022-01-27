using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IAlumnoBL
    {
        public AlumnoDTO Login(AlumnoLoginDTO alumnoDTO);
        public bool CreateAlumno(AlumnoSignUpDTO alumnoDTO);
        public bool Exists(AlumnoDTO alumnoDTO);
        List<AlumnoDTO> ObtenerAlumnos();
        bool BorrarAlumno(AlumnoDTO alumnoDTO);
        AlumnoDTO BuscarAlumno(int id);
        AlumnoDTO ActualizarAlumno(AlumnoUpdateDTO alumnoDTO);
        public void GenerarCodigo(string email);
        AlumnoDTO ExistsUnicamenteEmail(string email);
        bool CompararCodigo(string email, string codigo);
        bool CompararCodigoParaEmail(string codigo, string email);
        public bool CambiarPassAlumno(string pass, string email);
    }
}
