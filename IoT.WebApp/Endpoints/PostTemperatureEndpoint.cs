namespace IoT.WebApp.Endpoints;

using Microsoft.AspNetCore.Mvc;

internal static class PostTemperatureEndpoint
{
    public static IEndpointRouteBuilder MapPostTemperatureEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("{id:int}",
                async Task<Results<Ok, ProblemHttpResult>> (IClusterClient clusterClient, int id, TemperatureRequest request) =>
                {
                    var grain = clusterClient.GetGrain<IDeviceGrain>(id);
                    
                    var value = request.value;
                    
                    await grain.SetTemperatureAsync(value).ConfigureAwait(false);
                    return TypedResults.Ok();
                })
            .WithName("PostTemperature")
            .WithDescription("Update the current temperature for the id specified")
            .Produces<Ok>()
            .ProducesProblem(400);

        return builder;
    }
    
}