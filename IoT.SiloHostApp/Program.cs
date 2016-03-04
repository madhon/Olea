namespace IoT.SiloHostApp
{
    using System;
    using Topshelf;

    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<OleaService>();
                x.SetServiceName("OleaSiloHost");
                x.SetDescription("Olea Silo Host");
                x.StartAutomatically();
                x.RunAsNetworkService();
                x.EnableServiceRecovery(rc => rc.RestartService(1));
            });
        }
    }
}