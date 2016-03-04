namespace IoT.WebApp.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Halcyon.HAL;
    using IoT.GrainInterfaces;
    using IoT.WebApp.Model;
    using Orleans;

    /// <summary>
    /// Orleans Temperature API
    /// </summary>
    [RoutePrefix("api/temperature")]
    public class TemperatureController : ApiController
    {
        /// <summary>
        /// Get The Temperature from the given sensor
        /// </summary>
        /// <param name="id">Sensor ID</param>
        /// <returns>Current Temperature</returns>
        [HttpGet, Route("{id:int}")]
        public async Task<IHttpActionResult> GetTemperatureAsync(int id)
        {
            var grain = GrainClient.GrainFactory.GetGrain<IDeviceGrain>(id);
            var model = new TemperatureResultModel
            {
                Id = id,
                Value = await grain.GetTemperatureAsync().ConfigureAwait(false)
            };

            return this.HAL(model, new[] { new Link("self", "/api/temperature/{Id}") });
        }

        /// <summary>
        /// Set the given sensors temperature value
        /// </summary>
        /// <param name="id">Sensor ID</param>
        /// <param name="value">Current Temperature</param>
        /// <returns></returns>
        [HttpPost, Route("{id:int}")]
        public async Task<IHttpActionResult> PostTemperatureAsync(int id, [FromBody] double value)
        {
            var grain = GrainClient.GrainFactory.GetGrain<IDeviceGrain>(id);
            await grain.SetTemperatureAsync(value).ConfigureAwait(false);
            return Ok();
        }
    }
}