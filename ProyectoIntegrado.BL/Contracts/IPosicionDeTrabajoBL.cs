using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IPosicionDeTrabajoBL
    {
        PosicionDeTrabajoDTO CreatePosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajoDTO);
        bool Exists(PosicionDeTrabajoDTO posicionDeTrabajoDTO);
        List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo();
        bool BorrarPosicion(PosicionDeTrabajoDTO posicionDeTrabajoDTO);
        List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoActivasHoy();
        List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorNombre(string nombre);
        PosicionDeTrabajoDTO BuscarPosicionDeTrabajoId(int id);
        PosicionDeTrabajoDTO ActualizarPosicionDeTrabajo(PosicionDeTrabajoDTO posicionDeTrabajoDTO);
    }
}
