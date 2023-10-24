using System.Reflection.Metadata.Ecma335;

namespace GloboTicket.Api.MIddelware;

public static class MiddelwareExtenstion
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandler>();
    }
}
