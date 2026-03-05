namespace IoT.WebApp;

using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
    NumberHandling = JsonNumberHandling.Strict,
    GenerationMode = JsonSourceGenerationMode.Default)
]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(int?))]
[JsonSerializable(typeof(double))]
[JsonSerializable(typeof(double?))]

[JsonSerializable(typeof(TemperatureResultModel))]

[JsonSerializable(typeof(ProblemHttpResult))]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext;