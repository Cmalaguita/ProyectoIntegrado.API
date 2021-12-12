using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
   public interface IFamiliaProfesionalRepository
    {
        List<FamiliaProfesional> ObtenerFamiliasProfesionales();
        FamiliaProfesional BuscarFamiliaProfesionalId(int id);          
    }
}
