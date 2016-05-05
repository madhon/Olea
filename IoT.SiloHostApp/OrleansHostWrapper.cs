namespace IoT.SiloHostApp
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Orleans.Runtime.Configuration;
    using Orleans.Runtime.Host;
    using Orleans.Storage;

    public class OrleansHostWrapper : IDisposable
    {
        public bool Debug
        {
            get { return siloHost != null && siloHost.Debug; }
            set { siloHost.Debug = value; }
        }

        private SiloHost siloHost;

        public OrleansHostWrapper()
        {
            Configure();
            Init();
        }

        public bool Run()
        {
            bool ok = false;

            try
            {
                siloHost.InitializeOrleansSilo();

                ok = siloHost.StartOrleansSilo();

                if (ok)
                {
                    Console.WriteLine($"Successfully started Orleans silo '{siloHost.Name}' as a {siloHost.Type} node.");
                }
                else
                {
                    throw new SystemException(
                        $"Failed to start Orleans silo '{siloHost.Name}' as a {siloHost.Type} node.");
                }
            }
            catch (Exception exc)
            {
                siloHost.ReportStartupError(exc);
                var msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                Console.WriteLine(msg);
            }

            return ok;
        }

        public bool Stop()
        {
            bool ok = false;

            try
            {
                siloHost.StopOrleansSilo();

                Console.WriteLine($"Orleans silo '{siloHost.Name}' shutdown.");
            }
            catch (Exception exc)
            {
                siloHost.ReportStartupError(exc);
                var msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                Console.WriteLine(msg);
            }

            return ok;
        }

        private void Init()
        {
            siloHost.LoadOrleansConfig();
        }

        private void Configure()
        {
            string siloName = Dns.GetHostName(); // Default to machine name

            var config = ClusterConfiguration.LocalhostPrimarySilo();
            var props = new Dictionary<string, string>();
            config.Globals.RegisterStorageProvider<MemoryStorage>("MemoryStore", props);

            siloHost = new SiloHost(siloName, config);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool dispose)
        {
            siloHost.Dispose();
            siloHost = null;
        }
    }
}
