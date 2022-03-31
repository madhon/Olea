namespace IoT.SiloHostApp
{
    using System.Threading;
    using System.Threading.Tasks;
    using GrainImplementation;
    using Microsoft.Extensions.Hosting;
    using Orleans.Configuration;
    using Orleans.Hosting;

    public class SiloHostService : IHostedService
    {
        private ISiloHost host;

        private void BuildSilo()
        {
            var t = typeof(DeviceGrain);

            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "IOTApp";
                });

            host = builder.Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            BuildSilo();
            await host.StartAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await host.StopAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
