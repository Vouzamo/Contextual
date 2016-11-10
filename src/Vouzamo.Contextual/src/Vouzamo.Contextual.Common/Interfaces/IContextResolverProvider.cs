using System.Collections.Generic;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextResolverProvider
    {
        IEnumerable<IContextResolver> LoadResolvers();
    }
}
