
using ProyectoIntegrado.DAL.Entities;
using System.Collections.Generic;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IEmpresaRepository
    {
        bool Login(Empresa e);
        Empresa CreateEmpresa(Empresa empresa);
        bool Exists(Empresa empresa);
        List<Empresa> ObtenerEmpresas();
        bool BorrarEmpresa(Empresa empresa);
        Empresa BuscarEmpresa(string email);
        bool ActualizarEmpresa(Empresa empresa);
    }
}
