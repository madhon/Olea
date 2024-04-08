namespace IoT.WebApp.Endpoints;

public static class TemperatureApi
{
    public static IEndpointRouteBuilder MapTemperatureApi(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/temperature/");
        
        group.MapGetTemperatureEndpoint();
        group.MapPostTemperatureEndpoint();

        return builder;
    }
}