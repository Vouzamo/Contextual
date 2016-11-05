using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core;
using Vouzamo.Contextual.WebApp.Extensions;

namespace Vouzamo.Contextual.WebApp.Processors
{
    public class ContextProcessor : IContextProcessor
    {
        public IContextEngine Engine { get; protected set; }

        private ContainerConfiguration Configuration { get; set; }

        public ContextProcessor(IContextEngine engine)
        {
            Engine = engine;

            Configure();
        }

        private void Configure()
        {
            var conventions = new ConventionBuilder();

            conventions.ForTypesDerivedFrom<IContextResolver<IWho>>()
                .Export<IContextResolver<IWho>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWho>>()
                .Export<IContextResolver<IWhat>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWho>>()
                .Export<IContextResolver<IWhere>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWho>>()
                .Export<IContextResolver<IWhen>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWho>>()
                .Export<IContextResolver<IWhy>>()
                .Shared();

            Configuration = new ContainerConfiguration()
                .WithAssembliesInPath(@"c:\plugins", conventions);
        }

        private IEnumerable<IContextResolver<T>> LoadResolvers<T>() where T : IContextPillar
        {
            using (var container = Configuration.CreateContainer())
            {
                return container.GetExports<IContextResolver<T>>();
            }
        }

        public IContext Process(HttpRequest request)
        {
            var who = Consolidate<IWho>(request);
            var what = Consolidate<IWhat>(request);
            var where = Consolidate<IWhere>(request);
            var when = Consolidate<IWhen>(request);
            var why = Consolidate<IWhy>(request);

            return new Context(who, what, where, when, why);
        }

        private T Consolidate<T>(HttpRequest request) where T : IContextPillar
        {
            var resolvers = LoadResolvers<T>();

            var pillars = resolvers.Select(resolver => resolver.Resolve(request));

            return Engine.Consolidate(pillars);
        }
    }
}
