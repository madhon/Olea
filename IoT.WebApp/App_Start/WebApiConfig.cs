namespace IoT.WebApp.App_Start
{
    using System.Web.Http;

    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}