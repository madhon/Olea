namespace IoT.SiloHostApp
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Orleans.Hosting;

    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseOrleans(silo =>
                {
                    silo.UseLocalhostClustering(clusterId: "dev", serviceId: "IOTApp")
                        .ConfigureLogging(logging => logging.AddConsole());
                });

    }
}
