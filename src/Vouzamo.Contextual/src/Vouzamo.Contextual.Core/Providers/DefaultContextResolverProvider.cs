using System.Collections.Generic;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Resolvers;

namespace Vouzamo.Contextual.Core.Providers
{
    public class DefaultContextResolverProvider : IContextResolverProvider
    {
        public IEnumerable<IContextResolver> LoadResolvers()
        {
            var resolvers = new List<IContextResolver>
            {
                new DefaultContextResolver()
            };

            return resolvers;
        }
    }
}
