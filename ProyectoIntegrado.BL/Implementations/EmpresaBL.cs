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
    public class EmpresaBL : IEmpresaBL
    {
        public IEmpresaRepository empresaRepository { get; set; }
        public IPasswordGenerator passwordGenerator  { get; set; }
        public IMapper mapper { get; set; }
        public IEmailSender emailSender { get; set; }
        public IAlumnoRepository alumnoRepository { get; set; }
        public EmpresaBL(IEmpresaRepository empresaRepository, IPasswordGenerator passwordGenerator, IMapper mapper, IEmailSender emailSender, IAlumnoRepository alumnoRepository)
        {
            this.empresaRepository = empresaRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
            this.emailSender = emailSender;
            this.alumnoRepository = alumnoRepository;
        }
        public EmpresaDTO Login(EmpresaLoginDTO empresaLoginDTO)
        {
            empresaLoginDTO.Password = passwordGenerator.Hash(empresaLoginDTO.Password);
            if (empresaLoginDTO!=null)
            {
            var empresa = empresaRepository.Login(mapper.Map<EmpresaLoginDTO, Empresa>(empresaLoginDTO));
                var eDTO = mapper.Map<Empresa, EmpresaDTO>(empresa);
            return eDTO;
            }
            else
            {
                return null;
            }
        }

        public  EmpresaDTO CreateEmpresa(EmpresaSignUpDTO empresaSignUpDTO)
        {         
            empresaSignUpDTO.Password = passwordGenerator.Hash(empresaSignUpDTO.Password);
            var empresa = mapper.Map<EmpresaSignUpDTO, Empresa>(empresaSignUpDTO);
            if (!empresaRepository.Exists(empresa))
            {
             var e= mapper.Map<Empresa,EmpresaDTO>(empresaRepository.CreateEmpresa(empresa));
                
                return e;
            }
            return null;
        }

        public bool Exists(EmpresaDTO empresa)
        {
            var a = mapper.Map<EmpresaDTO, Empresa>(empresa);
            return empresaRepository.Exists(a);
        }



        public List<EmpresaDTO> ObtenerEmpresas()
        {
            List<EmpresaDTO> list = mapper.Map<List<Empresa>, List<EmpresaDTO>>(empresaRepository.ObtenerEmpresas());
            return list;
        }

        public bool BorrarEmpresa(EmpresaDTO empresa)
        {
            var e = mapper.Map<EmpresaDTO, Empresa>(empresa);
            return empresaRepository.BorrarEmpresa(e);
        }

        public EmpresaDTO BuscarEmpresa(int id)
        {
            var a = mapper.Map<Empresa, EmpresaDTO>(empresaRepository.BuscarEmpresa(id));
            return a;
        }

        public EmpresaDTO ActualizarEmpresa(EmpresaUpdateDTO empresa)
        {
            if (empresaRepository.ExistsUnicamenteEmail(empresa.Email)!=null)
            {

            var e = mapper.Map<EmpresaUpdateDTO, Empresa>(empresa);
            EmpresaDTO actualizado = mapper.Map<Empresa, EmpresaDTO>(empresaRepository.ActualizarEmpresa(e));
            return actualizado;
            }
            else
            {
                return null;
            }
         
        }

        public void GenerarCodigo(string email)
        {
            Random r = new Random();
            var e = empresaRepository.ExistsUnicamenteEmail(email);

            if (e != null)
            {
                e.CodigoVerificacion = null;
                for (int i = 0; i < 6; i++)
                {

                    e.CodigoVerificacion += r.Next(10).ToString();
                }
                empresaRepository.ActualizarEmpresa(e);
                emailSender.SendCodePass(e.Email, "Su codigo de verificacion es el siguiente: " + e.CodigoVerificacion);
            }
        }

        public bool CompararCodigo(string email, string codigo)
        {
           return empresaRepository.CompararCodigo(email,codigo);
        }

        public bool CompararCodigoParaEmail(string codigo, string email)
        {
            return empresaRepository.CompararCodigoParaEmail(codigo,email);
        }

        public bool CambiarPassEmpresa(string pass, string email)
        {
            pass = passwordGenerator.Hash(pass);
            return empresaRepository.CambiarPassEmpresa(pass,email);
        }

        public bool SendContact(string emailDestino, string mensaje, string nombrePosicion, string nombreEmpresa, string emailEmpresa)
        {
            var a = alumnoRepository.ExistsUnicamenteEmail(emailDestino);
            if (a!=null)
            {
                emailSender.SendContact(emailDestino, mensaje, nombrePosicion, nombreEmpresa, emailEmpresa);
                return true;
            }
            else
            {
                return false;
            }
        }

        public EmpresaDTO ExistsUnicamenteEmail(string email)
        {
          return  mapper.Map<Empresa,EmpresaDTO>( empresaRepository.ExistsUnicamenteEmail(email));
        }
    }
}
