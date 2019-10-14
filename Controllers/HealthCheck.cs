using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TodoApi.Controllers
{
    public class ApiHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = new CancellationToken())
        {
            /// TODO: Heatlh check logic goes here, it can be db check, connecting to any other apis, it will be all the checks that this microservice needs to run
            bool isHeathly = true;

            if(1 != 1)
            {
                isHeathly = false;
            }

            if(isHeathly)
            {
                return Task.FromResult(HealthCheckResult.Healthy("TodoApi is heatlhy."));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("TodoApi is not heatlhy please investigate."));

            }
        }
    }
}