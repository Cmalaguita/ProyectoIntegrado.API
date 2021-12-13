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
        public ActionResult Login(EmpresaLoginDTO empresaLoginDTO)
        {
           
            if (EmpresaBL.Login(empresaLoginDTO))
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
        public ActionResult CreateEmpresa(EmpresaDTO empresaDTO)
        {
            var empresa = EmpresaBL.CreateEmpresa(empresaDTO);
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
        [HttpPost]
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
