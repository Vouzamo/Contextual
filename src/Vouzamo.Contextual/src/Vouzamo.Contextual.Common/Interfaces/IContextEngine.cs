using System.Collections.Generic;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextEngine
    {
        T Consolidate<T>(IEnumerable<T> pillars) where T : IContextPillar;
    }
}