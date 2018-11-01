namespace IoT.SiloHostApp
{
    using Topshelf;

    public static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SiloHostService>();
                x.StartAutomatically();
                x.RunAsVirtualServiceAccount();
                x.SetServiceName("IOT.SiloHostApp");
                x.SetDisplayName("IOT.SiloHostApp");
            });
        }
    }
}
