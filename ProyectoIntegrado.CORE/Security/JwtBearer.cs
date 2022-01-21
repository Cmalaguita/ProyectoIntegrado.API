using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProyectoIntegrado.CORE.Security
{
    public class JwtBearer : IJwtBearer
    {
        public IConfiguration configuration { get; private set; }

        public JwtBearer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateJWTTokenEmpresa(EmpresaDTO empresa)
        {
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                    new Claim("Id",empresa.Id.ToString()),
                    new Claim("Email", empresa.Email),
                    new Claim("Random", Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateJWTTokenAlumno(AlumnoDTO alumno)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                    new Claim("Id",alumno.Id.ToString()),
                    new Claim("Email", alumno.Email),
                    new Claim("Random", Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int GetUserIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token.Replace("Bearer ", string.Empty));
            var tokenS = jsonToken as JwtSecurityToken;
            var id = tokenS.Claims.FirstOrDefault(claim => claim.Type == "Id");
            return id != null ? Int32.Parse(id.Value) : 0;

        }
    }
}
