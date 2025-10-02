using IoT.WebApp.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleansClient(client =>
{
    client.UseLocalhostClustering(clusterId: "dev", serviceId: "IOTApp", gatewayPort: 30000);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", cors => cors.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(
        0, AppJsonSerializerContext.Default);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.MapScalarApiReference(opts =>
    {
        opts.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        opts.DefaultFonts = false;
    });
}

app.UseRouting();

app.MapTemperatureApi();

app.Run();