using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.Security
{
   public interface IPasswordGenerator
    {
        public string Hash(string password);
    }
}
