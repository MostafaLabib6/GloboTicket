using GloboTicket.Application.Contracts.Infrastructure;
using GloboTicket.Application.Models;
using GloboTicket.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Infrastructure;

public static class InfrastructureServiceRegisteration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var EmailConfiguration = configuration.GetSection("EmailSettings");
        services.Configure<EmailSetting>(EmailConfiguration);
        services.AddTransient<IEmailService, EmailService>();
        return services;

    }
}
