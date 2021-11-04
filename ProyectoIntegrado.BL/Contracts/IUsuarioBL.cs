using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IUsuarioBL
    {
        public bool Login(UsuarioDTO usuarioDTO);

    }
}
