using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.Email
{
   public interface IEmailSender
    {
       public void Send(string emailDestino);
    }
}
