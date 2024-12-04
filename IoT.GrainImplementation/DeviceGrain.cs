namespace IoT.GrainImplementation;

using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;

public partial class DeviceGrain : Grain, IDeviceGrain
{
    private readonly ILogger<DeviceGrain> logger;
    private double temp;
    private const double MAX_TEMP = 100;

    public DeviceGrain(ILogger<DeviceGrain> logger)
    {
        this.logger = logger;
    }
        
    public Task SetTemperatureAsync(double value)
    {
        var id = this.GetPrimaryKeyLong();
        switch (value)
        {
            case >= MAX_TEMP when temp <= MAX_TEMP:
                LogTemperatureExceededForDevice(id);
                break;
            case < MAX_TEMP when temp > MAX_TEMP:
                LogReturnedToNormalForDevice(id);
                break;
        }

        temp = value;

        return Task.CompletedTask;
    }

    public ValueTask<double> GetTemperatureAsync()
    {
        LogGrainIdString(IdentityString);
        LogGetTemperatureCalled();
        return new ValueTask<double>(temp);
    }
        
    [LoggerMessage(EventId = 10_0001, Level = LogLevel.Information, Message = "Temperature threshold exceeded for device {id}")]
    private partial void LogTemperatureExceededForDevice(long id);
        
    [LoggerMessage(EventId = 10_0002, Level = LogLevel.Information, Message = "Temperature back to normal for device {id}")]
    private partial void LogReturnedToNormalForDevice(long id);
        
    [LoggerMessage(EventId = 10_0003, Level = LogLevel.Information, Message = "Identity: {identity}")]
    private partial void LogGrainIdString(string identity);
        
    [LoggerMessage(EventId = 10_0004, Level = LogLevel.Information, Message = "GetTemperatureAsync Called")]
    private partial void LogGetTemperatureCalled();
}