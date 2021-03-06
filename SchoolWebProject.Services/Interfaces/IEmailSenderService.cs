﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services
{
    public interface IEmailSenderService
    {
        MailAddress FromAddress { get; }

        void SendMail(string toAddress, string text);
    }
}
