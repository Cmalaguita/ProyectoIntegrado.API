using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.BL.Implementations;
using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public IEmpresaBL EmpresaBL { get; set; }
        public EmpresaController(IEmpresaBL empresaBL)
        {
            this.EmpresaBL = empresaBL;
        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("Login_Empresa")]
        public ActionResult<int> Login(EmpresaLoginDTO empresaLoginDTO)
        {
            int id;
            if ((id=EmpresaBL.Login(empresaLoginDTO))!=-1)
            {
            return Ok(id);

            }
            else
            {
                return Unauthorized(id);
            }
        }
        [HttpPost]
        [Route("Sign_up_Empresa")]
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
