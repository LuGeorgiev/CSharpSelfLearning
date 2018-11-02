using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.Areas.Identity.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("EstateManagment@estate.com", "EstateManagment Admin");
            var to = new EmailAddress(email, email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);

            var response = await client.SendEmailAsync(msg);
            var body = await response.Body.ReadAsStringAsync();
            var statusCode = response.StatusCode;
        }
    }
}
