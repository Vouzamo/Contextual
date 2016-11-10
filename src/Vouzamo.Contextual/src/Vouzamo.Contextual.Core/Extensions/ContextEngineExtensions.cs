using System;
using System.Collections.Generic;
using System.Linq;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Extensions
{
    public static class ContextEngineExtensions
    {
        public static IEnumerable<T> GetItemsUsingContext<T>(this IContextEngine engine, IEnumerable<Guid> ids, IContext context) where T : IItem
        {
            return ids.Select(id => engine.GetItemUsingContext<T>(id, context));
        }
    }
}
