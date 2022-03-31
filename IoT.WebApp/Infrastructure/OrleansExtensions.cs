namespace IoT.WebApp
{
    using Orleans;

    public static class OrleansExtensions
    {
        public static IServiceCollection AddOrleans(this IServiceCollection services)
        {
            services.AddSingleton(CreateClusterClient);
            return services;
        }

        private static IClusterClient CreateClusterClient(IServiceProvider serviceProvider)
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering(clusterId: "dev", serviceId: "IOTApp")
                .ConfigureLogging(_ => _.AddConsole())
                .Build();

            client.Connect().Wait();
            return client;
        }
    }
}
