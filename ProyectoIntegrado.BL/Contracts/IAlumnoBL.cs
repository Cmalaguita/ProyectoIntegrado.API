﻿using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IAlumnoBL
    {
        public bool Login(AlumnoDTO alumnoDTO);
        public AlumnoDTO CreateAlumno(AlumnoDTO alumnoDTO);
        public bool Exists(AlumnoDTO alumno);
        List<AlumnoCompletoDTO> ObtenerAlumnos();
        bool BorrarAlumno(AlumnoCompletoDTO alumno);
        AlumnoCompletoDTO BuscarAlumno(string email);
        bool ActualizarAlumno(AlumnoCompletoDTO alumno);
    }
}
