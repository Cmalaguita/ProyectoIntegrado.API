using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IEmpresaBL
    {
        public bool Login(EmpresaDTO empresaDTO);
        public EmpresaDTO CreateEmpresa(EmpresaDTO empresaDTO);
        public bool Exists(Empresa empresa);
        List<EmpresaCompletaDTO> ObtenerEmpresas();
        bool BorrarEmpresa(Empresa empresa);
        EmpresaCompletaDTO BuscarEmpresa(string email);
        bool ActualizarEmpresa(Empresa empresa);
    }
}
