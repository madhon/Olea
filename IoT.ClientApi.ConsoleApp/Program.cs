namespace IoT.ClientApi.ConsoleApp;

using IoT.KiotaClient;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System;
using System.Diagnostics;
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

        Console.WriteLine($"Id: {res2!.Id}  Value: {res2!.Value}");

        Debugger.Break();
    }

}