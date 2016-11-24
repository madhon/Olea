namespace IoT.ClientApi
{
    using System.Threading.Tasks;
    using RestEase;

    public class IotApi : IIoTApi
    {
        public async Task<TemperatureResult> GetTemperatureAsync(int id)
        {
            var api = RestClient.For<IIoTApi>("http://localhost:61588/");
            return await api.GetTemperatureAsync(id).ConfigureAwait(false);
        }

        public async Task PostTemperatureAsync(int id, double value)
        {
            var api = RestClient.For<IIoTApi>("http://localhost:61588/");
            await api.PostTemperatureAsync(id, value).ConfigureAwait(false);
        }

        public static IIoTApi Create() => new IotApi();
    }
}
