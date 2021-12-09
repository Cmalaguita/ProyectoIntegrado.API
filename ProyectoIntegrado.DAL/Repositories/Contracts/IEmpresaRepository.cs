
using ProyectoIntegrado.DAL.Entities;
using System.Collections.Generic;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IEmpresaRepository
    {
        bool Login(Empresa e);
        bool CreateEmpresa(Empresa empresa);
        bool Exists(Empresa empresa);
        List<Empresa> ObtenerEmpresas();
        bool BorrarEmpresa(Empresa empresa);
        Empresa BuscarEmpresa(int id);
        Empresa ActualizarEmpresa(Empresa empresa);
    }
}
