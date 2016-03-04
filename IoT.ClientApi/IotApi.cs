namespace IoT.ClientApi
{
    using System.Threading.Tasks;
    using Refit;

    public class IotApi : IIoTApi
    {
        public async Task<TemperatureResult> GetTemperatureAsync(int id)
        {
            var api = RestService.For<IIoTApi>("http://localhost:61588/");
            return await api.GetTemperatureAsync(id).ConfigureAwait(false);
        }

        public async Task PostTemperatureAsync(int id, double value)
        {
            var api = RestService.For<IIoTApi>("http://localhost:61588/");
            await api.PostTemperatureAsync(id, value).ConfigureAwait(false);
        }

        public static IIoTApi Create()
        {
            return new IotApi();
        }
    }
}
