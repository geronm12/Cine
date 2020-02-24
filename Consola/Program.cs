using Cine.Mailer;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmailSender _sender = new SendGridEmailSender();


            var detalles = new SendEmailDetails
            {
                FromEmail = "gerolpz01@gmail.com",
                FromName  = "Gero",
                Subject = "VerifyMail",
                BodyContent = "",
                IsHtml = true,
                ToEmail = "gerolpz01@gmail.com",
                ToName = "Gero"
            };


            var sendGridClass =  _sender.SendEmailAsync(detalles);





        }
    }
}
