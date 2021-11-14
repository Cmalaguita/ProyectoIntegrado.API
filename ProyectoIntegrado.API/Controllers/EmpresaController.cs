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
        
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("Login_Empresa")]
        public ActionResult<EmpresaDTO> Login(EmpresaDTO empresaDTO)
        {
            EmpresaDTO empresa;
            if ((empresa=EmpresaBL.Login(empresaDTO)) !=null)
            {
            return Ok();

            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("Sign_up_Empresa")]
        public ActionResult<EmpresaDTO> CreateEmpresa(EmpresaDTO empresaDTO)
        {
            var empresa = EmpresaBL.CreateEmpresa(empresaDTO);
            if (empresa!=null)
            {
                return Ok(empresa);
            }
            else
            {

                return BadRequest();
            }
        }
    }
}
