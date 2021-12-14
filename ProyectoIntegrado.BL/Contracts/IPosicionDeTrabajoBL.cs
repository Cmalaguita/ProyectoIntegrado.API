using ProyectoIntegrado.CORE.DTO;
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IPosicionDeTrabajoBL
    {
        PosicionDeTrabajoCreateDTO CreatePosicionDeTrabajo(PosicionDeTrabajoCreateDTO posicionDeTrabajoDTO);
        bool Exists(PosicionDeTrabajoDTO posicionDeTrabajoDTO);
        bool Exists(PosicionDeTrabajoCreateDTO posicionDeTrabajoCreateDTO);
        List<PosicionDeTrabajoDTO> ObtenerPosicionesDeTrabajo();
        bool BorrarPosicion(PosicionDeTrabajoDeleteDTO posicionDeTrabajoDeleteDTO);
        List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoActivasHoy();
        List<PosicionDeTrabajoDTO> BuscarPosicionesDeTrabajoPorNombre(string nombre);
        PosicionDeTrabajoDTO BuscarPosicionDeTrabajoId(int id);
        PosicionDeTrabajoCreateDTO ActualizarPosicionDeTrabajo(PosicionDeTrabajoCreateDTO posicionDeTrabajoCreateDTO);
    }
}
