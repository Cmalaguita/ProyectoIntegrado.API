using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
    public interface IMensajeRepository
    {
        List<Mensaje> ObtenerMensajesPorAlumnoId(int alumnoId);
        List<Mensaje> ObtenerMensajesPorEmpresaId(int empresaId);
        List<Mensaje> ObtenerMensajesSegunLecturaPorAlumnoId(int alumnoId, bool leido);
        bool CambiarEstadoLecturaMensaje(int idmensaje,bool leido);
        Mensaje CrearMensaje(Mensaje mensaje);
        bool BorrarMensaje(int mensajeId, int empresaId);
        Mensaje existMensaje(int idMensaje);
        Mensaje ActualizarMensaje(Mensaje mensaje);
    }
}
