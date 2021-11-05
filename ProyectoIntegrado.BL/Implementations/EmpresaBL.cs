using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
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
        public EmpresaBL(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }
        public bool Login(EmpresaDTO empresaDTO)
        {
            var empresa = new Empresa
            {
                Email = empresaDTO.Email,
                Password = empresaDTO.Password
            };
            return empresaRepository.Login(empresa);
        }

        public  EmpresaDTO CreateEmpresa(EmpresaDTO empresaDTO)
        {
            var empresa = new Empresa
            {
                Email = empresaDTO.Email,
                Password = empresaDTO.Password
            };
            if (!empresaRepository.Exists(empresa))
            {
             var e= empresaRepository.CreateEmpresa(empresa);
            var empresaDTOCreado = new EmpresaDTO
            {
                Email = e.Email,
                Password = e.Password
            };
                return empresaDTOCreado;
            }
            return null;
        }

        public bool Exists(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}
