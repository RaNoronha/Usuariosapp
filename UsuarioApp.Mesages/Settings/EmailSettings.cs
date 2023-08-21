using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    public class EmailSettings
    {
        public string? Conta { get => "ranoronha@msn.com"; }
        public string? Senha { get => "Lz5365@pq"; }
        public string? Smtp { get => "smtp-mail.outlook.com"; }
        public int Porta { get => 587; }        
    }
}
