using System.Threading.Tasks;
using Orleans;

namespace IoT.GrainInterfaces
{
    [Alias("IoT.GrainInterfaces.IDeviceGrain")]
    public interface IDeviceGrain : IGrainWithIntegerKey
    {
        [Alias("SetTemperatureAsync")]
        Task SetTemperatureAsync(double value);
        
        [Alias("GetTemperatureAsync")]
        ValueTask<double> GetTemperatureAsync();
    }
}
