namespace IoT.ClientApi.ConsoleApp;

using System.Text.Json.Serialization;
using IoT.KiotaClient.Models;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    NumberHandling = JsonNumberHandling.AllowReadingFromString )
]
[JsonSerializable(typeof(TemperatureResultModel))]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext;