using System.Globalization;
using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Pillars;

namespace Vouzamo.Contextual.Core
{
    public class ContextProcessor : IContextProcessor
    {
        public IContext Process(HttpRequest request)
        {
            // todo: This should be replaced with a MEF plugin system to consolidate various IContextResolver<T> into an IContext
            return new Context(new DefaultWhoPillar(), new DefaultWhatPillar(DeviceType.Unknown), new DefaultWherePillar(CultureInfo.CurrentCulture), new DefaultWhenPillar(), new DefaultWhyPillar(request));
        }
    }
}
