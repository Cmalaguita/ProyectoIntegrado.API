using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.BL.Implementations;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        public IEmpresaBL EmpresaBL { get; set; }
        public IJwtBearer  jwtBearer { get; set; }
        public EmpresaController(IEmpresaBL empresaBL, IJwtBearer jwtBearer)
        {
            this.jwtBearer = jwtBearer;
            this.EmpresaBL = empresaBL;
        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("Login_Empresa")]
        [AllowAnonymous]
        public ActionResult<int> Login(EmpresaLoginDTO empresaLoginDTO)
        {
            EmpresaDTO e = EmpresaBL.Login(empresaLoginDTO);
            if (e!=null)
            {
                Response.Headers.Add("Authorization", jwtBearer.GenerateJWTTokenEmpresa(e));
                return Ok(e.Id);

            }
            else
            {
                return Unauthorized(-1);
            }
        }
        [HttpPost]
        [Route("Sign_up_Empresa")]
        [AllowAnonymous]
        public ActionResult CreateEmpresa(EmpresaSignUpDTO empresaSignUpDTO)
        {
            
            var empresa = EmpresaBL.CreateEmpresa(empresaSignUpDTO);
            if (empresa)
            {
                return Ok();
            }
            else
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Obtener_Todas_Las_Empresas")]
        public List<EmpresaDTO> ObtenerEmpresas()
        {

            return EmpresaBL.ObtenerEmpresas();
        }
        [HttpGet]
        [Route("Buscar_Empresa_Id")]
        public EmpresaDTO BuscarEmpresa(int id)
        {
            return EmpresaBL.BuscarEmpresa(id);
        }
        [HttpDelete]
        [Route("Eliminar_Empresa")]
        public ActionResult EliminarAlumno(int id)
        {
            var a = EmpresaBL.BuscarEmpresa(id);
            if (EmpresaBL.Exists(a))
            {
                EmpresaBL.BorrarEmpresa(a);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        [Route("Actualizar_Empresa")]
        public ActionResult<EmpresaDTO> ActualizarEmpresa(EmpresaDTO empresa)
        {
            if (EmpresaBL.Exists(empresa))
            {
                return EmpresaBL.ActualizarEmpresa(empresa);
            }
            return NotFound();
        }
    }
}
