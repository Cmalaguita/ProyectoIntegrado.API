
using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
    public interface ICicloBL
    {
        List<CicloDTO> ObtenerCiclos();
        CicloDTO BuscarCicloId(int id);
        CicloDTO BuscarCicloNombre(string nombre);
        List<CicloDTO> ObtenerCiclosPorFamilia(int idFamilia);
        List<CicloDTO> ObtenerCiclosPorTipo(int idTipo);

        List<CicloDTO> ObtenerCiclosPorFamiliaYTipo(int idTipo,int idFamilia);
    }
}
