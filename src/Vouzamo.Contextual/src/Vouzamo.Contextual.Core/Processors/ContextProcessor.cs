using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Extensions;

namespace Vouzamo.Contextual.Core.Processors
{
    public class ContextProcessor : IContextProcessor
    {
        public IContextResolverProvider Provider { get; protected set; }
        public IContextEngine Engine { get; protected set; }

        public ContextProcessor(IContextResolverProvider provider, IContextEngine engine)
        {
            Provider = provider;
            Engine = engine;
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
            var resolvers = Provider.LoadResolvers<T>();

            var pillars = resolvers.Select(resolver => resolver.Resolve(request));

            return Engine.ConsolidatePillers(pillars);
        }
    }
}