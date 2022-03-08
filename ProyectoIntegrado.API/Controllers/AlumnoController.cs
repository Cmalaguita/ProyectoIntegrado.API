
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.CORE.Security;
using System.Collections.Generic;

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlumnoController : ControllerBase
    {
        public IJwtBearer jwtBearer { get; set; }
        public IAlumnoBL AlumnoBL { get; set; }
        public AlumnoController(IAlumnoBL alumnoBL, IJwtBearer jwtBearer)
        {
            this.jwtBearer = jwtBearer;
            this.AlumnoBL = alumnoBL;
        }
        
        [HttpPost]
        [Route("Login_Alumno")]
        [AllowAnonymous]
        public ActionResult<int> Login(AlumnoLoginDTO alumnoLoginDTO)
        {
            AlumnoDTO a = AlumnoBL.Login(alumnoLoginDTO);
            if (a!=null)
            {
                Response.Headers.Add("Authorization", jwtBearer.GenerateJWTTokenAlumno(a));
                return Ok(a.Id);
            }
            else
            {
                return Unauthorized(-1);
            }
        }
        [HttpPost]
        [Route("Sign_up_Alumno")]
        [AllowAnonymous]
        public ActionResult CreateAlumno(AlumnoSignUpDTO alumnoSignUpDTO)
        {
            var creado = AlumnoBL.CreateAlumno(alumnoSignUpDTO);
            if (creado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Obtener_Todos_Los_Alumnos")]
        public List<AlumnoDTO> ObtenerAlumnos()
        {
                 
            return AlumnoBL.ObtenerAlumnos();
        }
        [HttpGet]
        [Route("Buscar_Alumno_Id")]
        public AlumnoDTO BuscarAlumno()
        {
            int id = jwtBearer.GetUserIdFromToken(Request.Headers["Authorization"].ToString());
            return AlumnoBL.BuscarAlumno(id);
        }
        [HttpDelete]
        [Route("Eliminar_Alumno")]
        public ActionResult EliminarAlumno()
        {
            int id = jwtBearer.GetUserIdFromToken(Request.Headers["Authorization"].ToString());
            var a = AlumnoBL.BuscarAlumno(id);
            if (AlumnoBL.Exists(a))
            {
                AlumnoBL.BorrarAlumno(a);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut]
        [Route("Actualizar_Alumno")]
        public ActionResult<AlumnoDTO> ActualizarAlumno(AlumnoUpdateDTO alumno)
        {
            if (AlumnoBL.ExistsUnicamenteEmail(alumno.Email)!=null)
            {
            return AlumnoBL.ActualizarAlumno(alumno);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("Generar_Codigo_Verificacion")]
        [AllowAnonymous]
        public void GenerarCodigo(string email)
        {
            AlumnoBL.GenerarCodigo(email);
        }
        [HttpGet]
        [Route("Comprobar_Codigo_Verificacion")]
        [AllowAnonymous]
        public ActionResult CompararCodigo(string email, string codigo)
        {
            if (AlumnoBL.CompararCodigo(email, codigo))
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPut]
        [Route("Comprobar_Codigo_Verificacion_Email")]
        [AllowAnonymous]
        public bool CompararCodigoParaEmail(string codigo, string email)
        {
            return AlumnoBL.CompararCodigoParaEmail(codigo, email);
        }
        [HttpPut]
        [Route("Cambiar_Password_Alumno")]
        [AllowAnonymous]
        public bool CambiarPassAlumno(string pass, string email)
        {
            return AlumnoBL.CambiarPassAlumno(pass, email);
        }

        [HttpPut]
        [Route("Cambiar_Imagen_Alumno")]
        public ActionResult<AlumnoDTO> CambiarImagenAlumno(AlumnoUpdateDTO alumno)
        {
            var a=AlumnoBL.CambiarImagenAlumno(alumno);
            if (a!=null)
            {

                return Ok(a);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
