using IoT.WebApp.Endpoints;
using Microsoft.OpenApi;
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
builder.Services.AddOpenApi(opts =>
{
    opts.AddDocumentTransformer((document, _, _) =>
    {
        foreach (var schema in document.Components.Schemas.Values)
            FixFormats(schema);

        return Task.CompletedTask;
    });
    opts.AddSchemaTransformer((schema, _, _) =>
    {
        FixFormats(schema);
        return Task.CompletedTask;
    });
    
    opts.AddScalarTransformers();
});

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



static void FixFormats(IOpenApiSchema schema)
{
    if (schema is not OpenApiSchema concrete)
    {
        return;
    }

    // Type is a flags enum - check if it contains the unwanted string combination
    if (concrete.Type.HasValue)
    {
        if (concrete.Type.Value.HasFlag(JsonSchemaType.Number) && concrete.Format == "double")
        {
            concrete.Type = JsonSchemaType.Number;  // strip the |String
            concrete.Format = "float";
            concrete.Pattern = null;                // kiota doesn't need the pattern
        }
        else if (concrete.Type.Value.HasFlag(JsonSchemaType.Integer) && concrete.Format == "int32")
        {
            concrete.Type = JsonSchemaType.Integer; // strip the |String
            concrete.Format = "int64";
            concrete.Pattern = null;
        }
        else if (concrete.Type.Value.HasFlag(JsonSchemaType.Integer) && concrete.Format == "int64")
        {
            concrete.Type = JsonSchemaType.Integer; // strip the |String from int64 too
            concrete.Pattern = null;
        }
    }

    if (schema.Properties is null)
    {
        return;
    }

    foreach (var property in schema.Properties.Values)
    {
        FixFormats(property);
    }
}