using System.Threading.Tasks;
using Orleans;

namespace IoT.GrainInterfaces
{
	public interface IDeviceGrain : IGrainWithIntegerKey
    {
        Task SetTemperatureAsync(double value);
        Task<double> GetTemperatureAsync();
    }
}
