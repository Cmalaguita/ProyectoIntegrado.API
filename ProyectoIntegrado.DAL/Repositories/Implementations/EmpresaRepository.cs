﻿using Microsoft.EntityFrameworkCore;
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
        public Empresa Login(Empresa empresa)
        {
            if (ExistsEmail(empresa))
            {
                var e = _context.Empresas.Where(e => e.Email == empresa.Email && e.Password == empresa.Password).FirstOrDefault();
            return e;
            }
            else
            {

            return null;
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
            return _context.Empresas.Any(u => u.Email == empresa.Email && u.Password==empresa.Password);
        }
        public Empresa ExistsUnicamenteEmail(string email)
        {
            return _context.Empresas.Where(u => u.Email == email).FirstOrDefault();
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

        public bool CompararCodigo(string email, string codigo)
        {
            var a = ExistsUnicamenteEmail(email);
            if (a != null)
            {
                return _context.Empresas.Any(a => a.CodigoVerificacion == codigo);
            }
            else
            {
                return false;
            }
        }
        public bool CompararCodigoParaEmail(string codigo, string email)
        {
            var a = ExistsUnicamenteEmail(email);
            if (a != null)
            {
                if (_context.Empresas.Any(a => a.CodigoVerificacion == codigo))
                {
                    a.EmailVerificado = true;
                    _context.Empresas.Update(a);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        public bool CambiarPassEmpresa(string pass, string email)
        {
            var a = ExistsUnicamenteEmail(email);
            if (a != null)
            {
                a.Password = pass;
                _context.Empresas.Update(a);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
