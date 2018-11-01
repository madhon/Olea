namespace IoT.GrainInterfaces
{
    using System;
    using System.Threading.Tasks;
    using Orleans;
    using Orleans.Concurrency;

    public interface ICacheGrain<T> : IGrainWithStringKey
    {
        Task Set(Immutable<T> item, TimeSpan timeToKeep);
        Task<Immutable<T>> Get();
        Task Clear();
        Task Refresh();
    }
}