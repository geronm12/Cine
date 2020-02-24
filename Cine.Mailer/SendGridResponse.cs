using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Mailer
{
    /// <summary>
    /// Response de la clase SendGrid
    /// </summary>
   public class SendGridResponse
   {
     ///<summary>
     ///Errores del response
     /// </summary>
     
    public List<SendGridErrorResponse> Errores { get; set; }

   }
    
}
