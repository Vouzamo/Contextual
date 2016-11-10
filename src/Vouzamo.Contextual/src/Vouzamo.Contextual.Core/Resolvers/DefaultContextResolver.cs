using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core.Resolvers
{
    public class DefaultContextResolver : IContextResolver
    {
        public async Task<IContext> Resolve(HttpContext httpContext)
        {
            var who = new DefaultWhoPillar();
            var what = new DefaultWhatPillar(DeviceType.Unknown);
            var where = new DefaultWherePillar(CultureInfo.CurrentCulture);
            var when = new DefaultWhenPillar();
            var why = new DefaultWhyPillar(httpContext.Request);

            return await Task.FromResult(new Context(who, what, where, when, why));
        }
    }
}