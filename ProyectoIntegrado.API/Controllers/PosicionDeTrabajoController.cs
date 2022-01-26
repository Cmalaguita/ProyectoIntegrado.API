using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
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
    public class PosicionDeTrabajoController : ControllerBase
    {
        public IPosicionDeTrabajoBL posicionDeTrabajoBL { get; set; }
        public IJwtBearer jwtBearer { get; set; }
        public PosicionDeTrabajoController(IPosicionDeTrabajoBL posicionDeTrabajoBL, IJwtBearer jwtBearer)
        {
            this.posicionDeTrabajoBL = posicionDeTrabajoBL;
            this.jwtBearer = jwtBearer;
        }

        [HttpPost]
        [Route("Crear_Posicion_De_Trabajo")]
        public ActionResult<PosicionDeTrabajoCreateDTO> CrearPosicionDeTrabajo(PosicionDeTrabajoCreateDTO posicionDeTrabajoCreateDTO)
        {
            var create = posicionDeTrabajoBL.CreatePosicionDeTrabajo(posicionDeTrabajoCreateDTO);
            if (posicionDeTrabajoBL.Exists(create))
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpGet]
        [Route("Obtener_Todas_Las_Posiciones_De_Trabajo")]
        public List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo()
        {
            return posicionDeTrabajoBL.ObtenerPosicionesDeTrabajo();
        }
        [HttpGet]
        [Route("Obtener_Posiciones_De_Trabajo_Por_Empresa")]
        public List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajoPorEmpresa()
        {
            int id = jwtBearer.GetUserIdFromToken(Request.Headers["Authorization"].ToString());
            return posicionDeTrabajoBL.BuscarPosicionesDeTrabajoPorEmpresa(id);
        }
        [HttpGet]
        [Route("Obtener_Posiciones_De_Trabajo_Por_Ciclo")]
       public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorCiclo(int id)
        {
            return posicionDeTrabajoBL.BuscarPosicionesDeTrabajoPorCiclo(id);
        }

        [HttpGet]
        [Route("Obtener_Posicion_De_Trabajo_Por_Id")]
        public PosicionDeTrabajoDTO BuscarPosicionDeTrabajoId(int id)
        {
            return posicionDeTrabajoBL.BuscarPosicionDeTrabajoId(id);
        }
        [HttpGet]
        [Route("Obtener_Posiciones_De_Trabajo_Activas_Hoy")]
        public List<PosicionDeTrabajoDTO> BuscarPosicionDeTrabajoHoy()
        {
            return posicionDeTrabajoBL.BuscarPosicionesDeTrabajoActivasHoy();
        }
        [HttpGet]
        [Route("Obtener_Posiciones_De_Trabajo_Por_Nombre")]
       public List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorNombre(string nombre)
        {
            return posicionDeTrabajoBL.BuscarPosicionesDeTrabajoPorNombre(nombre);
        }
        [HttpPost]
        [Route("Actualizar_Posicion_De_Trabajo")]
       public PosicionDeTrabajoCreateDTO ActualizarPosicionDeTrabajo(PosicionDeTrabajoCreateDTO posicionDeTrabajo)
        {
            return posicionDeTrabajoBL.ActualizarPosicionDeTrabajo(posicionDeTrabajo);
        }
        [HttpDelete]
        [Route("Eliminar_Posicion_De_Trabajo")]
       public bool BorrarPosicion(PosicionDeTrabajoDeleteDTO  posicionDeTrabajo)
        {
            return posicionDeTrabajoBL.BorrarPosicion(posicionDeTrabajo);
        }

       
    }
}
