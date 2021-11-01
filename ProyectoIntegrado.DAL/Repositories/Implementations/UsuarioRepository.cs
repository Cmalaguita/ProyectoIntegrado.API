using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Implementations
{
    class UsuarioRepository : IUsuarioRepository
    {
        public proyectointegradodbContext _context { get; set; }
        public UsuarioRepository (proyectointegradodbContext context)
            {
            this._context = context;
            }
        public bool Login(Usuario usuario)
        {
           return _context.Usuarios.Any(u => u.Email == usuario.Email && u.Password == usuario.Password);
        }
    }
}
