namespace IoT.GrainImplementation;

using System;
using System.Threading.Tasks;
using IoT.GrainInterfaces;
using Orleans;
using Orleans.Concurrency;

public class CacheGrain<T> : Grain, ICacheGrain<T>
{
    private Immutable<T> item = new(default);
    private TimeSpan timeToKeep = TimeSpan.Zero;

    public Task SetValue(Immutable<T> item, TimeSpan timeToKeep)
    {
        this.item = item;
        this.timeToKeep = timeToKeep == TimeSpan.Zero ? TimeSpan.FromHours(2) : timeToKeep;
        this.DelayDeactivation(timeToKeep);
        return Task.FromResult(0);
    }

    public Task<Immutable<T>> GetValue()
    {
        return Task.FromResult(this.item);
    }

    public Task Clear()
    {
        this.DeactivateOnIdle();
        return Task.FromResult(0);
    }

    public Task Refresh()
    {
        this.DelayDeactivation(timeToKeep);
        return Task.FromResult(0);
    }
}