using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
   public interface IProvinciaRepository
    {
        List<Provincia> ObtenerProvincias();   
        Provincia BuscarProvinciaNombre(String nombre);
        Provincia BuscarProvinciaId(int id);
    }
}
