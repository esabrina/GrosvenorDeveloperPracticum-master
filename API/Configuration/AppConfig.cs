using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace API.Configuration
{
    public static class AppConfig
    {
        public static void MapCustomHealthCheck(this IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("/hc/live", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }
            );
            app.MapHealthChecks("/hc/ready", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self"), //Predicate = r => r.Tags.Contains("services"), //we dont have services right now
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }
            );
        }
    }
}
