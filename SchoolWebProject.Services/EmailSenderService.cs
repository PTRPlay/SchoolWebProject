using System;
using System.Collections.Generic;
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
        public MailAddress fromAddress { get; private set; }

        private SmtpClient smtp;
        private AccountService service;
        private string Password;

        public EmailSenderService(ILogger logger, AccountService inService) 
            : base(logger)
        {
            this.fromAddress = new MailAddress("AxeSchoolWebProject@gmail.com");
            this.service = inService;
            this.Password = "lv165net";
            this.smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.fromAddress.Address, this.Password)
            };
        }

        public void SendMail(MailAddress toAddress, string text)
        {
            MailMessage message = new MailMessage(this.fromAddress, toAddress) { Subject = Constants.EmailSubject, Body = text };
            try
            {
                this.smtp.Send(message);
            }
            catch
            {
                
            }
        }

    }
}
