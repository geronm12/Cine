using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Cine.Mailer
{
    public class SendGridEmailSender:IEmailSender
    {
            private static IConfiguration Configuration { get; set; }
            
            public async Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details)
            {

            ///<summary>
            ///Api generada en SendGrid 
            /// </summary>
              var apiKey = "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";
               ///<summary>
               ///Clase SendGridClient que requiere como parámetros apiKey
               ///Posee 4 sobrecargas para más información navegar dentro de la clase.
               /// </summary>    
               var client = new SendGridClient(apiKey);
               //From
               var from = new EmailAddress(details.FromEmail, details.FromName);
               //Subject   
               var subject = details.Subject;
               //To    
               var to = new EmailAddress(details.ToEmail, details.ToName);
               //Content    
               var plainTextContent = details.BodyContent;
               //Crea la clase email lista para enviar    
                var msg = MailHelper.CreateSingleEmail(from, 
                    to,
                    subject, 
                    //Texto plano
                    plainTextContent,
                    //Html content
                    details.IsHtml ? 
                    details.BodyContent :
                    null);

            msg.TemplateId = "cf405053-6d2a-488c-8427-0f1c07eb669b";
            msg.AddSubstitution("--Title--", "Verify Email");
            msg.AddSubstitution("--Content1--", "Hi guy. This is a verify email.");
            msg.AddSubstitution("--Content2--", "This is the second line </br> And this is Just below");
            msg.AddSubstitution("--ButtonText--", "Verify Email");
            msg.AddSubstitution("--ButtonUrl--", "www.google.com");


            var response = await client.SendEmailAsync(msg);
             
                return new SendEmailResponse();
            }
        }
    }


