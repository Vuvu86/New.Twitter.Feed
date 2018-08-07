using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Common.Api
{
    internal class CustomWebHostService : WebHostService
    {
        private ILogger Logger;

        public CustomWebHostService(IWebHost host) : base(host)
        {
            Logger = host.Services.GetRequiredService<ILogger<CustomWebHostService>>();
        }

        protected override void OnStarting(string[] args)
        {
            Logger.LogDebug("OnStarting method called.");
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            Logger.LogDebug("OnStarted method called.");
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            Logger.LogDebug("OnStopping method called.");
            base.OnStopping();
        }
    }
}
