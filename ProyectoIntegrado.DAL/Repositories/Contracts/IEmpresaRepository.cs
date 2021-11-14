
using ProyectoIntegrado.DAL.Entities;


namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IEmpresaRepository
    {
        Empresa Login(Empresa e);
        Empresa CreateEmpresa(Empresa empresa);
        bool Exists(Empresa empresa);
    }
}
