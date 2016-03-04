namespace IoT.WebApp
{
    using System;
    using System.Web;
    using System.Web.Http;
    using IoT.WebApp.App_Start;
    using Orleans;
    using Polly;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GrainClient.Initialize(Server.MapPath("ClientConfiguration.xml"));

        }
    }
}