using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.DAL.Repositories.Contracts
{
   public interface ITipoDeCicloRepository
    {
        List<TipoDeCiclo> ObtenerTiposDeCiclos();
        TipoDeCiclo BuscarTipoDeCicloId(int id);

    }
}
