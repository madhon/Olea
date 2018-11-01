namespace IoT.GrainImplementation
{
    using System;
    using System.Threading.Tasks;
    using GrainInterfaces;
    using Orleans;

    public class DeviceGrain : Grain, IDeviceGrain
    {
        private double temp;
        private const double MAX_TEMP = 100;

        public Task SetTemperatureAsync(double value)
        {
            var id = this.GetPrimaryKeyLong();
            if (value >= MAX_TEMP && temp <= MAX_TEMP)
            {
                Console.WriteLine($"Temperature threshold exceeded for device {id.ToString()}");
            }

            if (value < MAX_TEMP && temp > MAX_TEMP)
            {
                Console.WriteLine($"Temperature back to normal for device {id.ToString()}");
            }

            this.temp = value;

            return Task.CompletedTask;
        }

        public Task<double> GetTemperatureAsync()
        {
            Console.WriteLine(IdentityString);
            Console.WriteLine("GetTemperatureAsync Called");
            return Task.FromResult(this.temp);
        }
    }
}
