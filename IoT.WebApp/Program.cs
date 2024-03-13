using IoT.WebApp.Endpoints;
using Microsoft.OpenApi.Models;

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
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "IoT.WebApp",
        Contact = new OpenApiContact
        {
            Name = "madhon"
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "docs/{documentName}/openapi.json";
        c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{httpReq.PathBase.Value}" } });
    });
    
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "docs";
        c.SwaggerEndpoint("v1/openapi.json", "IoT.WebApp v1");
        c.DisplayRequestDuration();
        c.DefaultModelExpandDepth(-1);
    });
}

app.UseRouting();

app.MapGetTemperatureEndpoint();
app.MapPostTemperatureEndpoint();

app.Run();