using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
