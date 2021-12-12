using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
    public interface IProvinciaBL
    {
        List<ProvinciaDTO> ObtenerProvincias();
        ProvinciaDTO BuscarProvinciaNombre(String nombre);
        ProvinciaDTO BuscarProvinciaId(int id);
    }
}
