namespace IoT.ClientApi
{
    using System.Threading.Tasks;
    using RestEase;

    [Header("User-Agent", "IoTConsole")]
    public interface IIoTApi
    {
        [Get("/api/temperature/{id}")]
        Task<TemperatureResult> GetTemperatureAsync([Path] int id);

        [Post("/api/temperature/{id}")]
        Task PostTemperatureAsync([Path] int id, [Body] double value);
    }
}
