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
        public bool Login(EmpresaDTO empresaDTO)
        {
            empresaDTO.Password = passwordGenerator.Hash(empresaDTO.Password);

            var empresa = mapper.Map<EmpresaDTO, Empresa>(empresaDTO);
            return empresaRepository.Login(empresa);
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

        public List<EmpresaCompletaDTO> ObtenerEmpresas()
        {
            throw new NotImplementedException();
        }

        public bool BorrarEmpresa(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public EmpresaCompletaDTO BuscarEmpresa(string email)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarEmpresa(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}
