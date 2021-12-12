using ProyectoIntegrado.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
    public interface ITipoDeCicloBL
    {
        List<TipoDeCicloDTO> ObtenerTiposDeCiclos();
        TipoDeCicloDTO BuscarTipoDeCicloId(int id);
    }
}
