using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
    public interface IMensajeBL
    {
        List<MensajeDTO> ObtenerMensajesPorAlumnoId(int alumnoId);
        List<MensajeDTO> ObtenerMensajesPorEmpresaId(int empresaId);
        List<MensajeDTO> ObtenerMensajesSegunLecturaPorAlumnoId(int alumnoId, bool leido);
        bool CambiarEstadoLecturaMensaje(int idmensaje, bool leido);
        MensajeDTO CrearMensaje(CrearMensajeDTO mensaje);
        bool BorrarMensaje(int mensajeId, int empresaId);
        MensajeDTO existMensaje(int idMensaje);
        MensajeDTO ActualizarMensaje(MensajeDTO mensaje);
    }
}
