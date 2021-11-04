using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioBL UsuarioBL { get; set; }
        public UsuarioController(IUsuarioBL usuarioBL)
        {
            this.UsuarioBL = usuarioBL;
        }
        
        [HttpPost]
        [Route("Login")]
        public bool Login(UsuarioDTO usuarioDTO)
        {
            return UsuarioBL.Login(usuarioDTO);
        }
    }
}
