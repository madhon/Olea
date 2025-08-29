namespace IoT.ClientApi
{
    using System;
    using System.Threading.Tasks;
    using RestEase;

    public class IotApi : IIoTApi
    {
        public Uri Host { get; set; }

        public async Task<TemperatureResult> GetTemperatureAsync(int id)
        {
            var api = RestClient.For<IIoTApi>(Host);
            return await api.GetTemperatureAsync(id).ConfigureAwait(false);
        }

        public async Task PostTemperatureAsync(int id, double value)
        {
            var api = RestClient.For<IIoTApi>(Host);
            await api.PostTemperatureAsync(id, value).ConfigureAwait(false);
        }

        public static IIoTApi Create()
        {
            return Create( new Uri("http://localhost:56124/"));
        }

        public static IIoTApi Create(Uri hostUri)
        {
            return new IotApi { Host = hostUri };
        }
    }
}
