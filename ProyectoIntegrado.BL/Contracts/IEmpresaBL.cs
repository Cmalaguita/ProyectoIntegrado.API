using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IEmpresaBL
    {
        public bool Login(EmpresaLoginDTO empresaCompletaDTO);
        public bool CreateEmpresa(EmpresaDTO empresaCompletaDTO);
        public bool Exists(EmpresaDTO empresa);
        List<EmpresaDTO> ObtenerEmpresas();
        bool BorrarEmpresa(EmpresaDTO empresaCompletaDTO);
        EmpresaDTO BuscarEmpresa(int id);
        EmpresaDTO ActualizarEmpresa(EmpresaDTO empresaCompletaDTO);
    }
}
