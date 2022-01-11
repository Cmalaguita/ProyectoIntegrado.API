using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
    public interface IPosicionDeTrabajoRepository
    {
        PosicionDeTrabajo CreatePosicionDeTrabajo(PosicionDeTrabajo posicionDeTrabajo);
        bool Exists(PosicionDeTrabajo posicionDeTrabajo);
        List<PosicionDeTrabajo> ObtenerPosicionesDeTrabajo();
        bool BorrarPosicion(PosicionDeTrabajo posicionDeTrabajo);
        List <PosicionDeTrabajo> BuscarPosicionesDeTrabajoActivasHoy();
        List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoPorNombre(string nombre);
        List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoPorEmpresa(int id);
        List<PosicionDeTrabajo> BuscarPosicionesDeTrabajoPorCiclo(int id);
        PosicionDeTrabajo ActualizarPosicionDeTrabajo(PosicionDeTrabajo posicionDeTrabajo);
        PosicionDeTrabajo BuscarPosicionDeTrabajoId(int id);

    }
}
