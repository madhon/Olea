namespace IoT.WebApp;

using System.Collections.Concurrent;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

internal sealed class TypeTransformer : IOpenApiSchemaTransformer
{
    private static readonly ConcurrentDictionary<Type, (JsonSchemaType Type, string Format)> _typeMappings = new();

    public static void MapType<T>(OpenApiSchema schema)
    {
        _typeMappings[typeof(T)] = (schema.Type ?? JsonSchemaType.Null, schema.Format);
    }

    public Task TransformAsync(OpenApiSchema schema, OpenApiSchemaTransformerContext context, CancellationToken cancellationToken)
    {
        var clrType = context.JsonTypeInfo.Type;

        if (_typeMappings.TryGetValue(clrType, out var mapping))
        {
            schema.Type = mapping.Type;
            schema.Format = mapping.Format;
        }

        return Task.CompletedTask;
    }
}