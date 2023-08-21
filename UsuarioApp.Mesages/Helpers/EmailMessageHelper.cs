using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Messages.Models;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Helpers
{
    public class EmailMessageHelper
    {
        public void EnvioEmail(UsuarioMessageModel model)
        {
            var settings = new EmailSettings();

            var mailMessage = new MailMessage(settings.Conta, model.Para);
            mailMessage.Subject = model.Assunto;
            mailMessage.Body = model.Corpo;
            mailMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient(settings.Smtp, settings.Porta);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(settings.Conta, settings.Senha);
            smtpClient.Send(mailMessage);

        }
    }
}
