using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IEmpresaBL
    {
        public EmpresaDTO Login(EmpresaLoginDTO empresaLoginDTO);
        public bool CreateEmpresa(EmpresaSignUpDTO empresaSignUpDTO);
        public bool Exists(EmpresaDTO empresaDTO);
        EmpresaDTO ExistsUnicamenteEmail(string email);
        List<EmpresaDTO> ObtenerEmpresas();
        bool BorrarEmpresa(EmpresaDTO empresaDTO);
        EmpresaDTO BuscarEmpresa(int id);
        EmpresaDTO ActualizarEmpresa(EmpresaUpdateDTO empresaDTO);
        void GenerarCodigo(string email);
        bool CompararCodigo(string email, string codigo);
        bool CompararCodigoParaEmail(string codigo, string email);
        bool CambiarPassEmpresa(string pass, string email);
        bool SendContact(string emailDestino, string mensaje, string nombrePosicion, string nombreEmpresa, string emailEmpresa);

    }
}
