namespace IoT.ClientApi
{
    using System.Threading.Tasks;
    using Refit;

    [Headers("User-Agent: IoTConsole")]
    public interface IIoTApi
    {
        [Get("/api/temperature/{id}")]
        Task<TemperatureResult> GetTemperatureAsync(int id);

        [Post("/api/temperature/{id}")]
        Task PostTemperatureAsync(int id, [Body] double value);
    }
}
