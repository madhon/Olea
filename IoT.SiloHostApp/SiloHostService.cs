namespace IoT.SiloHostApp
{
    using GrainImplementation;
    using Orleans.Configuration;
    using Orleans.Hosting;
    using Topshelf;

    public class SiloHostService : ServiceControl
    {
        private ISiloHost host;

        public bool Start(HostControl hostControl)
        {
            BuildSilo();

            host.StartAsync().GetAwaiter().GetResult();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            host.StopAsync().GetAwaiter().GetResult();
            return true;
        }

        private void BuildSilo()
        {
            var t = typeof(DeviceGrain);

            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "IOTApp";
                })
                //.ConfigureApplicationParts(parts => parts.AddApplicationPart(t.Assembly).WithReferences())
                .EnableDirectClient();

            host = builder.Build();
        }

    }
}
