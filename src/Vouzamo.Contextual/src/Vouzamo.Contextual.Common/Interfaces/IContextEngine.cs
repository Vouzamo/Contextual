using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextEngine
    {
        Task<IContext> ProcessContext(HttpContext httpContext);
        Task<T> GetItemUsingContext<T>(Guid id, IContext context) where T : IItem, new();
    }
}