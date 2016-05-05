namespace IoT.SiloHostApp
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Orleans.Runtime.Configuration;
    using Orleans.Runtime.Host;
    using Orleans.Storage;
    using Topshelf;

    public class OleaService : ServiceControl
    {
        private AppDomain oleaDomain;
        private static SiloHost host;

        public bool Start(HostControl hostControl)
        {
            oleaDomain = AppDomain.CreateDomain("OleaSiloHostDomain", null, new AppDomainSetup() { AppDomainInitializer = InitSilo });
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            oleaDomain.DoCallBack(ShutdownSilo);
            return true;
        }

        private static void InitSilo(string[] args)
        {
            try
            {
                var config = ClusterConfiguration.LocalhostPrimarySilo();
                var props = new Dictionary<string, string>();
                config.Globals.RegisterStorageProvider<MemoryStorage>("MemoryStore", props);

                host = new SiloHost(Dns.GetHostName(), config);

                host.InitializeOrleansSilo();
                var initOk = host.StartOrleansSilo();

                if (!initOk)
                {
                    throw new SystemException($"Failed to start Orleans silo '{host.Name}' as a {host.Type} node");
                }
            }
            catch (Exception exc)
            {
                host.ReportStartupError(exc);
                var msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                throw;
            }
        }

        private static void ShutdownSilo()
        {
            try
            {
                host.ShutdownOrleansSilo();
            }
            catch (Exception exc)
            {
                host.ReportStartupError(exc);
                var msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                throw;
            }

            if (host != null)
            {
                host.Dispose();
                GC.SuppressFinalize(host);
                host = null;
            }
        }
    }
}
