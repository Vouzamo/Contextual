using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core.Resolvers
{
    public class DefaultWhyResolver : IContextResolver<IWhy>
    {
        public IWhy Resolve(HttpRequest request)
        {
            return new DefaultWhyPillar(request);
        }
    }
}