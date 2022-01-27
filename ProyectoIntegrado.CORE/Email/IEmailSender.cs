using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrado.CORE.Email
{
   public interface IEmailSender
    {
       public void Send(string emailDestino);
        public void SendCodePass(string emailDestino, string mensaje);
        public void SendContact(string emailDestino, string mensaje, string nombrePosicion, string nombreEmpresa, string emailEmpresa);
    }
}
