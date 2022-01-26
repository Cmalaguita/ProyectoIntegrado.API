
using ProyectoIntegrado.DAL.Entities;
using System.Collections.Generic;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IEmpresaRepository
    {
        Empresa Login(Empresa e);
        bool CreateEmpresa(Empresa empresa);
        bool Exists(Empresa empresa);
        List<Empresa> ObtenerEmpresas();
        bool BorrarEmpresa(Empresa empresa);
        Empresa ExistsUnicamenteEmail(string email);
        Empresa BuscarEmpresa(int id);
        Empresa ActualizarEmpresa(Empresa empresa);
        bool CompararCodigo(string email, string codigo);
        bool CompararCodigoParaEmail(string codigo,string email);
        bool CambiarPassEmpresa(string pass, string email);
    }
}
