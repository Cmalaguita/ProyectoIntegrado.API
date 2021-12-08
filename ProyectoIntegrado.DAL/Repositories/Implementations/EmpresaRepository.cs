using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using System.Collections.Generic;
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
        public bool Login(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email && u.Password == empresa.Password);
        }

        public Empresa CreateEmpresa(Empresa empresa)
        {
            var e = _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return e.Entity;
        }

        public bool Exists(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email);
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return _context.Empresas.ToList();
        }

        public bool BorrarEmpresa(Empresa empresa)
        {
            if (Exists(empresa))
            {
                _context.Empresas.Remove(empresa);
                return true;
            }
            return false;
        }

        public Empresa BuscarEmpresa(string email)
        {
            return _context.Empresas.Where(e => e.Email == email).FirstOrDefault();
        }

        public bool ActualizarEmpresa(Empresa empresa)
        {

            if (Exists(empresa))
            {
                _context.Empresas.Update(empresa);
                return true;
            }
            return false;
        }
    }
}
