using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMvcSample.Controllers
{
    [Route("api/[controller]")]
    public class Calculator : Controller
    {
        private readonly TelemetryClient _telemetryClient;

        public Calculator(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public async Task<int> Get(int a, int b, string o)
        {
            _telemetryClient.TrackEvent("calculate", new Dictionary<string, string>
            {
                { "a", a.ToString() },
                { "b", b.ToString() },
                { "operator", o },
            });

            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync($"http://api.mathjs.org/v4/?expr={a}{o}{b}");
            var resultString = await result.Content.ReadAsStringAsync();
            var resultInt = int.Parse(resultString);

            return resultInt;
        }
    }
}
