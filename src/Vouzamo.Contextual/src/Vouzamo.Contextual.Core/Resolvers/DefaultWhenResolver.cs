using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core.Resolvers
{
    public class DefaultWhenResolver : IContextResolver<IWhen>
    {
        public IWhen Resolve(HttpRequest request)
        {
            return new DefaultWhenPillar();
        }
    }
}