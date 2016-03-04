namespace IoT.GrainImplementation
{
    using System;
    using System.Threading.Tasks;
    using Orleans;
    using IoT.GrainInterfaces;

    public class DeviceGrain : Grain, IDeviceGrain
    {
        private double temp;
        private const double MAX_TEMP = 100;

        public Task SetTemperatureAsync(double value)
        {
            var id = this.GetPrimaryKeyLong();
            if (value >= MAX_TEMP && temp <= MAX_TEMP)
            {
                Console.WriteLine($"Temperature threshold exceeded for device {id}");
            }

            if (value < MAX_TEMP && temp > MAX_TEMP)
            {
                Console.WriteLine($"Temperature back to normal for device {id}");
            }

            this.temp = value;

            return TaskDone.Done;
        }

        public Task<double> GetTemperatureAsync()
        {
            Console.WriteLine(IdentityString);
            Console.WriteLine("GetTemperatureAsync Called");
            return Task.FromResult(this.temp);
        }
    }
}
