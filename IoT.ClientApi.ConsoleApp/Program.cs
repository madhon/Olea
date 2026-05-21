namespace IoT.ClientApi.ConsoleApp;

using IoT.KiotaClient;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using IoT.KiotaClient.Models;

public static class Program
{
#pragma warning disable RS0030
    public static void Main() => MainAsync().GetAwaiter().GetResult();
#pragma warning restore RS0030

    private static async Task MainAsync()
    {
        var authProvider = new AnonymousAuthenticationProvider();
        using var adaptor = new HttpClientRequestAdapter(authProvider);
        adaptor.BaseUrl = "http://localhost:56124";
        var client = new OleaClient(adaptor);

        Console.WriteLine("Setting Temp");

        var request = new TemperatureRequest
        {
            Value = 56
        };

        await client.Api.Temperature[1].PostAsync(request);

        var res2 = await client.Api.Temperature[1].GetAsync();

        Console.WriteLine($"Id: {res2!.Id}  Value: {res2!.Value}");

        Debugger.Break();
    }

}