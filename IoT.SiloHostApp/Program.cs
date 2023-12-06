Console.Title = "SilHost";


await Host.CreateDefaultBuilder()
    .UseWindowsService()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering(clusterId: "dev", serviceId: "IOTApp", gatewayPort: 30000, siloPort: 11111);
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .RunConsoleAsync();

