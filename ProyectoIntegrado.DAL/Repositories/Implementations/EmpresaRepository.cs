using Microsoft.EntityFrameworkCore;
using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using System;
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
        public int Login(Empresa empresa)
        {
            if (ExistsEmail(empresa))
            {
                int id = _context.Empresas.Where(e => e.Email == empresa.Email && e.Password == e.Password).FirstOrDefault().Id;
            return id;
            }
            else
            {

            return -1;
            }
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

        public bool ExistsEmail(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email);
        }

        public List<Empresa> ObtenerEmpresas()
        {
                var e=_context.Empresas.Include(e=>e.Provincia).ToList();
            foreach (var item in e)
            {
                item.Password = null;
            }
            return e;
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
                 var e=_context.Empresas.Where(e => e.Id == id).Include(e => e.Provincia).FirstOrDefault();
            e.Password = null;
            return e;
        }
        public Empresa BuscarEmpresaTrasUpdate(int id)
        {
            var e = _context.Empresas.Where(e => e.Id == id).Include(e => e.Provincia).FirstOrDefault();
          
            return e;
        }
        public Empresa ActualizarEmpresa(Empresa empresa)
        {

            if (Exists(empresa))
            {
                var e =_context.Empresas.Update(empresa).Entity;
                _context.SaveChanges();
                var a = BuscarEmpresaTrasUpdate(e.Id);
                return a;
            }
            return null;
        }
    }
}
