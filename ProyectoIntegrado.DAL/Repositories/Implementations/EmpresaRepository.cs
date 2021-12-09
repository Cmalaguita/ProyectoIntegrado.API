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

        public bool CreateEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return true;
        }

        public bool Exists(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Id == empresa.Id);
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

        public Empresa BuscarEmpresa(int id)
        {
            return _context.Empresas.Where(e => e.Id == id).FirstOrDefault();
        }

        public Empresa ActualizarEmpresa(Empresa empresa)
        {

            if (Exists(empresa))
            {
                var e =_context.Empresas.Update(empresa).Entity;
                _context.SaveChanges();
                return e;
            }
            return null;
        }
    }
}
