namespace IoT.KiotaClient;

using System.Text.Json.Serialization;

public class TemperatureResult
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }
}
