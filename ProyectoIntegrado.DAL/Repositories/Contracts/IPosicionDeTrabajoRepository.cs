using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
    public interface IPosicionDeTrabajoRepository
    {
        PosicionDeTrabajoDTO CreatePosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajo);
        bool Exists(PosicionDeTrabajoDTO posicionDeTrabajo);
        List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo();
        bool BorrarPosicion(PosicionDeTrabajoDTO posicionDeTrabajo);
        List <PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoActivasHoy();
        List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorNombre(string nombre);
        bool ActualizarPosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajo);
    }
}
