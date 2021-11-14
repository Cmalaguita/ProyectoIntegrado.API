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
    public class EmpresaBL : IEmpresaBL
    {
        public IEmpresaRepository empresaRepository { get; set; }
        public IPasswordGenerator passwordGenerator  { get; set; }
        public IMapper mapper { get; set; }
        public EmpresaBL(IEmpresaRepository empresaRepository, IPasswordGenerator passwordGenerator, IMapper mapper)
        {
            this.empresaRepository = empresaRepository;
            this.passwordGenerator = passwordGenerator;
            this.mapper = mapper;
        }
        public EmpresaDTO Login(EmpresaDTO empresaDTO)
        {
            empresaDTO.Password = passwordGenerator.Hash(empresaDTO.Password);
            var empresa = mapper.Map<EmpresaDTO,Empresa>(empresaDTO);
            empresaDTO = mapper.Map<Empresa, EmpresaDTO>(empresaRepository.Login(empresa));
            if (empresaDTO!=null)
            {

            empresa.Password = null;
            }
            return empresaDTO;
        }

        public  EmpresaDTO CreateEmpresa(EmpresaDTO empresaDTO)
        {
            empresaDTO.Password = passwordGenerator.Hash(empresaDTO.Password);
            var empresa = new Empresa
            {
                Email = empresaDTO.Email,
                Password = empresaDTO.Password
            };
            if (!empresaRepository.Exists(empresa))
            {
             var e= mapper.Map <Empresa, EmpresaDTO>(empresaRepository.CreateEmpresa(empresa));
                e.Password = null;
                return e;
            }
            return null;
        }

        public bool Exists(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}
