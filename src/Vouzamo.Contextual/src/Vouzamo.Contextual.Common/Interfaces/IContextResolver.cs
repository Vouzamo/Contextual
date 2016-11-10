using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextResolver
    {
        Task<IContext> Resolve(HttpContext httpContext);
    }
}