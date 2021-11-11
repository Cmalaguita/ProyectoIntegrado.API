using AutoMapper;
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
        public IMapper mapper { get; set; }
        public AlumnoBL(IAlumnoRepository alumnoRepository, IPasswordGenerator passwordGenerator,IMapper mapper)
        {
            this.alumnoRepository = alumnoRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
        }
        public bool Login(AlumnoDTO alumnoDTO)
        {
            alumnoDTO.Password = passwordGenerator.Hash(alumnoDTO.Password);

            var alumno = mapper.Map<AlumnoDTO, Alumno>(alumnoDTO);
            return alumnoRepository.Login(alumno);
        }

        public AlumnoDTO CreateAlumno(AlumnoDTO alumnoDTO)
        {
            alumnoDTO.Password = passwordGenerator.Hash(alumnoDTO.Password);
            var alumno = mapper.Map<AlumnoDTO, Alumno>(alumnoDTO);
           
            if (!alumnoRepository.Exists(alumno))
            {
                var u = mapper.Map<Alumno, AlumnoDTO>(alumnoRepository.CreateAlumno(alumno));
                u.Password = null;
                return u;
            }
            return null;
        }

        public bool Exists(Alumno alumno)
        {
            throw new NotImplementedException();
        }
    }
}
