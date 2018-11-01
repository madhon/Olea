namespace IoT.ClientApi.ConsoleApp
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public static class Program
    {
        public static void Main() => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            IIoTApi api = IotApi.Create();

            Console.WriteLine("Setting Temp");
            await api.PostTemperatureAsync(1, 5).ConfigureAwait(false);

            var res = await api.GetTemperatureAsync(1).ConfigureAwait(false);

            Debugger.Break();
        }
    }
}
