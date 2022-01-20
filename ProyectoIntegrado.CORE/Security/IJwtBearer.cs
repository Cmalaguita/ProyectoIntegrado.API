using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.Security
{
    public interface IJwtBearer
    {
        public string GenerateJWTToken(Empresa empresa);
        public int GetUserIdFromToken(string token);
        public string GenerateJWTToken(Alumno empresa);
    }
}
