using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Contracts
{
    interface IUsuarioRepository
    {
        bool Login(Usuario u);
    }
}
