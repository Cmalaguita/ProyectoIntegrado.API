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
        public bool Login(AlumnoLoginDTO alumnoLoginDTO)
        {
            alumnoLoginDTO.Password = passwordGenerator.Hash(alumnoLoginDTO.Password);

            var alumno = mapper.Map<AlumnoLoginDTO, Alumno>(alumnoLoginDTO);
            return alumnoRepository.Login(alumno);
        }

        public bool CreateAlumno(AlumnoDTO alumnoDTO)
        {
            alumnoDTO.Password = passwordGenerator.Hash(alumnoDTO.Password);
            var alumno = mapper.Map<AlumnoDTO, Alumno>(alumnoDTO);
           
            if (!alumnoRepository.Exists(alumno))
            {

                return alumnoRepository.CreateAlumno(alumno);

            }
            return false;
        }

        public bool Exists(AlumnoDTO alumno)
        {

            var a = mapper.Map<AlumnoDTO, Alumno>(alumno);
            return alumnoRepository.Exists(a);
        }

        public List<AlumnoDTO> ObtenerAlumnos()
        {
              List<AlumnoDTO> list = mapper.Map<List<Alumno>,List<AlumnoDTO>>(alumnoRepository.ObtenerAlumnos());
            return list;
        }

        public bool BorrarAlumno(AlumnoDTO alumno)
        {
            var a = mapper.Map<AlumnoDTO, Alumno>(alumno);
            return alumnoRepository.BorrarAlumno(a);
        }

        public AlumnoDTO BuscarAlumno(int id)
        {
                var a= mapper.Map<Alumno,AlumnoDTO>(alumnoRepository.BuscarAlumno(id));
            return a;
        }

        public AlumnoDTO ActualizarAlumno(AlumnoDTO alumno)
        {
            alumno.Password = passwordGenerator.Hash(alumno.Password);
            
            var a = mapper.Map<AlumnoDTO, Alumno>(alumno);

               AlumnoDTO actualizado=mapper.Map<Alumno,AlumnoDTO>(alumnoRepository.ActualizarAlumno(a));
            return actualizado;
        }
    }
}
