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
    public class AlumnoController : ControllerBase
    {
        public IAlumnoBL AlumnoBL { get; set; }
        public AlumnoController(IAlumnoBL alumnoBL)
        {
            this.AlumnoBL = alumnoBL;
        }
        
        [HttpPost]
   
        [Route("Login_Alumno")]
        public ActionResult Login(AlumnoDTO alumnoDTO)
        {
            if (AlumnoBL.Login(alumnoDTO))
            {
            return Ok();

            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("Sign_up_Alumno")]
        public ActionResult<AlumnoDTO> CreateAlumno(AlumnoDTO alumnoDTO)
        {
            var alumno = AlumnoBL.CreateAlumno(alumnoDTO);
            if (alumno != null)
            {
                return Ok(alumno);
            }
            else
            {

                return BadRequest();
            }
        }
    }
}
