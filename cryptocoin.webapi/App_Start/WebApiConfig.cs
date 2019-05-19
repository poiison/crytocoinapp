using System.Web.Http;
using System.Web.Http.Cors;

namespace cryptocoin.webapi
{
    public static class WebApiConfig
    {
        /// <summary>
        /// ConfigureWebApi
        /// </summary>
        /// <param name="config"></param>
        public static void ConfigureWebApi(this HttpConfiguration config)
        {
            Configure(config);
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="config"></param>
        public static void Configure(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Configuração de rotas
            config.MapHttpAttributeRoutes();

            //Força serialização JSON
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }

    }
}
