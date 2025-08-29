namespace IoT.GrainInterfaces;

using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

[Alias("IoT.GrainInterfaces.ICacheGrain`1")]
public interface ICacheGrain<T> : IGrainWithStringKey
{
    [Alias("Set")]
    Task SetValue(Immutable<T> item, TimeSpan timeToKeep);
        
    [Alias("Get")]
    Task<Immutable<T>> GetValue();
        
    [Alias("Clear")]
    Task Clear();
        
    [Alias("Refresh")]
    Task Refresh();
}