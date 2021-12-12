using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
    public interface IFamiliaProfesionalBL
    {
        List<FamiliaProfesionalDTO> ObtenerFamiliasProfesionales();
        FamiliaProfesionalDTO BuscarFamiliaProfesionalId(int id);
    }
}
