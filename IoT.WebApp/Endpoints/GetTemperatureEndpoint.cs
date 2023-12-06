namespace IoT.WebApp.Endpoints;

public static class GetTemperatureEndpoint
{
    public static IEndpointRouteBuilder MapGetTemperatureEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("api/temperature/{id:int}",
            async Task<Results<Ok<TemperatureResultModel>, ProblemHttpResult>> (IClusterClient clusterClient, int id) =>
            {
                var grain = clusterClient.GetGrain<IDeviceGrain>(id);
                var model = new TemperatureResultModel
                {
                    Id = id,
                    Value = await grain.GetTemperatureAsync().ConfigureAwait(false)
                };
                
                return TypedResults.Ok(model);
            })
            .WithName("GetTemperature")
            .WithDescription("Get the current temperature for the id specified")
            .Produces<TemperatureResultModel>()
            .ProducesProblem(400);

        return builder;
    }
}