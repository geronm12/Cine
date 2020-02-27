using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Mailer.CineEmailSender
{
    public static class CineAunthenticationMailSender
    { 
        private static IConfiguration config;
        
        public static IEmailSender Sender()
        {
            return new SendGridEmailSender(config);
        }


        public static async Task<SendEmailResponse> SendUserVerificationEmail(string displayName, string email, string verificationURL)
        {

           return await Sender().SendEmailAsync(new SendEmailDetails
           {
               IsHtml = true,
               FromEmail = config[""],
               FromName = config[""],
               ToEmail = email,
               ToName = displayName,
               Subject = "Mail de Verificación",
               BodyContent = "Verify Email"+
               $"Hi {displayName},"+
               "Thanks for creating an account with us.<br/> To continue please verify your email with us."+
               "Verify Email"+
               verificationURL

           });

        }

    }
}
