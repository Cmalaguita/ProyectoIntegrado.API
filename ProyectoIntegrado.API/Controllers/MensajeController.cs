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
    public class MensajeController : ControllerBase
    {
        public IMensajeBL mensajeBL { get; set; }

        public MensajeController(IMensajeBL mensajeBL)
        {
            this.mensajeBL = mensajeBL;
        }
        [HttpGet]
        [Route("Obtener_Mensajes_Por_Alumno")]
        public List<MensajeDTO> ObtenerMensajesPorAlumnoId(int alumnoId)
        {
            return mensajeBL.ObtenerMensajesPorAlumnoId(alumnoId);
        }
        [HttpGet]
        [Route("Obtener_Mensajes_Por_Empresa")]
        public List<MensajeDTO> ObtenerMensajesPorEmpresaId(int empresaId)
        {
            return mensajeBL.ObtenerMensajesPorEmpresaId(empresaId);
        }
        [HttpGet]
        [Route("Obtener_Mensajes_No_Leidos")]
        public List<MensajeDTO> ObtenerMensajesNoLeidos(int alumnoId)
        {
            return mensajeBL.ObtenerMensajesNoLeidos(alumnoId);
        }
        [HttpPut]
        [Route("Cambiar_Estado_Lectura")]
        public bool CambiarEstadoLecturaMensaje(int idmensaje, bool leido)
        {
            return mensajeBL.CambiarEstadoLecturaMensaje(idmensaje,leido);
        }
        [HttpPost]
        [Route("Crear_Mensaje")]
        public MensajeDTO CrearMensaje(CrearMensajeDTO mensaje)
        {
            return mensajeBL.CrearMensaje(mensaje);
        }
        [HttpDelete]
        [Route("Borrar_Mensaje")]
        public bool BorrarMensaje(int mensajeId, int empresaId)
        {
            return mensajeBL.BorrarMensaje(mensajeId,empresaId);
        }
        [HttpGet]
        [Route("Comprobar_Existencia")]
        public MensajeDTO existMensaje(int idMensaje)
        {
            return mensajeBL.existMensaje(idMensaje);
        }
        [HttpPut]
        [Route("Actualizar_Mensaje")]
        public MensajeDTO ActualizarMensaje(MensajeDTO mensaje)
        {
            return mensajeBL.ActualizarMensaje(mensaje);
        }
    }
}
