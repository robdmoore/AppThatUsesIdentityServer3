using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AnotherAppWithApi.Startup))]

namespace AnotherAppWithApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://appwithformsauth.localtest.me/identity",
                RequiredScopes = new[] { "reporting_api" }
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}
