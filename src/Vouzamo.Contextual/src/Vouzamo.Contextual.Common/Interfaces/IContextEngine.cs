using System;
using System.Collections.Generic;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextEngine
    {
        T ConsolidatePillers<T>(IEnumerable<T> pillars) where T : IContextPillar;
        T GetItemUsingContext<T>(Guid id, IContext context) where T : IItem;
    }
}