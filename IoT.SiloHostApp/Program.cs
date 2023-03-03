Console.Title = "SilHost";


await Host.CreateDefaultBuilder()
    .UseWindowsService()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering(clusterId: "dev", serviceId: "IOTApp");
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .RunConsoleAsync();

