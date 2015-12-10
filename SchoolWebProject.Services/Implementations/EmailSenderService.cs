using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public class EmailSenderService : BaseService, IEmailSenderService
    {
        private SmtpClient smtp;
        private IAccountService service;
        private string password;

        public EmailSenderService(ILogger logger, IAccountService inService) 
            : base(logger)
        {
            this.FromAddress = new MailAddress(ConfigurationSettings.AppSettings["smtpEmail"]);
            this.service = inService;
            this.password = ConfigurationSettings.AppSettings["smtpPassword"];
            this.smtp = new SmtpClient()
            {
                Host = ConfigurationSettings.AppSettings["smtpServer"],
                Port = int.Parse(ConfigurationSettings.AppSettings["smtpPort"]),
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.FromAddress.Address, this.password)
            };
        }

        public MailAddress FromAddress { get; private set; }

        public void SendMail(string toAddress, string text)
        {
            MailMessage message = new MailMessage(this.FromAddress, new MailAddress(toAddress)) 
            { 
                Subject = Constants.EmailSubject, 
                Body = text
            }; 
            this.smtp.Send(message);
        }
    }
}
