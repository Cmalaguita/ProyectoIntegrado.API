using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegrado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionDeTrabajoController : ControllerBase
    {
        public IPosicionDeTrabajoBL posicionDeTrabajoBL { get; set; }
        public PosicionDeTrabajoController(IPosicionDeTrabajoBL posicionDeTrabajoBL)
        {
            this.posicionDeTrabajoBL = posicionDeTrabajoBL;
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
            return Unauthorized();
        }
        
        [HttpGet]
        [Route("Obtener_Todas_Las_Posiciones_De_Trabajo")]
        public List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo()
        {
            return posicionDeTrabajoBL.ObtenerPosicionesDeTrabajo();
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
