using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.Security
{
    public interface IJwtBearer
    {
        public string GenerateJWTTokenEmpresa(EmpresaDTO empresaDTO);
        public int GetUserIdFromToken(string token);
        public string GenerateJWTTokenAlumno(AlumnoDTO alumnoDTO);
    }
}
