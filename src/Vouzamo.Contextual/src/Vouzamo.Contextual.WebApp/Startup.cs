using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core;
using Vouzamo.Contextual.Core.Items;
using Vouzamo.Contextual.Core.Providers;

namespace Vouzamo.Contextual.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IItemSerializer, ItemSerializer>();
            services.AddTransient<IContextResolverProvider, DefaultContextResolverProvider>();
            services.AddTransient<IContextEngine, ContextEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async httpContext =>
            {
                var engine = app.ApplicationServices.GetService<IContextEngine>();
                var itemSerializer = app.ApplicationServices.GetService<IItemSerializer>();

                var context = await engine.ProcessContext(httpContext);

                var page = await engine.GetItemUsingContext<Page>(Guid.Parse("28e4a997-95bd-4dca-a853-6fc1fcbff93f"), context);

                foreach (var pageRegion in page.PageRegions)
                {
                    foreach (var componentPresentation in pageRegion.ComponentPresentations)
                    {
                        var customTemplateData = itemSerializer.Serialize<CustomTemplateData>(componentPresentation.ComponentTemplate);

                        var controller = customTemplateData.Controller;
                        var action = customTemplateData.Action;

                        // return httpContext.Action(customData.Action, customData.Controller, new { cp = componentPresentation });
                    }
                }
            });
        }
    }

    public class CustomTemplateData
    {
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
