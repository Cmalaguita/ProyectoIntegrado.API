using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IUsuarioRepository
    {
        bool Login(Usuario u);
    }
}
