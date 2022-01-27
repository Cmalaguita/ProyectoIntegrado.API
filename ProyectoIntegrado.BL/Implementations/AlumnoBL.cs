using AutoMapper;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Email;
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
        public IEmailSender emailSender { get; set; }
        public AlumnoBL(IAlumnoRepository alumnoRepository, IPasswordGenerator passwordGenerator,IMapper mapper,IEmailSender emailSender)
        {
            this.emailSender = emailSender;
            this.alumnoRepository = alumnoRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
        }
        public AlumnoDTO Login(AlumnoLoginDTO alumnoLoginDTO)
        {

            alumnoLoginDTO.Password = passwordGenerator.Hash(alumnoLoginDTO.Password);
            if (alumnoLoginDTO!=null)
            {
            var a = alumnoRepository.Login(mapper.Map<AlumnoLoginDTO, Alumno>(alumnoLoginDTO));

                var aDTO = mapper.Map<Alumno, AlumnoDTO>(a);
            return aDTO;
            }
            else
            {
                return null;
            }
        }

        public bool CreateAlumno(AlumnoSignUpDTO alumnoSignUpDTO)
        {
            alumnoSignUpDTO.Password = passwordGenerator.Hash(alumnoSignUpDTO.Password);
            var alumno = mapper.Map<AlumnoSignUpDTO, Alumno>(alumnoSignUpDTO);
           
            if (!alumnoRepository.Exists(alumno))
            {
                    var a= alumnoRepository.CreateAlumno(alumno);
                emailSender.Send(alumno.Email);
                return a;
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

        public AlumnoDTO ActualizarAlumno(AlumnoUpdateDTO alumno)
        {
            
            
            var a = mapper.Map<AlumnoUpdateDTO, Alumno>(alumno);

               AlumnoDTO actualizado=mapper.Map<Alumno,AlumnoDTO>(alumnoRepository.ActualizarAlumno(a));
            return actualizado;
        }

        public void GenerarCodigo(string email)
        {

            Random r = new Random();
            var a =alumnoRepository.ExistsUnicamenteEmail(email);

            if (a != null)
            {
                a.CodigoVerificacion = null;
                for (int i = 0; i < 6; i++)
                {

                    a.CodigoVerificacion += r.Next(10).ToString();
                }
                alumnoRepository.ActualizarAlumno(a);
                emailSender.SendCodePass(a.Email, "Su codigo de verificacion es el siguiente: " + a.CodigoVerificacion);
            }
        }

        public bool CompararCodigo(string email, string codigo)
        {
            return alumnoRepository.CompararCodigo(email,codigo);
        }

        public bool CompararCodigoParaEmail(string codigo, string email)
        {
            return alumnoRepository.CompararCodigoParaEmail(codigo, email);
        }

        public bool CambiarPassAlumno(string pass, string email)
        {
            pass = passwordGenerator.Hash(pass);
            return alumnoRepository.CambiarPassAlumno(pass,email);
        }

        public AlumnoDTO ExistsUnicamenteEmail(string email)
        {
            return mapper.Map<Alumno, AlumnoDTO>(alumnoRepository.ExistsUnicamenteEmail(email));
        }
    }
}
