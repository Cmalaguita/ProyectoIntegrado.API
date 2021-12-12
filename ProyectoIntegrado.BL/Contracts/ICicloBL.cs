
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

    }
}
