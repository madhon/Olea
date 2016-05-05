namespace IoT.WebApp
{
    using System;
    using System.Web;
    using IoT.WebApp.App_Start;
    using Orleans;
    using Orleans.Runtime.Configuration;

    /// <summary>
    /// 
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);

            var orleansConfig = ClientConfiguration.LocalhostSilo();
            GrainClient.Initialize(orleansConfig);

        }
    }
}