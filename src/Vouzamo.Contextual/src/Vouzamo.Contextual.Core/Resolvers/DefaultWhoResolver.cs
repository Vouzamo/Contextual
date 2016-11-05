using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core.Resolvers
{
    public class DefaultWhoResolver : IContextResolver<IWho>
    {
        public IWho Resolve(HttpRequest request)
        {
            return new DefaultWhoPillar();
        }
    }
}