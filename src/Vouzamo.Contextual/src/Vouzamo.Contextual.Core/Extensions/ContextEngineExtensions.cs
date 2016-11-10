using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Extensions
{
    public static class ContextEngineExtensions
    {
        public static async Task<IEnumerable<T>> GetItemsUsingContext<T>(this IContextEngine engine, IEnumerable<Guid> ids, IContext context) where T : IItem, new()
        {
            var tasks = ids.Select(id => engine.GetItemUsingContext<T>(id, context));

            return await Task.WhenAll(tasks);
        }
    }
}
