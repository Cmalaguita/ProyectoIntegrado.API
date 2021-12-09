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
        public bool Login(EmpresaDTO empresaCompletaDTO)
        {
            empresaCompletaDTO.Password = passwordGenerator.Hash(empresaCompletaDTO.Password);

            var empresa = mapper.Map<EmpresaDTO, Empresa>(empresaCompletaDTO);
            return empresaRepository.Login(empresa);
        }

        public  bool CreateEmpresa(EmpresaDTO empresaCompletaDTO)
        {
            empresaCompletaDTO.Password = passwordGenerator.Hash(empresaCompletaDTO.Password);
            var empresa = mapper.Map<EmpresaDTO, Empresa>(empresaCompletaDTO);

            if (!empresaRepository.Exists(empresa))
            {
             var e= empresaRepository.CreateEmpresa(empresa);
                
                return e;
            }
            return false;
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

        public EmpresaDTO ActualizarEmpresa(EmpresaDTO empresa)
        {
            empresa.Password = passwordGenerator.Hash(empresa.Password);
            var e = mapper.Map<EmpresaDTO, Empresa>(empresa);
            EmpresaDTO actualizado = mapper.Map<Empresa, EmpresaDTO>(empresaRepository.ActualizarEmpresa(e));
            return actualizado;
        }
    }
}
