using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using System.Linq;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
   public class EmpresaRepository : IEmpresaRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public EmpresaRepository(proyectointegradodbContext context)
            {
            this._context = context;
            }
        public Empresa Login(Empresa empresa)
        {
           return _context.Empresas.FirstOrDefault(u => u.Email == empresa.Email && u.Password == empresa.Password);
        }

        public Empresa CreateEmpresa(Empresa empresa)
        {
           var e=_context.Empresas.Add(empresa);
            _context.SaveChanges();
            return e.Entity;
        }

        public bool Exists(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email);
        }
    }
}
