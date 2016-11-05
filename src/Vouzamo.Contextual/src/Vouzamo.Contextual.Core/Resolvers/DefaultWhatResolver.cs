using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core.Resolvers
{
    public class DefaultWhatResolver : IContextResolver<IWhat>
    {
        public IWhat Resolve(HttpRequest request)
        {
            return new DefaultWhatPillar(DeviceType.Unknown);
        }
    }
}