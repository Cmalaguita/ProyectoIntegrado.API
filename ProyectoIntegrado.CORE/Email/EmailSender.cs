using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProyectoIntegrado.CORE.Email
{
    public class EmailSender : IEmailSender

    {
        public void Send(string emailDestino)
        {
            var fromAddress = new MailAddress("2damproyectocutre@gmail.com", "Equipo de desarrollo de ratatata");
            var toAddress = new MailAddress(emailDestino, emailDestino.ToString());
            const string fromPassword = "RatitaInsensill@";
            const string subject = "Welcome to Miami!";
            const string body = "Bienvenido!!!";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        public void SendCodePass(string emailDestino, string mensaje)
        {
            var fromAddress = new MailAddress("2damproyectocutre@gmail.com", "Equipo de desarrollo de ratatata");
            var toAddress = new MailAddress(emailDestino, emailDestino.ToString());
            const string fromPassword = "RatitaInsensill@";
            const string subject = "Codigo de verificación para cambio de contraseña/verificacion email";
            string body = mensaje;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        public void SendContact(string emailDestino, string mensaje, string nombrePosicion, string nombreEmpresa, string emailEmpresa)
        {
            var fromAddress = new MailAddress("2damproyectocutre@gmail.com", "Equipo de desarrollo de ratatata");
            var toAddress = new MailAddress(emailDestino, emailDestino.ToString());
            const string fromPassword = "RatitaInsensill@";
            string subject = nombreEmpresa + " Quiere contactar con usted en relacion a una oferta de trabajo";
            string body = "En relacion a la oferta: " + nombrePosicion + ". La compañía envía el siguiente mensaje: \n" + mensaje + "\n puede contactar con la empresa a traves del siguiente correo: " + emailEmpresa;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
