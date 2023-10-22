using GloboTicket.Application.Models;

namespace GloboTicket.Application.Contracts.Infrastructure;

public interface IEmailService
{
    public Task<bool> SendEmail(Email email);
}
