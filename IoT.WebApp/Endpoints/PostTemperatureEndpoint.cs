namespace IoT.WebApp.Endpoints;

using Microsoft.AspNetCore.Mvc;

internal static class PostTemperatureEndpoint
{
    public static IEndpointRouteBuilder MapPostTemperatureEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("{id:int}",
                async Task<Results<Ok, ProblemHttpResult>> (IClusterClient clusterClient, int id, [FromBody] double value) =>
                {
                    var grain = clusterClient.GetGrain<IDeviceGrain>(id);
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