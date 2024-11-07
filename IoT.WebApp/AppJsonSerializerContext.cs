namespace IoT.WebApp;

using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
    GenerationMode = JsonSourceGenerationMode.Default)
]
[JsonSerializable(typeof(TemperatureResultModel))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;