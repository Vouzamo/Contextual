using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core
{
    public class ContextEngine : IContextEngine
    {
        private IContextResolverProvider ContextResolverProvider { get; set; }
        private ILogger<ContextEngine> Logger { get; set; }

        public ContextEngine(IContextResolverProvider contextResolverProvider, ILogger<ContextEngine> logger)
        {
            ContextResolverProvider = contextResolverProvider;
            Logger = logger;
        }

        public async Task<TResponse> Post<TResponse, TRequest>(string path, TRequest body)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost");

                //var response = await client.PostAsync(path, new StringContent(JsonConvert.SerializeObject(body)));
                var response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var itemJson = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<TResponse>(itemJson, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                }
            }

            return default(TResponse);
        }

        public async Task<IContext> ConsolidateContexts(IEnumerable<IContext> contexts)
        {
            var contextList = contexts.ToList();

            try
            {
                return contextList.Single();
            }
            catch
            {
                return await Post<IContext, IEnumerable<IContext>>($"/context/consolidate", contextList);
            }
        }

        public async Task<IContext> ProcessContext(HttpContext httpContext)
        {
            var resolvers = ContextResolverProvider.LoadResolvers();

            var tasks = resolvers.Select(resolver => resolver.Resolve(httpContext));

            var context = await Task.WhenAll(tasks);

            return await ConsolidateContexts(context);
        }

        public async Task<T> GetItemUsingContext<T>(Guid id, IContext context) where T : IItem, new()
        {
            return await Post<T, IContext>($"/item/{id}.json", context);
        }
    }
}
