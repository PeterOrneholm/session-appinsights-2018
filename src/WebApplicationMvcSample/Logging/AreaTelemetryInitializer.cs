using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

namespace WebApplicationMvcSample.Logging
{
    public class AreaTelemetryInitializer : ITelemetryInitializer
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public AreaTelemetryInitializer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Initialize(ITelemetry telemetry)
        {
            var area = GetBusinessArea(_httpContextAccessor.HttpContext);
            telemetry.Context.Properties["area"] = area;
        }

        private string GetBusinessArea(HttpContext context)
        {
            if (context == null)
            {
                return "default";
            }

            if (context.Request.Path.StartsWithSegments("/admin"))
            {
                return "admin";
            }
            else
            {
                return "default";
            }
        } 
    }
}