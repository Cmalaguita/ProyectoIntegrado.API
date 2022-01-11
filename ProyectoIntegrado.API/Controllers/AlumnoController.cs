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
        public ActionResult<int> Login(AlumnoLoginDTO alumnoLoginDTO)
        {
            int id;
            if ((id = AlumnoBL.Login(alumnoLoginDTO)) != -1)
            {
                return Ok(id);

            }
            else
            {
                return Unauthorized(id);
            }
        }
        [HttpPost]
        [Route("Sign_up_Alumno")]
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
        public AlumnoDTO BuscarAlumno(int id)
        {
            return AlumnoBL.BuscarAlumno(id);
        }
        [HttpDelete]
        [Route("Eliminar_Alumno")]
        public ActionResult EliminarAlumno(int id)
        {
            var a = AlumnoBL.BuscarAlumno(id);
            if (AlumnoBL.Exists(a))
            {
                AlumnoBL.BorrarAlumno(a);
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        [Route("Actualizar_Alumno")]
        public ActionResult<AlumnoDTO> ActualizarAlumno(AlumnoDTO alumno)
        {
            if (AlumnoBL.Exists(alumno))
            {
            return AlumnoBL.ActualizarAlumno(alumno);
            }
            return NotFound();
        }

    }
}
