namespace IoT.SiloHostApp
{
    using System;
    using Topshelf;

    public class OleaService : ServiceControl
    {
        private AppDomain oleaDomain;
        private static OrleansHostWrapper hostWrapper;

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
            hostWrapper = new OrleansHostWrapper();

            if (!hostWrapper.Run())
            {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        private static void ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }
    }
}
