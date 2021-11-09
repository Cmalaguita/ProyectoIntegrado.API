using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Security;
using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
    public class AlumnoBL : IAlumnoBL
    {
        public IAlumnoRepository alumnoRepository { get; set; }
        public IPasswordGenerator passwordGenerator { get; set; }
        public AlumnoBL(IAlumnoRepository alumnoRepository, IPasswordGenerator passwordGenerator)
        {
            this.alumnoRepository = alumnoRepository;
            this.passwordGenerator = passwordGenerator;
        }
        public bool Login(AlumnoDTO alumnoDTO)
        {
            alumnoDTO.Password = passwordGenerator.Hash(alumnoDTO.Password);

            var alumno = new Alumno
            {
                Email = alumnoDTO.Email,
                Password = alumnoDTO.Password
            };
            return alumnoRepository.Login(alumno);
        }

        public AlumnoDTO CreateAlumno(AlumnoDTO alumnoDTO)
        {
            var alumno = new Alumno
            {
                Email = alumnoDTO.Email,
                Password = alumnoDTO.Password
            };
            if (!alumnoRepository.Exists(alumno))
            {
             var a= alumnoRepository.CreateAlumno(alumno);
            var alumnoDTOCreado = new AlumnoDTO
            {
                Email = a.Email,
                Password = a.Password
            };
                return alumnoDTOCreado;
            }
            return null;
        }

        public bool Exists(Alumno alumno)
        {
            throw new NotImplementedException();
        }
    }
}
