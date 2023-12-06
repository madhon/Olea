namespace IoT.KiotaClient;

using System.Text.Json.Serialization;


[JsonSerializable(typeof(TemperatureResult), GenerationMode = JsonSourceGenerationMode.Metadata)]
public partial class KiotaTemperateureJsonContext : JsonSerializerContext
{
}
