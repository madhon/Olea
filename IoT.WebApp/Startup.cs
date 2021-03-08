namespace IoT.WebApp
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Orleans;

    public class Startup
    {
        private readonly IWebHostEnvironment env;
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            this.env = env;
            this.Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllersWithViews();

            services.AddSingleton(CreateClusterClient);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
              endpoints.MapDefaultControllerRoute();
            });
        }

        private IClusterClient CreateClusterClient(IServiceProvider serviceProvider)
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
