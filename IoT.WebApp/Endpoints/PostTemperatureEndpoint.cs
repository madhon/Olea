namespace IoT.WebApp.Endpoints;

using Microsoft.AspNetCore.Mvc;

public static class PostTemperatureEndpoint
{
    public static IEndpointRouteBuilder MapPostTemperatureEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("api/temperature/{id:int}",
                async Task<IResult> (IClusterClient clusterClient, int id, [FromBody] double value) =>
                {
                    var grain = clusterClient.GetGrain<IDeviceGrain>(id);
                    await grain.SetTemperatureAsync(value).ConfigureAwait(false);
                    return Results.Ok();
                })
            .WithName("PostTemperature")
            .WithDescription("Update the current temperature for the id specified")
            .Produces<Ok>()
            .ProducesProblem(400);

        return builder;
    }
    
}