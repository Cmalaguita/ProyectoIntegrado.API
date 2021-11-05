using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Contracts
{
   public interface IEmpresaRepository
    {
        bool Login(Empresa e);
        Empresa CreateEmpresa(Empresa empresa);
        bool Exists(Empresa empresa);
    }
}
