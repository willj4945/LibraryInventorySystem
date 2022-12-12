// This is a fake implementation of email sender. 
using Microsoft.AspNetCore.Identity.UI.Services;

namespace LibraryInventorySystem
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}

