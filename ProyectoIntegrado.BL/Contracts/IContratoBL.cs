using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IContratoBL
    {
        string CrearSuscripcionPremium(EmpresaDTO empresa);
        DateTime FromUnixTimestampToDateTime(long unixTimeStamp);
    }
}
