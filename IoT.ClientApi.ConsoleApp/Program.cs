namespace IoT.ClientApi.ConsoleApp
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Nito.AsyncEx;

    public class Program
    {
        public static void Main()
        {
            AsyncContext.Run(() => MainAsync());

        }

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
