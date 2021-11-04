using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository UsuarioRepository { get; set; }
        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }
        public bool Login(UsuarioDTO usuarioDTO)
        {
            var usuario = new ProyectoIntegrado.DAL.Entities.Usuario
            {
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password
            };
            return UsuarioRepository.Login(usuario);
        }
    }
}
