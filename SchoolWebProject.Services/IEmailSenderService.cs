using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IEmailSenderService
    {
        MailAddress fromAddress { get; }

        void SendMail(MailAddress toAddress, string text);
    }
}
