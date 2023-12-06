namespace IoT.ClientApi.ConsoleApp
{
    using IoT.KiotaClient;
    using Microsoft.Kiota.Abstractions.Authentication;
    using Microsoft.Kiota.Http.HttpClientLibrary;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public static class Program
    {
        public static void Main() => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            var authProvider = new AnonymousAuthenticationProvider();
            var adaptor = new HttpClientRequestAdapter(authProvider);
            adaptor.BaseUrl = "http://localhost:56124";

            var client = new OleaClient(adaptor);


            Console.WriteLine("Setting Temp");

            await client.Api.Temperature[1].PostAsync(56d);


            var res2 = await client.Api.Temperature[1].GetAsync();

            var tr = Deserialize<TemperatureResult>(res2);

            Console.WriteLine($"Id: {tr.Id}  Value: {tr.Value}");


            Debugger.Break();
        }

        public static T Deserialize<T>(Stream s)
        {
            var opts = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            return JsonSerializer.Deserialize<T>(s, opts);
        }
    }
}
