using GloboTicket.Application.Contracts.Infrastructure;
using GloboTicket.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GloboTicket.Infrastructure.Mail;

public class EmailService : IEmailService
{
    private EmailSetting? _emailSetting { get; set; }

    public EmailService(IOptions<EmailSetting> emailSetting)
    {
        _emailSetting = emailSetting.Value;
    }



    public async Task<bool> SendEmail(Email email)
    {
        var Client = new SendGridClient(_emailSetting.ApiKey);

        var subject = email.Subject;
        var body = email.Body;
        var to = new EmailAddress(email.To);

        var from = new EmailAddress(
            email: _emailSetting.FromEmail,
            name: _emailSetting.FromName);

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        var response = await Client.SendEmailAsync(sendGridMessage);

        if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
            return true;
        return false;

    }
}
