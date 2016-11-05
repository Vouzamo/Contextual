using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core.Resolvers
{
    public class DefaultWhereResolver : IContextResolver<IWhere>
    {
        public IWhere Resolve(HttpRequest request)
        {
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;

            return new DefaultWherePillar(cultureInfo);
        }
    }
}