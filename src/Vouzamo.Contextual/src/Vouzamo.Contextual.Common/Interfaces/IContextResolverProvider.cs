using System.Collections.Generic;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextResolverProvider
    {
        IEnumerable<IContextResolver<T>> LoadResolvers<T>() where T : IContextPillar;
    }
}
