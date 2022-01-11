using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
    public interface ICicloRepository
    {
        List<Ciclo> ObtenerCiclos();
        Ciclo BuscarCicloId(int id);
        Ciclo BuscarCicloNombre(string nombre);
        List<Ciclo> ObtenerCiclosPorFamilia(int idFamilia);
        List<Ciclo> ObtenerCiclosPorTipo(int idTipo);

        List<Ciclo> ObtenerCiclosPorFamiliaYTipo(int idTipo,int idFamilia);
    }
}
