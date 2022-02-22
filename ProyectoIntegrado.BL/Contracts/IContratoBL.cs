using ProyectoIntegrado.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.BL.Contracts
{
   public interface IContratoBL
    {
         ContratoDTO Stripe(ContratoDTO contratoDTO);
        DateTime FromUnixTimestampToDateTime(long unixTimeStamp);
    }
}
