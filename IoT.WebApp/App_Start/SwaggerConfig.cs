using System.Web.Http;
using WebActivatorEx;
using IoT.WebApp;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace IoT.WebApp
{
    using System;
    using System.IO;
    using System.Reflection;

    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "IoT.WebApp");
                        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        var fileName = Assembly
                            .GetExecutingAssembly()
                            .GetName()
                            .Name + ".XML";
                        var commentsFile = Path.Combine(baseDirectory, "bin", fileName);
                        c.IncludeXmlComments(commentsFile);

                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
