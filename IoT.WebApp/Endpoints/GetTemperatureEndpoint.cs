namespace IoT.WebApp.Endpoints;

internal static class GetTemperatureEndpoint
{
    public static IEndpointRouteBuilder MapGetTemperatureEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("{id:int}",
            async Task<Results<Ok<TemperatureResultModel>, ProblemHttpResult>> (IClusterClient clusterClient, CancellationToken ct, int id) =>
            {
                var grain = clusterClient.GetGrain<IDeviceGrain>(id);
                var value = await grain.GetTemperatureAsync().ConfigureAwait(false);
                var model = new TemperatureResultModel(id, value);
                
                return TypedResults.Ok(model);
            })
            .WithName("GetTemperature")
            .WithDescription("Get the current temperature for the id specified")
            .Produces<TemperatureResultModel>()
            .ProducesProblem(400);

        return builder;
    }
}