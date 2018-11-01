namespace IoT.WebApp.Controllers
{
    using System;
    using System.Threading.Tasks;
    using GrainInterfaces;
    using Microsoft.AspNetCore.Mvc;
    using Orleans;
    using Model;

    [ApiController]
    [Route("api/temperature")]
    public class TemperatureController : ControllerBase
    {
        private readonly IClusterClient clusterClient;

        public TemperatureController(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpGet, Route("{id:int}")]
        public async Task<ActionResult> GetTemperatureAsync(int id)
        {

            var grain = clusterClient.GetGrain<IDeviceGrain>(id);

            var model = new TemperatureResultModel
            {
                Id = id,
                Value = await grain.GetTemperatureAsync().ConfigureAwait(false)
            };

            return Ok(model);
        }

        [HttpPost, Route("{id:int}")]
        public async Task<ActionResult> PostTemperatureAsync(int id, [FromBody] double value)
        {
            var grain = clusterClient.GetGrain<IDeviceGrain>(id);
            await grain.SetTemperatureAsync(value).ConfigureAwait(false);
            return Ok();
        }

    }
}
